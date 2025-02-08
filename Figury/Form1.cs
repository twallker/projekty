namespace Figury
{
    public partial class Form1 : Form
    {
        private List<IFigury> dostepneFigury = new();
        public Form1()
        {
            InitializeComponent();
            dostepneFigury.Add(new Prostok¹t());
            dostepneFigury.Add(new Kwadrat());
            dostepneFigury.Add(new Ko³o());
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

    public class Prostok¹t : IFigury
    {
        private string nazwa = "Prostok¹t";
        public string Nazwa { get { return nazwa; } }
    }

    public class Kwadrat : IFigury
    {
        private string nazwa = "Kwadrat";
        public string Nazwa { get { return nazwa; } }
    }

    public class Ko³o : IFigury
    {
        private string nazwa = "Ko³o";
        public string Nazwa { get { return nazwa; } }
    }
}
