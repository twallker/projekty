namespace Figury
{
    public partial class Form1 : Form
    {
        private List<IFigury> dostepneFigury = new();
        public Form1()
        {
            InitializeComponent();
            dostepneFigury.Add(new Prostok�t());
            dostepneFigury.Add(new Kwadrat());
            dostepneFigury.Add(new Ko�o());
            foreach (IFigury f in dostepneFigury)
            {
                zasobnikFigur.Items.Add(f.Nazwa);
            }
        }
    }
    interface IFigury
    {
        string Nazwa { get; }
    }

    public class Prostok�t : IFigury
    {
        private string nazwa = "Prostok�t";
        public string Nazwa { get { return nazwa; } }
    }

    public class Kwadrat : IFigury
    {
        private string nazwa = "Kwadrat";
        public string Nazwa { get { return nazwa; } }
    }

    public class Ko�o : IFigury
    {
        private string nazwa = "Ko�o";
        public string Nazwa { get { return nazwa; } }
    }
}
