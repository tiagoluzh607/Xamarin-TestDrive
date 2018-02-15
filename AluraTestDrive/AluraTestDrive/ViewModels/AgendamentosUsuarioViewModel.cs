using AluraTestDrive.Data;
using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AluraTestDrive.ViewModels
{
    public class AgendamentosUsuarioViewModel : BaseViewModel
    {
        public ObservableCollection<Agendamento> lista = new ObservableCollection<Agendamento>();
        public ObservableCollection<Agendamento> Lista // usamos um observable colection pois ele avisa o xamarin sobre mudanças Dinâmicamente
        {
            get {
                return lista;
            }
            private set {
                lista = value;
                OnPropertyChanged();
            }
        }


        public AgendamentosUsuarioViewModel()
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conexao);
                var listaBD = dao.Lista;

                var query = listaBD
                            .OrderBy(l => l.DataAgendamento)
                            .ThenBy(l => l.HoraAgendamento);

                foreach(var itemDB in query)
                {
                    this.Lista.Add(itemDB);
                }
            }
        }
    }
}
