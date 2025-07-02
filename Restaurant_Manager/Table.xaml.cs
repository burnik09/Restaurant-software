using System.Collections.ObjectModel;

namespace Restaurant_Manager;

[QueryProperty(nameof(isAdmin), "isAdmin")]
public partial class Table : ContentPage
{
    
    
        ObservableCollection<String> drinks = new ObservableCollection<String> { "Espresso", "Machiatto", "Instant" };
        
        public string isAdmin { get; set; }

        public bool IsAdminFlag => bool.TryParse(isAdmin, out var result) && result;

        public Table()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ListaDrop.ItemsSource = drinks;

            if (!IsAdminFlag)
            {
                btnDrinkToAdd.IsVisible = false;
                DrinkToAdd.IsVisible = false;
            }
            else
            {
                btnDrinkToAdd.IsVisible = true;
                DrinkToAdd.IsVisible = true;
            }

        }

        private void AddDrink(object sender, EventArgs e)
        {
            String drink = DrinkToAdd.Text;
            if (drink != null && drink != " ")
            {
                drinks.Add(drink);
                ListaDrop.ItemsSource = drinks;
            }

            DrinkToAdd.Text = "";
        }
        private async void LogUserOut(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }

}