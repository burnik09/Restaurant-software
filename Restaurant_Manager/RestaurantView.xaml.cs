using Microsoft.Maui.Layouts;
using System.Threading.Tasks;
//using static Android.Icu.Text.Transliterator;

namespace Restaurant_Manager;

[QueryProperty(nameof(isAdmin), "isAdmin")]
public partial class RestaurantView : ContentPage
{
    private int idCount { get; set; } = 0;
    public string isAdmin { get; set; }
    public bool IsAdminFlag => bool.TryParse(isAdmin, out var result) && result;
    public List<Rect> tableRects = new List<Rect>();

    public RestaurantView()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (!IsAdminFlag)
        {
            DodatniOpcii.IsVisible = false;
        }
        else
        {
            DodatniOpcii.IsVisible = true;
        }

    }

    private async void LogUserOut(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("///MainPage");
	}

    const double TableWidth = 120;
    const double TableHeight = 120;
    void dodadiMasa(Object sender, TappedEventArgs e)
    {
        idCount++;

        if (!IsAdminFlag)
        {
            return;
        }

        var container = (AbsoluteLayout)sender;
        Point? pos = e.GetPosition(container);
        if (pos != null)
        {
            Rect newRect = new Rect(pos.Value.X - 60, pos.Value.Y - 60, TableWidth, TableHeight);
            if (tableRects.Count != 0)
            {
                bool overlaps = tableRects.Any(existingRect => existingRect.IntersectsWith(newRect));

                if (overlaps)
                {
                    DisplayAlert("Error", "Cannot place table here—it overlaps another table.", "OK");
                    return;
                }
            }

            String ajDi = $"{idCount}";
            var imageButton = new ImageButton
            {
                ClassId = ajDi,
                Source = "greenemptytable.png",
                WidthRequest = TableWidth,
                HeightRequest = TableHeight
            };

            imageButton.Clicked += (s, args) => {

            };

            
            container.Children.Add(imageButton);
            AbsoluteLayout.SetLayoutBounds(imageButton, newRect);
            AbsoluteLayout.SetLayoutFlags(imageButton, AbsoluteLayoutFlags.None);

            tableRects.Add(newRect);

        }

        

    }


}