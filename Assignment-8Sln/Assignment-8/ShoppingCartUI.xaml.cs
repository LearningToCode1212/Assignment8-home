using Assignment_8.Models;
using Assignment_8.Services;
using System.Collections.ObjectModel;

namespace Assignment_8;

public partial class ShoppingCartUI : ContentPage
{
    private ProfileDatabase _database;

    private ObservableCollection<ShoppingCart> _cartitems;
    public ObservableCollection<ShoppingCart> CartItems
    {
        get { return _cartitems; }
        set
        {
            _cartitems = value;
            OnPropertyChanged();
        }
    }
    public ShoppingCartUI()
	{
		InitializeComponent();
        _database = new ProfileDatabase();
        BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadData();
    }
    public void LoadData()
    {
        // Returns a list from the database with all data and displays in one the screen
        CartItems = new ObservableCollection<ShoppingCart>(_database.GetAllCartItems());
    }

    // Remove Button
    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        var selectedItem = button.CommandParameter as ShoppingCart;

        if (selectedItem != null)
        {
            CartItems.Remove(selectedItem);
            _database.RemoveFromCart(selectedItem);
        }
    }
}