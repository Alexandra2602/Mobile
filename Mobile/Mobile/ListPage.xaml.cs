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
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {

            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var rlist = (RoomList)BindingContext;
            rlist.Date = DateTime.UtcNow;
            await App.Database.SaveRoomListAsync(rlist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var rlist = (RoomList)BindingContext;
            await App.Database.DeleteRoomListAsync(rlist);
            await Navigation.PopAsync();
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CamPage((RoomList)
           this.BindingContext)
            {
                BindingContext = new Cam()
            });


        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var rooml = (RoomList)BindingContext;

            listView.ItemsSource = await App.Database.GetListCamsAsync(rooml.ID);
        }
    }


}