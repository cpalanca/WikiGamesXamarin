using System;
using System.Collections.Generic;
using WikiGames.Layouts.AboutUS;
using WikiGames.Layouts.Home;
using WikiGames.Layouts.Configuration;
using WikiGames.Layouts.Profile_Settings;
using WikiGames.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiGames.Layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            menuList = new List<MasterPageItem>();


            //Fot Android / IOS icons
            var page1 = new MasterPageItem() { id = 1, Title = "Home", Icon = "Home.png" };
            var page2 = new MasterPageItem() { id = 2, Title = "About US", Icon = "About.png" };
            var page3 = new MasterPageItem() { id = 3, Title = "Configuration", Icon = "Configuration.png" };
            var page4 = new MasterPageItem() { id = 4, Title = "Profile", Icon = "ProfileSetting.png" };
            var page5 = new MasterPageItem() { id = 5, Title = "Configuration", Icon = "Configuration.png" };
            var page6 = new MasterPageItem() { id = 6, Title = "Profile Settings", Icon = "ProfileSetting.png" };

            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);



            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));

        }

        async private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {


            var myselecteditem = e.Item as MasterPageItem;

            switch (myselecteditem.id)
            {

                case 1:
                    await Navigation.PushAsync(new HomePage());


                    break;
                case 2:
                    await Navigation.PushAsync(new AboutUSPage());

                    break;
                case 3:
                    await Navigation.PushAsync(new ConfigurationPage());

                    break;
                case 4:
                    await Navigation.PushAsync(new ProfileSettingsPage());

                    break;
                case 5:
                    await Navigation.PushAsync(new ProfileSettingsPage());

                    break;
                case 6:
                    await Navigation.PushAsync(new ProfileSettingsPage());

                    break;


            }
            ((ListView)sender).SelectedItem = null;
            IsPresented = false;


        }
    }





}
