using AluraTestDrive.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

        public string Email
        {
            get { return usuario.email; }
            set { usuario.email = value; }
        }

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
        }

    }
}
