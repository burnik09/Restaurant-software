namespace Restaurant_Manager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Table", typeof(Table));
            Routing.RegisterRoute("RestaurantView", typeof(RestaurantView));
        }
    }
}
//< ShellContent
//        Title = "Home"
//        ContentTemplate = "{DataTemplate local:MainPage}"
//        Route = "MainPage" />