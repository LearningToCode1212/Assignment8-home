using Assignment_8.Models;
using Assignment_8.Services;
using System.Collections.ObjectModel;

namespace Assignment_8;

public partial class ShoppingListUI : ContentPage
{
    private ProfileDatabase _database;

    private ObservableCollection<ShoppingItems> _items;
    public ObservableCollection<ShoppingItems> Items
    {
        get { return _items; }
        set
        {
            _items = value;
            OnPropertyChanged();
        }
    }
    public ShoppingListUI()
	{
		InitializeComponent();
        _database = new ProfileDatabase();
        BindingContext = this;
        //ItemsList.ItemsSource = GetAllItems();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadData();
    }
    public void LoadData()
    {
        //ShoppingItems items = _database.GetItemByID(1);
        //CurrentItem = items;
        Items = new ObservableCollection<ShoppingItems>(_database.GetAllItems());
    }
    private void Button1(object sender, EventArgs e)
    {
        // takes the current item that is clicked and adds it into the database
        Button button = (Button)sender;
        var selectedItem = button.CommandParameter;
        //ShoppingCart
        if (selectedItem is ShoppingItems item)
        {
            string name = item.ItemName;
            int quantityAmount = item.ItemQuantity - 1;
            decimal total = item.ItemPrice;
            string img = item.ItemImage;
            

            InsertToDatabase(name, total, quantityAmount, img);
            DisplayAlert("Cart", "Item Added To Cart", "Done");
        }
    }


    public void InsertToDatabase(string name, decimal amount, int quantity, string images)
    {
        _database.InsertToCart(name, amount, quantity, images);
    }

    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Does the exact some thing the button does
        if (e.SelectedItem != null)
        {
            var selectedItem = e.SelectedItem as ShoppingCart;

            string itemName = selectedItem.NameOfItem;
            decimal itemPrice = selectedItem.CartTotal;
            int itemQuantity = selectedItem.ItemAmount;
            string img = selectedItem.ItemImageCart;

            InsertToDatabase(itemName, itemPrice, itemQuantity, img);
        }
    }

    // List data that will be displayed in the list UI
    /*private List<ShoppingCart> GetAllItems()
    {
        return new List<ShoppingCart>
        {
            new ShoppingCart
            {
                NameOfItem = "Nike Air Max",
                CartTotal = new decimal(3000),
                ItemAmount = 10,
                ItemImageCart = "shoe.png",
            },

            new ShoppingCart
            {
                NameOfItem = "New Balanace 550",
                CartTotal = new decimal(6000),
                ItemAmount = 90,
                ItemImageCart = "Resoures/Images/new_balanace.png",
            },

            new ShoppingCart
            {
                NameOfItem = "Nike Air Max 90",
                CartTotal = new decimal(9000),
                ItemAmount = 18,
                ItemImageCart = "Resources/Images/air_maxs.png",
            },
        };
    }*/
}