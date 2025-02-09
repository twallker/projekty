using System.Collections.ObjectModel;

namespace Figury
{
    public partial class Form1 : Form
    {
        private List<IFigury> dostepneFigury = [new Prostokąt(), new Kwadrat(), new Koło()];
        private List<System.Windows.Forms.NumericUpDown> dostępneWartosci;
        private List<System.Windows.Forms.Label> dostępneParametry;
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
                            dostępneWartosci[i].Value = 0;
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
                    userFig.Items.Add(obj.nazwa + obj.id);
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
    }

    public class Prostokąt : IFigury
    {
        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "Wys", "Szer", "X", "Y" }.AsReadOnly(); } }
    }

    public class Kwadrat : IFigury
    {
        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "Bok", "X", "Y" }.AsReadOnly(); } }
    }

    public class Koło : IFigury
    {
        public override ReadOnlyCollection<string> GetParamNames { get { return new List<string> { "R", "X", "Y" }.AsReadOnly(); } }
    }
}
