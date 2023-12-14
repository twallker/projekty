using System.Drawing;

namespace Piasek
{
    public partial class Form1 : Form
    {
        interface ISwiat
        {
            bool CheckPoint(int x, int y);
            bool CheckPoint(int x, int y, ref Ziarno? ziarno);

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
                    Random rnd = new Random();
                    //czy mo¿na przesun¹æ siê ni¿ej i 95% prawdopodobieñstwo spadku                    
                    if ((swiat.CheckPoint(x, y + 1)) && (rnd.Next(100) > 5))
                    {
                        lista[y + 1].Add(x, this);
                        lista[y].Remove(x);
                    }else
                    {
                        //prawdopodobienstwo spadku na ktoras strone
                        if (rnd.Next(m_maxwagi) < m_waga+1)
                        {
                            int strona = 0;
                            bool nextLeftZ = swiat.CheckPoint(x - 1, y + 1);
                            bool nextrightZ = swiat.CheckPoint(x + 1, y + 1);
                            if ((nextLeftZ) && (nextrightZ))
                            {
                                strona = rnd.Next(2) == 0 ? 1 : -1;
                            }
                            else
                            {
                                if (nextLeftZ) { strona = -1; }
                                if (nextrightZ) { strona = 1; }
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

            private Point m_wspolrzedne;
            private Color m_kolor;
            private int m_waga;
            private static int m_maxwagi = 0;
        }

        class Swiat : ISwiat
        {
            public Swiat(Panel obraz, int liniiPiasku, int wagi)
            {
                height = obraz.Height/ wielkoscZiarna;
                width = obraz.Width/ wielkoscZiarna;
                iloscZiaren = width * liniiPiasku;

                kolory = new List<Color>(wagi);                
                Random rnd = new Random();
                for (int i = 0; i < wagi; i++)
                {
                    kolory.Add(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                }

                lokalizacjaZiarna = new Dictionary<int, IDictionary<int, Ziarno>>();
                for (int y = 0; y < height; y++)
                {
                    lokalizacjaZiarna.Add(y, new Dictionary<int, Ziarno>());
                }

                ziarna = new List<Ziarno>(iloscZiaren);
                for (int y = 0; y < liniiPiasku; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int kolorNumber = rnd.Next(wagi);
                        Ziarno ziarno = new(new Point(x, y), kolory[kolorNumber], kolorNumber, wagi);
                        ziarna.Add(ziarno);
                        lokalizacjaZiarna[y][x] = ziarno;
                    }
                }
                //powietrze
                int iloscLuk = 8;
                //Color kolorPowietrza = Color.LightBlue;
                Color kolorPowietrza = Color.Black;
                for (int x = 0; x < width; ++x)
                {
                    if (rnd.Next(width) > iloscLuk)
                    {
                        Ziarno ziarno = new(new Point(x, liniiPiasku), kolorPowietrza, -1, wagi);
                        ziarna.Add(ziarno);
                        lokalizacjaZiarna[liniiPiasku][x] = ziarno;
                    }
                }

                g = obraz.CreateGraphics();
            }

            public void Rysuj()
            {
                g.Clear(background);
                Bitmap bmp = new Bitmap(width * wielkoscZiarna, height * wielkoscZiarna);
                for (int y = 0; y < height; y++)
                {
                    foreach (var para in lokalizacjaZiarna[y])
                    {
                        for (int xp= 0; xp < wielkoscZiarna;  xp++)
                            for (int yp= 0;yp < wielkoscZiarna; yp++)
                            {
                                bmp.SetPixel(para.Key * wielkoscZiarna + xp, y * wielkoscZiarna + yp, para.Value.Kolor);
                            }
                    }
                }
                g.DrawImage(bmp, 0, 0);
            }

            public void Przesun()
            {
                for (int y = height - 1; y >= 0; y--)
                {
                    foreach (var para in lokalizacjaZiarna[y])
                    {
                        int x = para.Key;
                        Ziarno ziarno = para.Value;
                        ziarno.Przesun(x, y, lokalizacjaZiarna, this);
                    }
                }
            }

            // return true gdy mozna siê przesun¹æ na ten punkt
            bool ISwiat.CheckPoint(int x, int y, ref Piasek.Form1.Ziarno? ziarno)
            {
                ziarno = null;
                if ((y < 0) || (y >= height) || (x < 0) || (x >= width))
                {
                    return false;
                }

                if (lokalizacjaZiarna.ContainsKey(y) && (lokalizacjaZiarna[y].ContainsKey(x)))
                {
                    ziarno = lokalizacjaZiarna[y][x];
                    return false;
                }
                return true;
            }

            // return true gdy mozna siê przesun¹æ na ten punkt
            bool ISwiat.CheckPoint(int x, int y)
            {
                if ((y < 0) || (y >= height) || (x < 0) || (x >= width))
                {
                    return false;
                }

                if (lokalizacjaZiarna.ContainsKey(y) && (lokalizacjaZiarna[y].ContainsKey(x)))
                {
                    return false;
                }
                return true;
            }

            private List<Ziarno> ziarna;
            private int height;
            private int width;
            private int wielkoscZiarna = 2;
            private int iloscZiaren;
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