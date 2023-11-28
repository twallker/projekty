using System.Drawing;

namespace Piasek
{
    public partial class Form1 : Form
    {
        class Ziarno
        {
            public Ziarno(Point pkt, Color color, int waga)
            {
                m_wspolrzedne = pkt;
                m_kolor = color;
                m_waga = waga;
            }
            public Point Xy { get => m_wspolrzedne; set => m_wspolrzedne = value; }
            public Color Kolor { get => m_kolor; set => m_kolor = value; }

            private Point m_wspolrzedne;
            private Color m_kolor;
            private int m_waga;
        }

        //List<Ziarno> ziarna;

        class Swiat
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

                ziarna = new List<Ziarno>(iloscZiaren);
                for (int y = 0; y < liniiPiasku; y++)
                {
                    for (int x = 0; x < obraz.Width; x++)
                    {
                        int kolorNumber = rnd.Next(wagi);
                        ziarna.Add(new Ziarno(new Point(x, y), kolory[kolorNumber], kolorNumber));
                    }
                }

                g = obraz.CreateGraphics();
            }

            public void Rysuj()
            {
                Bitmap bmp = new Bitmap(obraz.Width, obraz.Height);
                foreach (Ziarno ziarno in ziarna)
                {
                    bmp.SetPixel(ziarno.Xy.X, ziarno.Xy.Y, ziarno.Kolor);
                }
                g.DrawImage(bmp, 0, 0);
            }

            private List<Ziarno> ziarna;
            private Panel obraz;
            private int iloscZiaren;
            private int wagi;
            private List<Color> kolory;
            private Graphics g;
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

            //losuj iloœæ linii piasku 3-10
            int liniiPiasku = rnd.Next(3, 11);

            swiat = new Swiat(obraz, liniiPiasku, iloscKolorow);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            swiat.Rysuj();
        }

        static int nrRefr = 0;
        private void obraz_Paint(object sender, PaintEventArgs e)
        {
            //textBox1.Text = nrRefr.ToString();
            //if (nrRefr == 0)
            //{
            //    swiat.Rysuj();
            //    nrRefr++;
            //}
        }
    }
}