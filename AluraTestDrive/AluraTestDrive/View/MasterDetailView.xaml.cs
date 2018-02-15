using AluraTestDrive.Models;
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
	public partial class MasterDetailView : MasterDetailPage
	{
        private readonly Usuario usuario;

        public MasterDetailView (Usuario usuario)
		{
			InitializeComponent ();
            this.usuario = usuario;

            this.Master = new MasterView(usuario); // Pagina Escondida (Obs: sem o Title nesta pagina ela nao carrega)
            this.Detail = new NavigationPage(new ListagemView()); // Pagina Exibida 
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
            MessagingCenter.Subscribe<Usuario>(this, "MeusAgendamentos", (usuario) =>
            {

                this.Detail = new NavigationPage(new AgendamentosUsuarioView()); //troca a navegacao
                this.IsPresented = false; // fecha o menu lateral
            });

            MessagingCenter.Subscribe<Usuario>(this, "NovoAgendamento", (usuario) =>
            {

                this.Detail = new NavigationPage(new ListagemView()); //troca a Navegação
                this.IsPresented = false; // Fecha o menu lateral

            });
        }

        private void CancelarMensagens()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "MeusAgendamentos");
            MessagingCenter.Unsubscribe<Usuario>(this, "NovoAgendamento");
        }
    }
}