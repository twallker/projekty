using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;

namespace Figury
{
    public partial class Form1 : Form
    {
        private List<IFigury> dostepneFigury = [new Prostokąt(), new Kwadrat(), new Koło(), new Trójkąt()];
        private List<System.Windows.Forms.NumericUpDown> dostępneWartosci;
        private List<Tuple<System.Windows.Forms.Label, System.Windows.Forms.NumericUpDown>> dostępneKontrolki;
        private List<IFigury> figuries;
        private Point mouseDown;
        public Form1()
        {
            InitializeComponent();
            dostępneKontrolki = [Tuple.Create(p0,v0), Tuple.Create(p1, v1), Tuple.Create(p2, v2),
                                 Tuple.Create(p3, v3), Tuple.Create(p4, v4), Tuple.Create(p5, v5), Tuple.Create(p6, v6)];
            dostępneWartosci = [v0, v1, v2, v3, v4, v5, v6];
            foreach (IFigury f in dostepneFigury)
            {
                zasobnikFigur.Items.Add(f.nazwa);
            }
            zasobnikFigur.SelectedIndex = 0;
            figuries = new List<IFigury>();
        }

        private void AktualizujParametryFiguryzKontrolekiRysuj()
        {
            //uaktualnij parametry w figurach
            foreach (IFigury f in figuries)
            {
                if (userFig.Text == f.nazwa + "_" + f.id)
                {
                    Dictionary<string, decimal> wartosci = new Dictionary<string, decimal>();
                    foreach (Tuple<System.Windows.Forms.Label, System.Windows.Forms.NumericUpDown> para in dostępneKontrolki)
                    {
                        if (para.Item1.Visible && para.Item2.Visible)
                        {
                            wartosci.Add(para.Item1.Text, para.Item2.Value);
                        }
                    }
                    f.SetParameters(wartosci);
                    Rysuj();
                    return;
                }
            }
        }

        private void PrzesunFigure(Point actualMouse)
        {

            foreach (IFigury f in figuries)
            {
                if (userFig.Text == f.nazwa + "_" + f.id)
                {
                    int dx = actualMouse.X - mouseDown.X;
                    int dy = actualMouse.Y - mouseDown.Y;

                    int x = -1;
                    int y = -1;
                    for (int i = 0; i < dostępneKontrolki.Count; i++)
                    {
                        if (dostępneKontrolki[i].Item1.Visible && dostępneKontrolki[i].Item2.Visible && dostępneKontrolki[i].Item1.Text == "X")
                        {
                            x = i;
                        }
                        if (dostępneKontrolki[i].Item1.Visible && dostępneKontrolki[i].Item2.Visible && dostępneKontrolki[i].Item1.Text == "Y")
                        {
                            y = i;
                        }
                    }
                    if (x == -1 || y == -1) return;

                    // uaktualnij kontrolki, są obie warttośći X i Y
                    dostępneKontrolki[x].Item2.Value += dx;
                    dostępneKontrolki[y].Item2.Value -= dy;

                    AktualizujParametryFiguryzKontrolekiRysuj();
                }
            }
        }

        private void PokazParametryFigury(Dictionary<string, decimal> parametry)
        {
            if (parametry.Count > dostępneKontrolki.Count)
            {
                throw new InvalidOperationException("Brak miejsca na parametry");
            }
            for (int i = 0; i < dostępneKontrolki.Count; i++)
            {
                if (i < parametry.Count)
                {
                    dostępneKontrolki[i].Item1.Text = parametry.ElementAt(i).Key;
                    dostępneKontrolki[i].Item1.Visible = true;
                    dostępneKontrolki[i].Item2.Value = parametry.ElementAt(i).Value;
                    dostępneKontrolki[i].Item2.Visible = true;
                }
                else
                {
                    dostępneKontrolki[i].Item1.Text = "";
                    dostępneKontrolki[i].Item1.Visible = false;
                    dostępneKontrolki[i].Item2.Visible = false;
                }
            }
        }

        private void Rysuj()
        {
            if (figuries.Count <= 0) return;
            Graphics g = panelRysuj.CreateGraphics();
            g.Clear(BackColor);
            foreach (IFigury f in figuries)
            {
                Pen pen;
                if (userFig.Text == f.nazwa + "_" + f.id)
                {
                    pen = new Pen(Color.Red);
                }
                else
                {
                    pen = new Pen(Color.DarkGreen);
                }
                f.Rysuj(g, panelRysuj.Width, panelRysuj.Height, pen);
            }
        }

        private void zasobnikFigur_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (IFigury f in dostepneFigury)
            {
                if (f.nazwa == zasobnikFigur.Text)
                {
                    PokazParametryFigury(f.GetParams);
                    return;
                }
            }
            for (int i = 0; i < dostępneKontrolki.Count; i++)
            {
                dostępneKontrolki[i].Item1.Visible = false;
                dostępneKontrolki[i].Item2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {//dodaj nową figurę
            foreach (IFigury f in dostepneFigury)
            {
                if (f.nazwa == zasobnikFigur.Text)
                {

                    IFigury obj = f.CreateNewFig();


                    Dictionary<string, decimal> wartosci = new Dictionary<string, decimal>();
                    foreach (Tuple<System.Windows.Forms.Label, System.Windows.Forms.NumericUpDown> para in dostępneKontrolki)
                    {
                        if (para.Item1.Visible && para.Item2.Visible)
                        {
                            wartosci.Add(para.Item1.Text, para.Item2.Value);
                        }
                    }
                    if (obj.SetParameters(wartosci))
                    {//parametry przyjęte
                        figuries.Add(obj);
                        string nazwa = obj.nazwa + "_" + obj.id;
                        userFig.Items.Add(nazwa);
                        userFig.Text = nazwa;
                        IFigury.licznik++;
                    }
                    Rysuj();
                }
            }
        }

        private void userFig_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //uaktualnij kontrolki po wybraniu figury z zapamiętanej listy
            foreach (IFigury f in figuries)
            {
                if (userFig.Text == f.nazwa + "_" + f.id)
                {
                    zasobnikFigur.Text = f.nazwa;
                    PokazParametryFigury(f.GetParams);
                    Rysuj();
                    return;
                }
            }
        }

        private void Aktualizuj_Click(object sender, EventArgs e)
        {
            AktualizujParametryFiguryzKontrolekiRysuj();
        }

        private void Usuń_Click(object sender, EventArgs e)
        {
            foreach (IFigury f in figuries)
            {
                if (userFig.Text == f.nazwa + "_" + f.id)
                {
                    userFig.Items.Remove(f.nazwa + "_" + f.id);
                    int index = figuries.IndexOf(f);
                    figuries.Remove(f);
                    if (figuries.Count > index)
                    {
                        userFig.SelectedIndex = index;
                    }
                    else
                    {
                        userFig.SelectedIndex = figuries.Count - 1;
                    }
                    Rysuj();
                    return;
                }
            }
        }

        private void panelRysuj_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (IFigury f in figuries)
            {
                if (userFig.Text == f.nazwa + "_" + f.id)
                {
                    //mouseDown = e.Location;
                    mouseDown = MousePosition;
                    CykliczneRysowanieFigur.Start();
                }
            }
        }

        private void panelRysuj_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (IFigury f in figuries)
            {
                if (userFig.Text == f.nazwa + "_" + f.id)
                {
                    CykliczneRysowanieFigur.Stop();
                    PrzesunFigure(MousePosition);
                }
            }
        }

        private void CykliczneRysowanieFigur_Tick(object sender, EventArgs e)
        {
            //AktualizujParametryFiguryzKontrolekiRysuj();
            PrzesunFigure(MousePosition);
            mouseDown = MousePosition;
        }
    }
    public abstract class IFigury
    {
        public IFigury()
        {
            nazwa = this.GetType().Name;
            id = licznik;
        }

        public static int licznik = 0;

        public int id { get; private set; }

        public string nazwa { get;  }

        public abstract Dictionary<string, decimal> GetParams { get; }

        virtual public bool SetParameters(Dictionary<string, decimal> parametry)
        {
            foreach (var param in GetParams)
            {
                if (parametry.ContainsKey(param.Key))
                {
                    GetParams[param.Key] = parametry[param.Key];
                }
                else
                {
                    throw new Exception("Nie zgadzają się parametry");
                    //return false;
                }
            }
            return true;
        }

        virtual protected bool CheckParameters(Dictionary<string, decimal> parametry)
        {
            if (parametry.Count != GetParams.Count)
            {
                return false;
            }
            foreach (var param in GetParams)
            {
                if (!parametry.ContainsKey(param.Key))
                {
                    return false;
                }
            }
            return true;
        }

        abstract public void Rysuj(Graphics g, int width, int height, Pen pen);

        virtual protected void Obrót(PointF[] punkty, double degRotate)
        {
            double radRotate = degRotate * Math.PI / 180;
            for (int i = 0; i < punkty.Length; i++)
            {
                float x = punkty[i].X;
                float y = punkty[i].Y;
                punkty[i].X = (float)(x * Math.Cos(radRotate) - y * Math.Sin(radRotate));
                punkty[i].Y = (float)(x * Math.Sin(radRotate) + y * Math.Cos(radRotate));
            }
        }

        virtual protected void MoveXY(PointF[] punkty, float x, float y)
        {
            for (int i = 0; i < punkty.Length; i++)
            {
                punkty[i].X += x;
                punkty[i].Y += y;
            }
        }

        virtual protected void KorektaWspółrzędnych(PointF[] punkty, int width, int height)
        {
            float w2 = width / 2;
            float h2 = height / 2;
            for (int i = 0; i < punkty.Length; i++)
            {
                punkty[i].X += w2;
                punkty[i].Y = h2 - punkty[i].Y;
            }
        }

        abstract public IFigury CreateNewFig();
    }

    public class Prostokąt : IFigury
    {
        private readonly Dictionary<string, decimal> m_parametryf = new Dictionary<string, decimal> { { "Wys", 50 }, { "Szer", 100 }, { "X", 0 }, { "Y", 0 }, { "Obrót", 0 } };        
        public override Dictionary<string, decimal> GetParams { get { return m_parametryf; } }

        public override bool SetParameters(Dictionary<string, decimal> parametry)
        {
            if (!CheckParameters(parametry))
            {
                return false;
            }
            if ((parametry["Wys"]<=0) || (parametry["Szer"]<=0))
            {
                return false;
            }
            return base.SetParameters(parametry);
        }

        public override void Rysuj(Graphics g, int width, int height, Pen pen)
        {
            float wysHalf = (float)m_parametryf["Wys"] / 2;
            float szerHalf = (float)m_parametryf["Szer"] / 2;
            PointF[] punkty = new PointF[4];
            punkty[0] = new PointF(-szerHalf, wysHalf);
            punkty[1] = new PointF(szerHalf, wysHalf);
            punkty[2] = new PointF(szerHalf, -wysHalf);
            punkty[3] = new PointF(-szerHalf, -wysHalf);

            Obrót(punkty, (double)m_parametryf["Obrót"]);
            MoveXY(punkty, (float)m_parametryf["X"], (float)m_parametryf["Y"]);
            KorektaWspółrzędnych(punkty, width, height);
          
            ////Random rnd = new Random();
            ////Point[] points={ new Point(0, 0), new Point(rnd.Next(10,30), rnd.Next(10,30)) };
            g.DrawPolygon(pen, punkty);
        }

        public override IFigury CreateNewFig()
        {
            return new Prostokąt();
        }
    }

    public class Kwadrat : IFigury
    {
        private readonly Dictionary<string, decimal> m_parametryf = new Dictionary<string, decimal> { { "Bok", 90 }, { "X", 0 }, { "Y", 0 }, { "Obrót", 0 } };
        public override Dictionary<string, decimal> GetParams { get { return m_parametryf; } }

        public override bool SetParameters(Dictionary<string, decimal> parametry)
        {
            if (!CheckParameters(parametry))
            {
                return false;
            }
            if (parametry["Bok"] <= 0)
            {
                return false;
            }
            return base.SetParameters(parametry);
        }

        public override void Rysuj(Graphics g, int width, int height, Pen pen)
        {
            float bokHalf = (float)m_parametryf["Bok"] / 2;
            PointF[] punkty = new PointF[4];
            punkty[0] = new PointF(-bokHalf, bokHalf);
            punkty[1] = new PointF(bokHalf, bokHalf);
            punkty[2] = new PointF(bokHalf, -bokHalf);
            punkty[3] = new PointF(-bokHalf, -bokHalf);

            Obrót(punkty, (double)m_parametryf["Obrót"]);
            MoveXY(punkty, (float)m_parametryf["X"], (float)m_parametryf["Y"]);
            KorektaWspółrzędnych(punkty, width, height);

            ////Random rnd = new Random();
            ////Point[] points={ new Point(0, 0), new Point(rnd.Next(10,30), rnd.Next(10,30)) };
            g.DrawPolygon(pen, punkty);
        }

        public override IFigury CreateNewFig()
        {
            return new Kwadrat();
        }
    }

    public class Koło : IFigury
    {
        private readonly Dictionary<string, decimal> m_parametryf = new Dictionary<string, decimal> { { "R", 120 }, { "X", 0 }, { "Y", 0 } };
        public override Dictionary<string, decimal> GetParams { get { return m_parametryf; } }

        public override void Rysuj(Graphics g, int width, int height, Pen pen)
        {
            float R = (float)m_parametryf["R"];
            float X = (float)m_parametryf["X"] + width / 2 - R;
            float Y = -(float)m_parametryf["Y"] + height / 2 - R;
            ////Random rnd = new Random();
            ////Point[] points={ new Point(0, 0), new Point(rnd.Next(10,30), rnd.Next(10,30)) };
            g.DrawEllipse(pen, X, Y, 2 * R, 2 * R);
        }

        public override bool SetParameters(Dictionary<string, decimal> parametry)
        {
            if (!CheckParameters(parametry))
            {
                return false;
            }
            if (parametry["R"] <= 0)
            {
                return false;
            }
            return base.SetParameters(parametry);
        }

        public override IFigury CreateNewFig()
        {
            return new Koło();
        }
    }

    public class Trójkąt : IFigury
    {
        private readonly Dictionary<string, decimal> m_parametryf = new Dictionary<string, decimal> { { "Bok", 220 }, { "X", 0 }, { "Y", 0 }, { "Obrót", 0 } };
        public override Dictionary<string, decimal> GetParams { get { return m_parametryf; } }
        public override IFigury CreateNewFig()
        {
            return new Trójkąt();
        }

        public override void Rysuj(Graphics g, int width, int height, Pen pen)
        {
            float bok = (float)m_parametryf["Bok"];
            float h = 0.866f * bok;

            float X1 = -bok / 2;
            float X2 = 0;
            float X3 = bok / 2;

            float Y1 = -h / 3;
            float Y2 = h * 2 / 3;
            float Y3 = Y1;
            PointF[] punkty = new PointF[3];
            punkty[0] = new PointF(X1, Y1);
            punkty[1] = new PointF(X2, Y2);
            punkty[2] = new PointF(X3, Y3);

            Obrót(punkty, (double)m_parametryf["Obrót"]);
            MoveXY(punkty, (float)m_parametryf["X"], (float)m_parametryf["Y"]);
            KorektaWspółrzędnych(punkty, width, height);

            g.DrawPolygon(pen, punkty);
        }

    }
}
