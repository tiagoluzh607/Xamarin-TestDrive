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
	public partial class AgendamentosUsuarioView : ContentPage
	{
		public AgendamentosUsuarioView ()
		{
			InitializeComponent ();
            /*
            this.listViewAgendamentos.ItemsSource = new List<Agendamento> {
               new Agendamento("Joao da Silva","1234-5678", "joao@alura.com.br", "Astra 2.0", 40000),
               new Agendamento("Joao da Silva","1234-5678", "joao@alura.com.br", "Onix", 40000),
               new Agendamento("Joao da Silva","1234-5678", "joao@alura.com.br", "Vectra", 40000)
            };
            */
		}
	}
}