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
}