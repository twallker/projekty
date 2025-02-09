namespace Figury
{
    public partial class Form1 : Form
    {
        private List<IFigury> dostepneFigury = [new Prostok¹t(), new Kwadrat(), new Ko³o()];
        private List<System.Windows.Forms.Label> dostêpneParametry;
        public Form1()
        {
            InitializeComponent();
            dostêpneParametry = [p0,p1,p2,p3,p4,p5,p6];
            foreach (IFigury f in dostepneFigury)
            {
                zasobnikFigur.Items.Add(f.Nazwa);
            }
        }

        private void zasobnikFigur_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(IFigury f in dostepneFigury)
            {
                if (f.Nazwa == zasobnikFigur.Text)
                {
                    var lista = f.GetParamNames;
                    if (lista.Count > dostêpneParametry.Count)
                    {
                        throw new InvalidOperationException("brak miejssca na parametry");
                    }
                    for (int i = 0; i< dostêpneParametry.Count; i++)
                    {
                        if (i< lista.Count)
                        {
                            dostêpneParametry[i].Text = lista[i];
                            dostêpneParametry[i].Visible = true;
                        }
                        else
                        {
                            dostêpneParametry[i].Text = "";
                            dostêpneParametry[i].Visible = false;
                        }
                    }
                }
            }
        }
    }
    interface IFigury
    {
        string Nazwa { get; }
        List<string> GetParamNames {  get; }
    }

    public class Prostok¹t : IFigury
    {
        private string nazwa = "Prostok¹t";
        private List<string> paramNames = new List<string> { "Wys", "Szer", "X", "Y" };
        public string Nazwa { get { return nazwa; } }
        public List<string> GetParamNames { get { return paramNames; } }
    }

    public class Kwadrat : IFigury
    {
        private string nazwa = "Kwadrat";
        private List<string> paramNames = new List<string> { "Bok", "X", "Y" };
        public string Nazwa { get { return nazwa; } }
        public List<string> GetParamNames { get { return paramNames; } }
    }

    public class Ko³o : IFigury
    {
        private string nazwa = "Ko³o";
        private List<string> paramNames = new List<string> { "R", "X", "Y" };
        public string Nazwa { get { return nazwa; } }
        public List<string> GetParamNames { get { return paramNames; } }
    }
}
