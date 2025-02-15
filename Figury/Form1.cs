using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Figury
{
    public partial class Form1 : Form
    {
        private List<IFigury> dostepneFigury = [new Prostokąt(), new Kwadrat(), new Koło()];
        private List<System.Windows.Forms.NumericUpDown> dostępneWartosci;
        //private List<System.Windows.Forms.Label> dostępneParametry;
        private List<Tuple<System.Windows.Forms.Label, System.Windows.Forms.NumericUpDown>> dostępneKontrolki;
        private List<IFigury> figuries;
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

        private void AktualizujParametry2(Dictionary<string, decimal> parametry)
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
            Graphics g = panelRysuj.CreateGraphics();
            g.Clear(BackColor);
            foreach (IFigury f in figuries)
            {
                f.Rysuj(g, panelRysuj.Width, panelRysuj.Height);
            }
        }

        private void zasobnikFigur_SelectedIndexChanged(object sender, EventArgs e)        
        {
            foreach (IFigury f in dostepneFigury)
            {
                if (f.nazwa == zasobnikFigur.Text)
                {
                    AktualizujParametry2(f.GetParams);
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

                    IFigury obj = (IFigury)Activator.CreateInstance(f.GetType());
                    if (obj == null) { throw new InvalidOperationException("Nie utworzono biektu!"); }


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
                    if (zasobnikFigur.Text == f.nazwa)
                    {
                        AktualizujParametry2(f.GetParams);//todo błąd!
                    }
                    else
                    {
                        zasobnikFigur.Text = f.nazwa;
                    }
                    return;
                }
            }
        }

        private void Aktualizuj_Click(object sender, EventArgs e)
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
                        userFig.SelectedIndex = figuries.Count-1;
                    }
                    Rysuj();
                    return;
                }
            }
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

        public abstract ReadOnlyCollection<string> GetParamNames { get; }

        public abstract List<decimal> GetDefaultVal { get; }

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

        abstract public void Rysuj(Graphics g, int width, int height);
    }

    public class Prostokąt : IFigury
    {
        private readonly Dictionary<string, decimal> m_parametryf = new Dictionary<string, decimal> { { "Wys", 10 }, { "Szer", 20 }, { "X", 0 }, { "Y", 0 } };        
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

        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "Wys", "Szer", "X", "Y" }.AsReadOnly(); } }
        public override List<decimal> GetDefaultVal { get { return new List<decimal> { 10, 20, 0, 0 }; } }

        public override void Rysuj(Graphics g, int width, int height)
        {
            float wysHalf = (float)m_parametryf["Wys"]/2;
            float szerHalf = (float)m_parametryf["Szer"]/2;
            float X = (float)m_parametryf["X"] + width/2;
            float Y = -(float)m_parametryf["Y"] + height/2;
            PointF[] punkty = new PointF[4];
            punkty[0] = new PointF(-szerHalf+X, wysHalf+Y);
            punkty[1] = new PointF(szerHalf+X, wysHalf+Y);
            punkty[2] = new PointF(szerHalf+X, -wysHalf + Y);
            punkty[3] = new PointF(-szerHalf+X, -wysHalf + Y);            
            ////Random rnd = new Random();
            ////Point[] points={ new Point(0, 0), new Point(rnd.Next(10,30), rnd.Next(10,30)) };
            Pen pen = new Pen(Color.DarkGreen);
            g.DrawPolygon(pen, punkty);
        }
    }

    public class Kwadrat : IFigury
    {
        private readonly Dictionary<string, decimal> m_parametryf = new Dictionary<string, decimal> { { "Bok", 20 }, { "X", 0 }, { "Y", 0 } };
        public override Dictionary<string, decimal> GetParams { get { return m_parametryf; } }

        public override bool SetParameters(Dictionary<string, decimal> parametry)
        {
            return true;
        }


        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "Bok", "X", "Y" }.AsReadOnly(); } }
        public override List<decimal> GetDefaultVal { get { return new List<decimal> { 10, 0, 0 }; } }

        public override void Rysuj(Graphics g, int width, int height)
        {
            float bokHalf = (float)m_parametryf["Bok"] / 2;
            float X = (float)m_parametryf["X"] + width / 2;
            float Y = -(float)m_parametryf["Y"] + height / 2;
            PointF[] punkty = new PointF[4];
            punkty[0] = new PointF(-bokHalf + X, bokHalf + Y);
            punkty[1] = new PointF(bokHalf + X, bokHalf + Y);
            punkty[2] = new PointF(bokHalf + X, -bokHalf + Y);
            punkty[3] = new PointF(-bokHalf + X, -bokHalf + Y);
            ////Random rnd = new Random();
            ////Point[] points={ new Point(0, 0), new Point(rnd.Next(10,30), rnd.Next(10,30)) };
            Pen pen = new Pen(Color.DarkGreen);
            g.DrawPolygon(pen, punkty);
        }
    }

    public class Koło : IFigury
    {
        private readonly Dictionary<string, decimal> m_parametryf = new Dictionary<string, decimal> { { "R", 30 }, { "X", 0 }, { "Y", 0 } };
        public override Dictionary<string, decimal> GetParams { get { return m_parametryf; } }

        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "R", "X", "Y" }.AsReadOnly(); } }
        public override List<decimal> GetDefaultVal { get { return new List<decimal> { 20, 0, 0 }; } }

        public override void Rysuj(Graphics g, int width, int height)
        {
            float R = (float)m_parametryf["R"];
            float X = (float)m_parametryf["X"] + width / 2 - R / 2;
            float Y = -(float)m_parametryf["Y"] + height / 2 - R / 2;            
            ////Random rnd = new Random();
            ////Point[] points={ new Point(0, 0), new Point(rnd.Next(10,30), rnd.Next(10,30)) };
            Pen pen = new Pen(Color.DarkGreen);
            g.DrawEllipse(pen, X, Y, R, R);
        }
    }
}
