using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AluraTestDrive.Media;
using AluraTestDrive.Droid;
using Xamarin.Forms;
using Android.Content;
using Android.Provider;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))] //Registrando no servico de dependencias para ser executado primeiro

namespace AluraTestDrive.Droid
{
    [Activity(Label = "AluraTestDrive", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {

        static Java.IO.File arquivoImagem; //referencia para a imagem

        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture); // Construindo a intenção de acessar a camera para pegar uma foto

            arquivoImagem = PegarArquivoImagem();

            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(arquivoImagem)); // colocando na nossa intenção que queremos um output a imagem

            var activity = Forms.Context as Activity; //transformando contexto atual em activity
            activity.StartActivityForResult(intent, 0);
        }

        private static Java.IO.File PegarArquivoImagem()
        {
            Java.IO.File arquivoImagem;
            //Setando para qual diretorio salvar a pasta
            Java.IO.File diretorio = new Java.IO.File(
                    Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures),
                    "Imagens"
                );

            if (!diretorio.Exists()) { diretorio.Mkdirs(); } // Se o diretorio não existir cria o diretorio e toda a estrura acima dele

            arquivoImagem = new Java.IO.File(diretorio, "MinhaFoto.jpg"); //dizendo qual será o nome da imagem e o diretório de saida
            return arquivoImagem;
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        //Tratando o resultado da activity, caira nesse trecho mesmo se o usuario aceitar ou nao 
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok) { //somente se o usuario nao cancelar a foto

                //Como vamos passar a imagem para o projeto portable precisamos transformar em um array de bytes
                byte[] bytes;
                using (var stream = new Java.IO.FileInputStream(arquivoImagem))
                {
                    bytes = new byte[arquivoImagem.Length()];
                    stream.Read(bytes);
                }

                MessagingCenter.Send<byte[]>(bytes, "FotoTirada");
            }
        }
    }
}

