namespace Figury
{
    public partial class Form1 : Form
    {
        private List<IFigury> dostepneFigury = [new Prostok�t(), new Kwadrat(), new Ko�o()];
        private List<System.Windows.Forms.Label> dost�pneParametry;
        public Form1()
        {
            InitializeComponent();
            dost�pneParametry = [p0,p1,p2,p3,p4,p5,p6];
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
                    if (lista.Count > dost�pneParametry.Count)
                    {
                        throw new InvalidOperationException("brak miejssca na parametry");
                    }
                    for (int i = 0; i< dost�pneParametry.Count; i++)
                    {
                        if (i< lista.Count)
                        {
                            dost�pneParametry[i].Text = lista[i];
                            dost�pneParametry[i].Visible = true;
                        }
                        else
                        {
                            dost�pneParametry[i].Text = "";
                            dost�pneParametry[i].Visible = false;
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

    public class Prostok�t : IFigury
    {
        private string nazwa = "Prostok�t";
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

    public class Ko�o : IFigury
    {
        private string nazwa = "Ko�o";
        private List<string> paramNames = new List<string> { "R", "X", "Y" };
        public string Nazwa { get { return nazwa; } }
        public List<string> GetParamNames { get { return paramNames; } }
    }
}
