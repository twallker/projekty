namespace Figury
{
    public partial class Form1 : Form
    {
        private List<IFigury> dostepneFigury = [new Prostokąt(), new Kwadrat(), new Koło()];
        private List<System.Windows.Forms.Label> dostępneParametry;
        public Form1()
        {
            InitializeComponent();
            dostępneParametry = [p0,p1,p2,p3,p4,p5,p6];
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
                    if (lista.Count > dostępneParametry.Count)
                    {
                        throw new InvalidOperationException("brak miejssca na parametry");
                    }
                    for (int i = 0; i< dostępneParametry.Count; i++)
                    {
                        if (i< lista.Count)
                        {
                            dostępneParametry[i].Text = lista[i];
                            dostępneParametry[i].Visible = true;
                        }
                        else
                        {
                            dostępneParametry[i].Text = "";
                            dostępneParametry[i].Visible = false;
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

    public class Prostokąt : IFigury
    {
        private string nazwa = "Prostokąt";
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

    public class Koło : IFigury
    {
        private string nazwa = "Koło";
        private List<string> paramNames = new List<string> { "R", "X", "Y" };
        public string Nazwa { get { return nazwa; } }
        public List<string> GetParamNames { get { return paramNames; } }
    }
}
