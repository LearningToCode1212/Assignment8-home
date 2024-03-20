using Assignment_8.Models;
using Assignment_8.Services;

namespace Assignment_8;

public partial class ProfilePage : ContentPage
{
    private ProfileDatabase _database;

    private UserProfile _currentUser;
    public UserProfile CurrentUser
    {
        get { return _currentUser; }
        set
        {
            _currentUser = value;
            OnPropertyChanged();
        }
    }
    public ProfilePage()
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
    public void LoadData() // Loading the data
    {
        UserProfile profile = _database.GetUserByID(1); // Assigning the user to a userid that was saved
        CurrentUser = profile; // Assigning the user to the CurrentUser (will display on screen)
    }                

    private void SaveProfile(object sender, EventArgs e)
    {
        //DisplayAlert("test", "button click works", "ok");
        _database.UpdateUser(CurrentUser); // Saving the data to the database but updating with new information
        nameEntry.Text = "";
        surnameEntry.Text = "";
        emailEntry.Text = "";
        bioEntry.Text = "";
    }

    private void LoadProfile(object sender, EventArgs e) // Loading data on button clcik
    {
        //DisplayAlert("test", "is working", "ok");
        LoadData();
    }
}