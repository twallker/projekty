using System.Collections.ObjectModel;

namespace Figury
{
    public partial class Form1 : Form
    {
        private List<IFigury> dostepneFigury = [new Prostok�t(), new Kwadrat(), new Ko�o()];
        private List<System.Windows.Forms.NumericUpDown> dost�pneWartosci;
        private List<System.Windows.Forms.Label> dost�pneParametry;
        private List<IFigury> figuries;
        public Form1()
        {
            InitializeComponent();
            IFigury.licznik = 0;
            dost�pneParametry = [p0, p1, p2, p3, p4, p5, p6];
            dost�pneWartosci = [v0, v1, v2, v3, v4, v5, v6];
            if (dost�pneParametry.Count != dost�pneWartosci.Count)
            {
                throw new InvalidOperationException("Musi by� r�wna ilo�� opis�w i warto�ci");
            }
            foreach (IFigury f in dostepneFigury)
            {
                zasobnikFigur.Items.Add(f.nazwa);
            }
            zasobnikFigur.SelectedIndex = 0;
            figuries = new List<IFigury>();
        }

        private void zasobnikFigur_SelectedIndexChanged(object sender, EventArgs e)
        //private void zasobnikFigur_SelectionChangeCommitted(object sender, EventArgs e)
        {
            bool found = false;
            foreach (IFigury f in dostepneFigury)
            {
                if (f.nazwa == zasobnikFigur.Text)
                {
                    found = true;
                    var lista = f.GetParamNames;
                    var defVal = f.GetDefaultVal;
                    if (lista.Count != defVal.Count)
                    {
                        throw new InvalidOperationException("Ilo�� parametr�w i warto�ci defaultowych sie nie zgadza");
                    }
                    if (lista.Count > dost�pneParametry.Count)
                    {
                        throw new InvalidOperationException("Brak miejsca na parametry");
                    }
                    for (int i = 0; i < dost�pneParametry.Count; i++)
                    {
                        if (i < lista.Count)
                        {
                            dost�pneParametry[i].Text = lista[i];
                            dost�pneParametry[i].Visible = true;
                            dost�pneWartosci[i].Visible = true;
                            dost�pneWartosci[i].Value = defVal[i];
                        }
                        else
                        {
                            dost�pneParametry[i].Text = "";
                            dost�pneParametry[i].Visible = false;
                            dost�pneWartosci[i].Visible = false;
                        }
                    }
                }
            }
            if (!found)
            {
                for (int i = 0; i < dost�pneParametry.Count; i++)
                {
                    dost�pneParametry[i].Visible = false;
                    dost�pneWartosci[i].Visible = false;
                }
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
                    figuries.Add(obj);
                    string nazwa = obj.nazwa + "_" + obj.id;
                    userFig.Items.Add(nazwa);
                    userFig.Text = nazwa;
                    List<decimal> param = new List<decimal>();
                    foreach (System.Windows.Forms.NumericUpDown l in dost�pneWartosci)
                    {
                        if (l.Visible) param.Add(l.Value);
                    }
                    obj.SetParameters(param);
                }
            }
        }

        private void userFig_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Text = IFigury.licznik.ToString();
            IFigury.licznik++;
        }
    }
    public abstract class IFigury
    {
        public IFigury()
        {
            nazwa = this.GetType().Name;
            id = licznik++;
        }

        public static int licznik = 0;

        public int id { get; }

        public string nazwa { get;  }

        public abstract ReadOnlyCollection<string> GetParamNames { get; }

        public abstract ReadOnlyCollection<int> GetDefaultVal { get; }

        virtual public bool SetParameters(List<decimal> parametry)
        {
            if (parametry.Count != GetParamNames.Count)
            { 
                return false; 
            }
            return true;
        }
    }

    public class Prostok�t : IFigury
    {
        private List<decimal> m_parametry = new List<decimal>();
        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "Wys", "Szer", "X", "Y" }.AsReadOnly(); } }
        public override ReadOnlyCollection<int> GetDefaultVal { get { return new List<int> { 10, 20, 0, 0 }.AsReadOnly(); } }

        override public bool SetParameters(List<decimal> parametry)
        {
            if ((base.SetParameters(parametry) == false) || (parametry[0] <= 0) || (parametry[1]) <= 0)
            {
                return false;
            }
            m_parametry = parametry;
            return true;
        }
    }

    public class Kwadrat : IFigury
    {
        private List<decimal> m_parametry = new List<decimal>();
        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "Bok", "X", "Y" }.AsReadOnly(); } }
        public override ReadOnlyCollection<int> GetDefaultVal { get { return new List<int> { 10, 0, 0 }.AsReadOnly(); } }

        public new bool SetParameters(List<decimal> parametry)
        {
            if ((base.SetParameters(parametry) == false) || (parametry[0] <= 0))
            {
                return false;
            }
            m_parametry = parametry;
            return true;
        }
    }

    public class Ko�o : IFigury
    {
        private List<decimal> m_parametry = new List<decimal>();
        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "R", "X", "Y" }.AsReadOnly(); } }
        public override ReadOnlyCollection<int> GetDefaultVal { get { return new List<int> { 20, 0, 0 }.AsReadOnly(); } }

        public new bool SetParameters(List<decimal> parametry)
        {
            if ((base.SetParameters(parametry) == false) || (parametry[0] <= 0))
            {
                return false;
            }
            m_parametry = parametry;
            return true;
        }
    }
}
