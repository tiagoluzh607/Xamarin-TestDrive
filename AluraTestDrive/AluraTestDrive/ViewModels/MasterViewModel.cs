using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluraTestDrive.ViewModels
{
     public class MasterViewModel
    {
        private readonly Usuario usuario;

        public string Nome
        {
            get { return usuario.nome; }
            set { usuario.nome = value; }
        }

        public string Email
        {
            get { return usuario.email; }
            set { usuario.email = value; }
        }

        //Commands

        public ICommand EditarPerfilCommand { get; private set; }
        public void EditarPerfil()
        {
            MessagingCenter.Send<Usuario>(usuario, "NavegarEditarPerfil");
        }

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            EditarPerfilCommand = new Command(EditarPerfil);
        }

    }
}
