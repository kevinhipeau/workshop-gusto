namespace Diabetic.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new Diabetic.App());
        }
    }
}