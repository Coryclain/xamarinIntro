using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MyLogin.Models;
using MyLogin.Services;
using MyLogin.View.Presente;
using Xamarin.Forms;

namespace MyLogin.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private INavigation Navigation { get; set; }
        private Page _page;

        public string _usuario;
        public string usuario
        {
            get { return _usuario; }
            set { _usuario = value; RaisePropertyChanged("usuario"); }
        }

        public string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged("password"); }
        }

        public LoginViewModel(INavigation navigation, Page page)
        {
            this.Navigation = navigation;
            _page = page;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Command _loginCommand;
        public Command loginCommand
        {
            get
            {
                return (_loginCommand ?? (_loginCommand = new Command(
                    async () => await login())));
            }
        }

        public async Task login()
        {
            Debug.WriteLine("Usuario " + usuario);
            Debug.WriteLine("Password " + password);

            Login l = new Login
            {
                username = this.usuario,
                password = this.password
            };

            var loginService = new LoginService();
            var resultado = await loginService.userLogin(l);

            if(resultado.success)
            {
                Debug.WriteLine(resultado.loginSuccess.access_token);
                Token.access_token = resultado.loginSuccess.access_token;
                var page = new Presente();
                NavigationPage.SetHasBackButton(page, false);
                await Navigation.PushAsync(page);
                //await Application.Current.MainPage.Navigation.PushAsync(page);
            }

        }
    }
}
