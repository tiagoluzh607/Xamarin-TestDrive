using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AluraTestDrive.Data;
using AluraTestDrive.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_android))] //Registrando no servico de dependencias para ser executado primeiro

namespace AluraTestDrive.Droid
{
    class SQLite_android : ISQLite
    {
        private const string nomeArquivoDB = "Agendamento.db3";

        public SQLiteConnection PegarConexao()
        {
            var caminhoDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, nomeArquivoDB); // Concatena caminho mais o nome do arquivo

           return new SQLite.SQLiteConnection(caminhoDB);
        }
    }
}