using System.Drawing;

namespace Piasek
{
    public partial class Form1 : Form
    {
        interface ISwiat
        {
            //void IsNextFree();
            void IsNextFree(int x, int y, ref bool nextLeft, ref bool next, ref bool nextright);
        }
        class Ziarno
        {
            public Ziarno(Point pkt, Color color, int waga, int maxWagi)
            {
                m_wspolrzedne = pkt;
                m_kolor = color;
                m_waga = waga;
                m_maxwagi = maxWagi;
            }

            public void Przesun(int x, int y, IDictionary<int, IDictionary<int, Ziarno>> lista, ISwiat swiat)
            {
                if ((lista[y][x].m_waga >= 0) && (y+1 < lista.Count))
                {
                    bool nextLeft = false;
                    bool next = false;
                    bool nextright = false;
                    swiat.IsNextFree(x, y, ref nextLeft, ref next, ref nextright);
                    Random rnd = new Random();
                    //czy mo¿na przesun¹æ siê ni¿ej i 95% prawdopodobieñstwo spadku
                    if ((next) && (rnd.Next(100) > 5))
                    {
                        lista[y + 1].Add(x, lista[y][x]);
                        lista[y].Remove(x);
                    }else
                    {
                        //prawdopodobienstwo spadku na ktoras strone
                        if (rnd.Next(m_maxwagi) < m_waga)
                        {
                            int strona = 0;
                            if ((nextLeft) && (nextright))
                            {
                                if (rnd.Next(2) == 0) strona = -1;
                            }
                            else
                            { 
                                if (nextLeft) { strona = -1; }
                                if (nextright) { strona = 1; }
                            }
                            if (strona != 0) 
                            {
                                lista[y + 1].Add(x+strona, lista[y][x]);
                                lista[y].Remove(x);
                            }
                        }

                    }
                }
            }
            public Point Xy { get => m_wspolrzedne; set => m_wspolrzedne = value; }
            public Color Kolor { get => m_kolor; set => m_kolor = value; }

            public IDictionary<int, IDictionary<int, Ziarno>> UstawListe { set => m_lista = value; }


            private Point m_wspolrzedne;
            private Color m_kolor;
            private int m_waga;
            static private int m_maxwagi = 0;
            private static IDictionary<int, IDictionary<int, Ziarno>> m_lista = new Dictionary<int, IDictionary<int, Ziarno>>();
        }

        class Swiat : ISwiat
        {
            public Swiat(Panel obraz, int liniiPiasku, int wagi)
            {
                this.obraz = obraz;
                iloscZiaren = obraz.Width * liniiPiasku;

                kolory = new List<Color>(wagi);
                Random rnd = new Random();
                for (int i = 0; i < wagi; i++)
                {
                    kolory.Add(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                }

                lokalizacjaZiarna = new Dictionary<int, IDictionary<int, Ziarno>>();
                for (int y = 0; y < obraz.Height; y++)
                {
                    lokalizacjaZiarna.Add(y, new Dictionary<int, Ziarno>());
                }

                ziarna = new List<Ziarno>(iloscZiaren);
                for (int y = 0; y < liniiPiasku; y++)
                {
                    for (int x = 0; x < obraz.Width; x++)
                    {
                        int kolorNumber = rnd.Next(wagi);
                        Ziarno ziarno = new(new Point(x, y), kolory[kolorNumber], kolorNumber, wagi);
                        ziarna.Add(ziarno);
                        lokalizacjaZiarna[y][x] = ziarno;
                    }
                }
                //powietrze
                int iloscLuk = 5;
                for (int x = 0; x < obraz.Width; ++x)
                {
                    if (rnd.Next(obraz.Width) > iloscLuk)
                    {
                        Ziarno ziarno = new(new Point(x, liniiPiasku), Color.LightBlue, -1, wagi);
                        ziarna.Add(ziarno);
                        lokalizacjaZiarna[liniiPiasku][x] = ziarno;
                    }
                }

                g = obraz.CreateGraphics();
            }

            public void Rysuj()
            {
                g.Clear(background);
                Bitmap bmp = new Bitmap(obraz.Width, obraz.Height);
                for (int y = 0; y < obraz.Height; y++)
                {
                    foreach (var para in lokalizacjaZiarna[y])
                    {
                        bmp.SetPixel(para.Key, y, para.Value.Kolor);
                    }
                }
                g.DrawImage(bmp, 0, 0);
            }

            public void Przesun()
            {
                for (int y = obraz.Height - 1; y >= 0; y--)
                {
                    foreach (var para in lokalizacjaZiarna[y])
                    {
                        int x = para.Key;
                        Ziarno ziarno = para.Value;
                        ziarno.Przesun(x, y, lokalizacjaZiarna, this);
                    }
                }
            }

            void ISwiat.IsNextFree(int x, int y, ref bool nextLeft, ref bool next, ref bool nextright)
            {
                nextLeft = false;
                next = false;
                nextright = false;
                y++;
                if(y < lokalizacjaZiarna.Count)
                {
                    if (x - 1 >= 0) { nextLeft = !lokalizacjaZiarna[y].ContainsKey(x - 1); }
                    next = !lokalizacjaZiarna[y].ContainsKey(x);
                    if (x + 1 < obraz.Width) { nextright = !lokalizacjaZiarna[y].ContainsKey(x + 1); }
                }
            }

            private List<Ziarno> ziarna;
            private Panel obraz;
            private int iloscZiaren;
            private int wagi;
            private List<Color> kolory;
            private Graphics g;
            IDictionary<int, IDictionary<int, Ziarno>> lokalizacjaZiarna;
            Color background = Color.LightGray;
        }

        Swiat swiat;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //losuj iloœæ kolorów - 3-10
            Random rnd = new Random();
            int iloscKolorow = rnd.Next(3, 11);

            //losuj iloœæ linii piasku
            int liniiPiasku = rnd.Next(10, 30);

            swiat = new Swiat(obraz, liniiPiasku, iloscKolorow);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //swiat.Przesun();
            //swiat.Rysuj();
            timer1.Start();
            timer2.Start();
        }

        private void obraz_Paint(object sender, PaintEventArgs e)
        {
            swiat.Rysuj();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            swiat.Przesun();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            swiat.Rysuj();
        }
    }
}