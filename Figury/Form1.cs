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
            IFigury.licznik = 0;
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
                        throw new InvalidOperationException("Ilość parametrów i wartości defaultowych sie nie zgadza");
                    }
                    if (lista.Count > dostępneParametry.Count)
                    {
                        throw new InvalidOperationException("Brak miejsca na parametry");
                    }
                    for (int i = 0; i < dostępneParametry.Count; i++)
                    {
                        if (i < lista.Count)
                        {
                            dostępneParametry[i].Text = lista[i];
                            dostępneParametry[i].Visible = true;
                            dostępneWartosci[i].Visible = true;
                            dostępneWartosci[i].Value = defVal[i];
                        }
                        else
                        {
                            dostępneParametry[i].Text = "";
                            dostępneParametry[i].Visible = false;
                            dostępneWartosci[i].Visible = false;
                        }
                    }
                }
            }
            if (!found)
            {
                for (int i = 0; i < dostępneParametry.Count; i++)
                {
                    dostępneParametry[i].Visible = false;
                    dostępneWartosci[i].Visible = false;
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
                    foreach (System.Windows.Forms.NumericUpDown l in dostępneWartosci)
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

    public class Prostokąt : IFigury
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

    public class Koło : IFigury
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
