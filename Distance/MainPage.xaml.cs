namespace Distance
{
    public partial class MainPage : ContentPage
    {
        string? distance;

        public MainPage()
        {
            InitializeComponent();
        }

        private void calculateButton_Clicked(object sender, EventArgs e)
        {
            string
                P1 = coordinatePoint1.Text,
                P2 = coordinatePoint2.Text;
            distance = DistanceCalculator.Distance(P1, P2).ToString();
            if (string.IsNullOrEmpty(distance))
            {
                labelResult.Text = "Расстояние";
            }
            else
            {
                labelResult.Text = "Расстояние: " + distance + " км";
            }
        }
    }

}
