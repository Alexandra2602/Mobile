using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobile.Models;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CamPage : ContentPage
    {
        RoomList rl;
        public CamPage(RoomList rlist)
        {
            InitializeComponent();
            rl = rlist;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var cam = (Cam)BindingContext;
            await App.Database.SaveCamAsync(cam);
            listView.ItemsSource = await App.Database.GetCamsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var cam = (Cam)BindingContext;
            await App.Database.DeleteCamAsync(cam);
            listView.ItemsSource = await App.Database.GetCamsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetCamsAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Cam c;
            if (e.SelectedItem != null)
            {
                c = e.SelectedItem as Cam;
                var lc = new ListCam()
                {
                    RoomListID = rl.ID,
                    CamID = c.ID
                };
                await App.Database.SaveListCamAsync(lc);
                c.ListCams = new List<ListCam> { lc };
                await Navigation.PopAsync();
            }
        }
    }
}