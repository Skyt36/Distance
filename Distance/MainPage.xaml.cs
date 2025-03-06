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

        private void ContentPage_Unloaded(object sender, EventArgs e)
        {
            Preferences.Default.Set("entry1", coordinatePoint1.Text);
            Preferences.Default.Set("entry2", coordinatePoint2.Text);
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            if (Preferences.ContainsKey("entry1"))
                coordinatePoint1.Text = Preferences.Default.Get("entry1", "");
            if (Preferences.ContainsKey("entry2"))
                coordinatePoint2.Text = Preferences.Default.Get("entry2", "");
        }

        private async void getCurCoordinate1_Clicked(object sender, EventArgs e)
        {
            string location = await GetLocation();
            if (!string.IsNullOrEmpty(location))
                coordinatePoint1.Text = location;
        }

        private async void getCurCoordinate2_Clicked(object sender, EventArgs e)
        {
            string location = await GetLocation();
            if (!string.IsNullOrEmpty(location))
                coordinatePoint2.Text = location;
        }
        private async Task<string> GetLocation()
        {
            Location location = null;
            try
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.High,
                    Timeout = TimeSpan.FromSeconds(10)
                });
            }
            catch { }

            if (location == null)
                return null;
            return $"{location.Latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}, {location.Longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
        }
    }

}
