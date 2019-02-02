using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLogin.ViewModels;
using Xamarin.Forms;

namespace MyLogin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel(Navigation, this);
        }

        /*async void OnButtonClicked(object sender, EventArgs args)
        {
            string user = usuario.Text;
            string pass = password.Text;

            Debug.WriteLine("Usuario: "+ user);
            Debug.WriteLine("Passwoord: "+ pass);
        }*/
    }
}
