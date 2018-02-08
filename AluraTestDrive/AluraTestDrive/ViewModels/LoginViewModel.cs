using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluraTestDrive.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set {
                usuario = value;
                OnPropertyChanged();
                ((Command)LogarCommand).ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set {
                senha = value;
                OnPropertyChanged();
                ((Command)LogarCommand).ChangeCanExecute();
            }
        }

        public ICommand LogarCommand { get; set; }
        public async void Logar()
        {
            var loginService = new LoginService();
            await loginService.LogarAsync(new Login(usuario, senha));
        }
        public bool LogarCondicao()
        {
            return
                !string.IsNullOrEmpty(usuario) &&
                !string.IsNullOrEmpty(senha);
        }

        public LoginViewModel()
        {
            LogarCommand = new Command(Logar,LogarCondicao);
        }

    }
}
