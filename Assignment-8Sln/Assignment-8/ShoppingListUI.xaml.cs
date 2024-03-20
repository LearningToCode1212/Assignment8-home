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
        ItemsList.ItemsSource = GetAllItems();
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
        //Items = new ObservableCollection<ShoppingItems>(_database.GetAllItems());
    }
    private void Button1(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        var selectedItem = button.CommandParameter;

        if (selectedItem is ShoppingCart item)
        {
            // Access item properties here
            string name = item.NameOfItem;
            int quantityAmount = item.ItemAmount - 1;
            decimal total = item.CartTotal;
            string img = item.ItemImageCart;

            InsertToDatabase(name, total, quantityAmount, img);
            // Now you can use the values as needed
            DisplayAlert("Cart", "Item Added To Cart", "Done");
        }
    }
    public void InsertToDatabase(string name, decimal amount, int quantity, string images)
    {
        _database.InsertToCart(name, amount, quantity, images);
    }
    private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            // Cast the selected item to your data model type
            var selectedItem = e.SelectedItem as ShoppingCart; // Replace YourDataType with your actual data type

            // Extract data from the selected item
            string itemName = selectedItem.NameOfItem;
            decimal itemPrice = selectedItem.CartTotal;
            int itemQuantity = selectedItem.ItemAmount;
            string img = selectedItem.ItemImageCart;
            InsertToDatabase(itemName, itemPrice, itemQuantity, img);
            // Extract other relevant data as needed
            //_database.InsertToCart(itemName, itemPrice, itemQuantity);
        }
    }
    private List<ShoppingCart> GetAllItems()
    {
        return new List<ShoppingCart>
        {
            new ShoppingCart
            {
                NameOfItem = "Nike Air Max",
                CartTotal = new decimal(30),
                ItemAmount = 10,
                ItemImageCart = "shoe.png",
            },

            new ShoppingCart
            {
                NameOfItem = "New Balanace 550",
                CartTotal = new decimal(60),
                ItemAmount = 90,
                ItemImageCart = "Resoures/Images/new_balanace.png",
            },

            new ShoppingCart
            {
                NameOfItem = "Nike Air Max 90",
                CartTotal = new decimal(90),
                ItemAmount = 18,
                ItemImageCart = "Resources/Images/air_maxs.png",
            },
        };
    }
}