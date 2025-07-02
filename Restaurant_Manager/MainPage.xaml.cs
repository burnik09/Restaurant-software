using System.Collections.ObjectModel;

namespace Restaurant_Manager
{

    // Ova e log in page (landing page, od tuka pochnuva)!

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void UserLogIn(object sender, EventArgs e)
        {
            String username = UsernameField.Text;
            String password = PasswordField.Text;

            if (username == null || password == null)
            {
                return;
            }

            bool exists = false;
            User found = null;

            foreach (User u in AppData.allServers)
            {
                if (u.checkUser(username, password))
                {
                    found = u;
                    exists = true;
                    break;
                }
            }

            if (exists == true)
            {
                if(found.IsAdmin == true)
                    await Shell.Current.GoToAsync("/RestaurantView?isAdmin=true");
                else
                    await Shell.Current.GoToAsync("/RestaurantView?isAdmin=false");
            }
            else
            {
                ErrorField.TextColor = Colors.Red;
                ErrorField.Text = "That server doesn't exist";
            }

        }
    }

}
