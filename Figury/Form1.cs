using System.Collections.ObjectModel;

namespace Figury
{
    public partial class Form1 : Form
    {
        private List<IFigury> dostepneFigury = [new Prostok¹t(), new Kwadrat(), new Ko³o()];
        private List<System.Windows.Forms.NumericUpDown> dostêpneWartosci;
        private List<System.Windows.Forms.Label> dostêpneParametry;
        private List<IFigury> figuries;
        public Form1()
        {
            InitializeComponent();
            IFigury.licznik = 0;
            dostêpneParametry = [p0, p1, p2, p3, p4, p5, p6];
            dostêpneWartosci = [v0, v1, v2, v3, v4, v5, v6];
            if (dostêpneParametry.Count != dostêpneWartosci.Count)
            {
                throw new InvalidOperationException("Musi byæ równa iloœæ opisów i wartoœci");
            }
            foreach (IFigury f in dostepneFigury)
            {
                zasobnikFigur.Items.Add(f.nazwa);
            }
            zasobnikFigur.SelectedIndex = 0;
            figuries = new List<IFigury>();
        }

        private void zasobnikFigur_SelectedIndexChanged(object sender, EventArgs e)
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
                        throw new InvalidOperationException("Iloœæ parametrów i wartoœci defaultowych sie nie zgadza");
                    }
                    if (lista.Count > dostêpneParametry.Count)
                    {
                        throw new InvalidOperationException("Brak miejsca na parametry");
                    }
                    for (int i = 0; i < dostêpneParametry.Count; i++)
                    {
                        if (i < lista.Count)
                        {
                            dostêpneParametry[i].Text = lista[i];
                            dostêpneParametry[i].Visible = true;
                            dostêpneWartosci[i].Visible = true;
                            dostêpneWartosci[i].Value = defVal[i];
                        }
                        else
                        {
                            dostêpneParametry[i].Text = "";
                            dostêpneParametry[i].Visible = false;
                            dostêpneWartosci[i].Visible = false;
                        }
                    }
                }
            }
            if (!found)
            {
                for (int i = 0; i < dostêpneParametry.Count; i++)
                {
                    dostêpneParametry[i].Visible = false;
                    dostêpneWartosci[i].Visible = false;
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
                    userFig.Items.Add(obj.nazwa + "_" + obj.id);
                    List<decimal> param = new List<decimal>();
                    foreach(System.Windows.Forms.NumericUpDown l in dostêpneWartosci)
                    {
                        if (l.Visible) param.Add(l.Value);
                    }
                    obj.SetParameters(param);
                }
            }
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

        public abstract bool SetParameters(List<decimal> parametry);
    }

    public class Prostok¹t : IFigury
    {
        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "Wys", "Szer", "X", "Y" }.AsReadOnly(); } }
        public override ReadOnlyCollection<int> GetDefaultVal { get { return new List<int> { 10, 20, 0, 0 }.AsReadOnly(); } }

        public override bool SetParameters(List<decimal> parametry)
        {
            throw new NotImplementedException();
        }
    }

    public class Kwadrat : IFigury
    {
        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "Bok", "X", "Y" }.AsReadOnly(); } }
        public override ReadOnlyCollection<int> GetDefaultVal { get { return new List<int> { 10, 0, 0 }.AsReadOnly(); } }

        public override bool SetParameters(List<decimal> parametry)
        {
            throw new NotImplementedException();
        }
    }

    public class Ko³o : IFigury
    {
        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "R", "X", "Y" }.AsReadOnly(); } }
        public override ReadOnlyCollection<int> GetDefaultVal { get { return new List<int> { 20, 0, 0 }.AsReadOnly(); } }

        public override bool SetParameters(List<decimal> parametry)
        {
            throw new NotImplementedException();
        }
    }
}
