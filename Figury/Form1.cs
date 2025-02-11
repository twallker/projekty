using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Figury
{
    public partial class Form1 : Form
    {
        private List<IFigury> dostepneFigury = [new Prostokąt(), new Kwadrat(), new Koło()];
        private List<System.Windows.Forms.NumericUpDown> dostępneWartosci;
        private List<System.Windows.Forms.Label> dostępneParametry;
        private List<IFigury> figuries;
        public Form1()
        {
            InitializeComponent();
            dostępneParametry = [p0, p1, p2, p3, p4, p5, p6];
            dostępneWartosci = [v0, v1, v2, v3, v4, v5, v6];
            if (dostępneParametry.Count != dostępneWartosci.Count)
            {
                throw new InvalidOperationException("Musi być równa ilość opisów i wartości");
            }
            foreach (IFigury f in dostepneFigury)
            {
                zasobnikFigur.Items.Add(f.nazwa);
            }
            zasobnikFigur.SelectedIndex = 0;
            figuries = new List<IFigury>();
        }

        private void AktualizujParametry(ReadOnlyCollection<string> etykiety, List<decimal> wartości)
        {
            if (etykiety.Count != wartości.Count)
            {
                throw new InvalidOperationException("Ilość parametrów i wartości defaultowych sie nie zgadza");
            }
            if (etykiety.Count > dostępneParametry.Count)
            {
                throw new InvalidOperationException("Brak miejsca na parametry");
            }
            for (int i = 0; i < dostępneParametry.Count; i++)
            {
                if (i < etykiety.Count)
                {
                    dostępneParametry[i].Text = etykiety[i];
                    dostępneParametry[i].Visible = true;
                    dostępneWartosci[i].Visible = true;
                    dostępneWartosci[i].Value = wartości[i];
                }
                else
                {
                    dostępneParametry[i].Text = "";
                    dostępneParametry[i].Visible = false;
                    dostępneWartosci[i].Visible = false;
                }
            }
        }

        private void zasobnikFigur_SelectedIndexChanged(object sender, EventArgs e)
        //private void zasobnikFigur_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (IFigury f in dostepneFigury)
            {
                if (f.nazwa == zasobnikFigur.Text)
                {
                    AktualizujParametry(f.GetParamNames, f.GetDefaultVal);
                    return;
                }
            }
            for (int i = 0; i < dostępneParametry.Count; i++)
            {
                dostępneParametry[i].Visible = false;
                dostępneWartosci[i].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (IFigury f in dostepneFigury)
            {
                if (f.nazwa == zasobnikFigur.Text)
                {

                    IFigury obj = (IFigury)Activator.CreateInstance(f.GetType());
                    if (obj == null) { throw new InvalidOperationException("Nie utworzono biektu!"); }
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
                    AktualizujParametry(f.GetParamNames, f.m_parametry);
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

        abstract public void Rysuj();
    }

    public class Prostokąt : IFigury
    {
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

        public override void Rysuj()
        {
            throw new NotImplementedException();
        }
    }

    public class Kwadrat : IFigury
    {
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
        public override void Rysuj()
        {
            throw new NotImplementedException();
        }
    }

    public class Koło : IFigury
    {
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
        public override void Rysuj()
        {
            throw new NotImplementedException();
        }
    }
}
