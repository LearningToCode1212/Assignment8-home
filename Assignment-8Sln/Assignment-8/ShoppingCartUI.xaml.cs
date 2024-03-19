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
        CartItems = new ObservableCollection<ShoppingCart>(_database.GetAllCartItems());
    }
}