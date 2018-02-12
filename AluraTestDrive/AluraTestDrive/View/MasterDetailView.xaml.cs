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
	}
}