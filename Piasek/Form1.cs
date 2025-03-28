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

                m_ziarna.Add(this);
            }

            public void move()
            {
                foreach (Ziarno ziarno in m_ziarna)
                {
                    //bmp.SetPixel(ziarno.Xy.X, ziarno.Xy.Y, ziarno.Kolor);
                }
            }
            public Point Xy { get => m_wspolrzedne; set => m_wspolrzedne = value; }
            public Color Kolor { get => m_kolor; set => m_kolor = value; }

            private Point m_wspolrzedne;
            private Color m_kolor;
            private int m_waga;

            public static List<Ziarno> m_ziarna;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void rysuj()
        {
            Graphics g = obraz.CreateGraphics();
            Bitmap bmp = new Bitmap(obraz.Width, obraz.Height);
            //foreach (Ziarno ziarno in ziarna)
            foreach (Ziarno ziarno in Ziarno.m_ziarna)
            {
                bmp.SetPixel(ziarno.Xy.X, ziarno.Xy.Y, ziarno.Kolor);
            }
            g.DrawImage(bmp, 0, 0);
        }

        private void rysuj(Graphics g)
        {

            ////Graphics g = obraz.CreateGraphics();
            //Bitmap bmp = new Bitmap(obraz.Width, obraz.Height);
            //foreach (Ziarno ziarno in ziarna)
            //{
            //    bmp.SetPixel(ziarno.Xy.X, ziarno.Xy.Y, ziarno.Kolor);
            //}
            //g.DrawImage(bmp, 0, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //losuj ilosc kolorów - 3-10
            Random rnd = new Random();
            int kolorCount = rnd.Next(3, 11);

            //generuj kolory
            List<Color> colors = new List<Color>();
            for (int i = 0; i < kolorCount; i++)
            {
                colors.Add(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            }

            //losuj ilosc linii piasku 3-10
            int linesCount = rnd.Next(3, 11);

            Ziarno.m_ziarna = new List<Ziarno>(obraz.Width * linesCount);
            for (int y = 0; y < linesCount; y++)
            {
                for (int x = 0; x < obraz.Width; x++)
                {
                    int kolorNumber = rnd.Next(colors.Count);
                    new Ziarno(new Point(x, y), colors[kolorNumber], kolorNumber);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rysuj();
        }

        static int nrRefr = 0;
        private void obraz_Paint(object sender, PaintEventArgs e)
        {
            //textBox1.Text = nrRefr.ToString();
            //if (nrRefr == 0)
            //{
            //    rysuj(e.Graphics);
            //    nrRefr++;
            //}
        }

        private void krok_Click(object sender, EventArgs e)
        {

        }
    }
}