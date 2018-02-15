using AluraTestDrive.Converters;
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
	public partial class AgendamentosUsuarioView : ContentPage
	{
		public AgendamentosUsuarioView ()
		{
			InitializeComponent ();
            this.BindingContext = new AgendamentosUsuarioViewModel();
		}
	}
}