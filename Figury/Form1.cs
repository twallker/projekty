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
            //dostępneParametry = [p0, p1, p2, p3, p4, p5, p6];
            dostępneWartosci = [v0, v1, v2, v3, v4, v5, v6];
            //if (dostępneParametry.Count != dostępneWartosci.Count)
            //{
            //    throw new InvalidOperationException("Musi być równa ilość opisów i wartości");
            //}
            foreach (IFigury f in dostepneFigury)
            {
                zasobnikFigur.Items.Add(f.nazwa);
            }
            zasobnikFigur.SelectedIndex = 0;
            figuries = new List<IFigury>();
        }

        //private void AktualizujParametry_sks(ReadOnlyCollection<string> etykiety, List<decimal> wartości)
        //{
        //    if (etykiety.Count != wartości.Count)
        //    {
        //        throw new InvalidOperationException("Ilość parametrów i wartości defaultowych sie nie zgadza");
        //    }
        //    if (etykiety.Count > dostępneParametry.Count)
        //    {
        //        throw new InvalidOperationException("Brak miejsca na parametry");
        //    }
        //    for (int i = 0; i < dostępneParametry.Count; i++)
        //    {
        //        if (i < etykiety.Count)
        //        {
        //            dostępneParametry[i].Text = etykiety[i];
        //            dostępneParametry[i].Visible = true;
        //            dostępneWartosci[i].Visible = true;
        //            dostępneWartosci[i].Value = wartości[i];
        //        }
        //        else
        //        {
        //            dostępneParametry[i].Text = "";
        //            dostępneParametry[i].Visible = false;
        //            dostępneWartosci[i].Visible = false;
        //        }
        //    }
        //}

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
                    //AktualizujParametry(f.GetParamNames, f.GetDefaultVal);
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
                //if (f.nazwa == zasobnikFigur.Text)
                //{

                //    IFigury obj = (IFigury)Activator.CreateInstance(f.GetType());
                //    if (obj == null) { throw new InvalidOperationException("Nie utworzono biektu!"); }
                //    List<decimal> param = new List<decimal>();
                //    foreach (System.Windows.Forms.NumericUpDown l in dostępneWartosci)
                //    {
                //        if (l.Visible) param.Add(l.Value);
                //    }

                //    if (obj.SetParameters(param))
                //    {//parametry przyjęte
                //        figuries.Add(obj);
                //        string nazwa = obj.nazwa + "_" + obj.id;
                //        userFig.Items.Add(nazwa);
                //        userFig.Text = nazwa;
                //        IFigury.licznik++;
                //    }
                //    Rysuj();
                //}
                if (f.nazwa == zasobnikFigur.Text)
                {

                    IFigury obj = (IFigury)Activator.CreateInstance(f.GetType());
                    if (obj == null) { throw new InvalidOperationException("Nie utworzono biektu!"); }

                    bool paramsOk = true;
                    foreach (Tuple<System.Windows.Forms.Label, System.Windows.Forms.NumericUpDown> para in dostępneKontrolki)
                    {
                        if (para.Item2.Visible)
                        {
                            obj.SetParam(para.Item1.Text, para.Item2.Value);
                        }
                    }


                    List<decimal> param = new List<decimal>();
                    foreach (System.Windows.Forms.NumericUpDown l in dostępneWartosci)
                    {
                        if (l.Visible) param.Add(l.Value);
                    }

                    if (obj.SetParameters(param))
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
                    //AktualizujParametry(f.GetParamNames, f.m_parametry);
                    AktualizujParametry2(f.GetParams);
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
                    List<decimal> param = new List<decimal>();
                    foreach (System.Windows.Forms.NumericUpDown l in dostępneWartosci)
                    {
                        if (l.Visible) param.Add(l.Value);
                    }
                    f.SetParameters(param);
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
                    figuries.Remove(f);
                    zasobnikFigur_SelectedIndexChanged(sender, e);
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
            m_parametry = new List<decimal>();
            id = licznik;
        }

        public static int licznik = 0;

        public int id { get; private set; }

        public string nazwa { get;  }

        public abstract Dictionary<string, decimal> GetParams { get; }

        public abstract bool SetParam(string key, decimal value);


        public List<decimal> m_parametry { get; private set; }

        public abstract ReadOnlyCollection<string> GetParamNames { get; }

        public abstract List<decimal> GetDefaultVal { get; }

        virtual public bool SetParameters(List<decimal> parametry)
        {
            if (parametry.Count != GetParamNames.Count)
            { 
                return false; 
            }
            m_parametry = parametry;
            return true;
        }

        abstract public void Rysuj(Graphics g, int width, int height);
    }

    public class Prostokąt : IFigury
    {
        public Dictionary<string, decimal> m_parametryf = new Dictionary<string, decimal> { { "Wys", 10 }, { "Szer", 20 }, { "X", 0 }, { "Y", 0 } };
        public override Dictionary<string, decimal> GetParams { get { return m_parametryf; } }

        public override bool SetParam(string key, decimal value)
        {
            if (!m_parametryf.ContainsKey(key))
            {
                return false;
            }

            m_parametryf["not"] = 5;
            return false;
        }

        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "Wys", "Szer", "X", "Y" }.AsReadOnly(); } }
        public override List<decimal> GetDefaultVal { get { return new List<decimal> { 10, 20, 0, 0 }; } }

        override public bool SetParameters(List<decimal> parametry)
        {
            if ((parametry[0] <= 0) || (parametry[1]) <= 0)
            {
                return false;
            }            
            return base.SetParameters(parametry);
        }

        public override void Rysuj(Graphics g, int width, int height)
        {
            float wysHalf = (float)m_parametry[0]/2;
            float szerHalf = (float)m_parametry[1]/2;
            PointF[] punkty = new PointF[4];
            punkty[0] = new PointF(-szerHalf, wysHalf);
            punkty[1] = new PointF(szerHalf, wysHalf);
            punkty[2] = new PointF(szerHalf, -wysHalf);
            punkty[3] = new PointF(-szerHalf, -wysHalf);            
            //Random rnd = new Random();
            //Point[] points={ new Point(0, 0), new Point(rnd.Next(10,30), rnd.Next(10,30)) };
            Pen pen = new Pen(Color.DarkGreen);
            g.DrawPolygon(pen, punkty);
        }
    }

    public class Kwadrat : IFigury
    {
        public Dictionary<string, decimal> m_parametryf = new Dictionary<string, decimal> { { "Bok", 20 }, { "X", 0 }, { "Y", 0 } };
        public override Dictionary<string, decimal> GetParams { get { return m_parametryf; } }

        public override bool SetParam(string key, decimal value)
        {
            return false;
        }


        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "Bok", "X", "Y" }.AsReadOnly(); } }
        public override List<decimal> GetDefaultVal { get { return new List<decimal> { 10, 0, 0 }; } }

        override public bool SetParameters(List<decimal> parametry)
        {
            if (parametry[0] <= 0)
            {
                return false;
            }
            return base.SetParameters(parametry);
        }
        public override void Rysuj(Graphics g, int width, int height)
        {
            throw new NotImplementedException();
        }
    }

    public class Koło : IFigury
    {
        public Dictionary<string, decimal> m_parametryf = new Dictionary<string, decimal> { { "R", 30 }, { "X", 0 }, { "Y", 0 } };
        public override Dictionary<string, decimal> GetParams { get { return m_parametryf; } }

        public override bool SetParam(string key, decimal value)
        {
            return false;
        }



        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "R", "X", "Y" }.AsReadOnly(); } }
        public override List<decimal> GetDefaultVal { get { return new List<decimal> { 20, 0, 0 }; } }

        override public bool SetParameters(List<decimal> parametry)
        {
            if (parametry[0] <= 0)
            {
                return false;
            }
            return base.SetParameters(parametry);
        }
        public override void Rysuj(Graphics g, int width, int height)
        {
            throw new NotImplementedException();
        }
    }
}
