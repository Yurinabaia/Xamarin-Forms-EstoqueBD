using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO; //E PRECISO TER ESTA BIBLIOTECA 
using Xamarin.Forms;//Primeiro instanciar a biblioteca Xamarin.Forms, pq nesta biblioteca tem o DependecyService
using EstoquesBD.Banco;//Segundo chamar a pasta do BancoDeDados
using EstoquesBD.Droid.Banco;//É preciso colocar o Namespace
[assembly: Dependency(typeof(Caminho))]//é depois chamar este assembly

namespace EstoquesBD.Droid.Banco
{
    /// <summary>
    /// Aqui vamos criar o caminho do banco de dados para o android
    /// </summary>
    class Caminho : IConectado //Terceiro chamar a interface, e colocar a classe como public
    {
        public string ObeterCaminho(string NomeArquivoBanco)//Quarto criar um metodo que implemente o caminho, OBS deve ser o mesmo nome do metodo da interface ICaminho
        {
            string CaminhoDaPastadoAndroid = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);//Sexto retorna um metodo ate determinada pasta 
            //System.Environment.SpecialFolder.Personal;//Aqui vamos pegar a pasta especifica chamada Personal, ou seja
            // uma pasta pessoal e dentro dela que vamos colocar nosso banco, vamos o  System.Environment.SpecialFolder.Personal colocarmos no parametro do GetFolderPath
            string CaminhoBanco = Path.Combine(CaminhoDaPastadoAndroid, NomeArquivoBanco);//Penultimo passo chamar a pasta para nosso banco de dados, para que o caminho se junte ao banco
            return CaminhoBanco;//Ultimo passo retorna o caminho especifico para o banco
        }
    }
}