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

        public string DataNascimento
        {
            get { return this.usuario.dataNascimento; }
            set { this.usuario.dataNascimento = value; }
        }

        public string Telefone
        {
            get { return this.usuario.telefone; }
            set { this.usuario.telefone = value; }
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

        public ICommand SalvarPerfilCommand { get; private set; }
        public void SalvarPerfil()
        {

        }

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            EditarPerfilCommand = new Command(EditarPerfil);
            SalvarPerfilCommand = new ICommand(SalvarPerfil);
        }

    }
}
