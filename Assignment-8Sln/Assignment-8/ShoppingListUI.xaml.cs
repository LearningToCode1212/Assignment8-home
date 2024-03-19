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

            InsertToDatabase(name, total, quantityAmount);
            // Now you can use the values as needed
            DisplayAlert("Cart", "Item Added To Cart", "Done");
        }
    }
    public void InsertToDatabase(string name, decimal amount, int quantity)
    {
        _database.InsertToCart(name, amount, quantity);
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
            InsertToDatabase(itemName, itemPrice, itemQuantity);
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
                NameOfItem = "John Doe",
                CartTotal = new decimal(30),
                ItemAmount = 10,
                ItemImageCart = "Air-Max.jpg",
            },

            new ShoppingCart
            {
                NameOfItem = "Paul Doe",
                CartTotal = new decimal(60),
                ItemAmount = 90,
                ItemImageCart = "Air-Max.jpg",
            },

            new ShoppingCart
            {
                NameOfItem = "David Doe",
                CartTotal = new decimal(90),
                ItemAmount = 18,
                ItemImageCart = "Air-Force.jfif",
            },
        };
    }
}