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
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
			InitializeComponent ();
		}

        private void Entrar_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
        }
	}
}