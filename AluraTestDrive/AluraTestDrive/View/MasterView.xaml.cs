using AluraTestDrive.Models;
using AluraTestDrive.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AluraTestDrive.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterView : TabbedPage
	{
        public MasterViewModel ViewModel { get; set; }

        public MasterView(Usuario usuario)
		{
			InitializeComponent ();
            this.ViewModel = new MasterViewModel(usuario);
            this.BindingContext = this.ViewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarMensagens();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Usuario>(this, "NavegarEditarPerfil", (usuario) =>
            {
                //o Tabet Page tem a propriedade pagina atual(CurrentPage) - e tambem guarda as paginas filhas com indices começando em 0, podendo ser acessadas(thi.Children[indice])
                this.CurrentPage = this.Children[1];
            });

            MessagingCenter.Subscribe<Usuario>(this, "SucessoSalvarUsuario", (usuario) =>
            {
                this.CurrentPage = this.Children[0];
            });
        }

        private void CancelarMensagens()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "NavegarEditarPerfil");
            MessagingCenter.Unsubscribe<Usuario>(this, "SucessoSalvarUsuario");
        }
    }
}