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
            MessagingCenter.Subscribe<Usuario>(this, "NavegarEditarPerfil", (usuario) => {
                //o Tabet Page tem a propriedade pagina atual(CurrentPage) - e tambem guarda as paginas filhas com indices começando em 0, podendo ser acessadas(thi.Children[indice])
                this.CurrentPage = this.Children[1];
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Usuario>(this, "NavegarEditarPerfil");
        }
    }
}