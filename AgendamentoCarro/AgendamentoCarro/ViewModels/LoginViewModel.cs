using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendamentoCarro
{
    public class LoginViewModel : BaseViewModel
    {
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                OnPropertyChanged();
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value; OnPropertyChanged();
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(async () =>
            {
                var loginService = new LoginService();
                await loginService.FazerLogin(new Login(usuario, senha));
            },
            () =>
            {
                return !string.IsNullOrEmpty(usuario)
                        && !string.IsNullOrEmpty(senha);
            });
        }
    }
}