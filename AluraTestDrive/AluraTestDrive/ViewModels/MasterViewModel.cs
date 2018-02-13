using AluraTestDrive.Media;
using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AluraTestDrive.ViewModels
{
     public class MasterViewModel : BaseViewModel
    {
        //Propriedades
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

        private bool editando = false;
        public bool Editando
        {
            get { return editando; }
            private set {
                editando = value;
                OnPropertyChanged(nameof(Editando));
            }
        }

        private ImageSource imageSource = "perfil.png";

        public ImageSource FotoPerfil
        {
            get { return imageSource; }
            private set {
                imageSource = value;
                OnPropertyChanged();
            }
        }


        //Commands

        public ICommand EditarPerfilCommand { get; private set; }
        public void EditarPerfil()
        {
            MessagingCenter.Send<Usuario>(usuario, "NavegarEditarPerfil");
        }

        public ICommand SalvarCommand { get; private set; }
        public void Salvar()
        {
            Editando = false;
            MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");
        }
        public bool SalvarCondicao()
        {
            return true;
        }

        public ICommand EditarCommand { get; private set; }
        public void Editar()
        {
            this.Editando = true;
        }

        public ICommand TirarFotoCommand { get; private set; }
        public void TirarFoto()
        {
            DependencyService.Get<ICamera>().TirarFoto();
        }

        //Messagens

        private void Messagens()
        {
            MessagingCenter.Subscribe<byte[]>(this, "FotoTirada", (bytes) => {
                FotoPerfil = ImageSource.FromStream(()=> new MemoryStream(bytes)); // transforma o array de bytes em imagesource
            });
        }


        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            EditarPerfilCommand = new Command(EditarPerfil);
            SalvarCommand = new Command(Salvar,SalvarCondicao);
            EditarCommand = new Command(Editar);
            TirarFotoCommand = new Command(TirarFoto);

            Messagens();
        }

    }
}
