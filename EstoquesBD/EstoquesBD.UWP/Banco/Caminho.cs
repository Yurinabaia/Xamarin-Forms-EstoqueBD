using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoquesBD.Banco;
using System.IO;//E PRECISO TER ESTA BIBLIOTECA 
using Xamarin.Forms;//Primeiro instanciar a biblioteca Xamarin.Forms, pq nesta biblioteca tem o DependecyService
using Windows.Storage;//E preciso chamar a bibloteca de armazenamento
using EstoquesBD.UWP.Banco;//É preciso colocar o Namespace
[assembly: Dependency(typeof(Caminho))]//é depois chamar este assembly

namespace EstoquesBD.UWP.Banco
{
    class Caminho : IConectado //Terceiro colocar a classe como publica e depois chamar a interface ICaminho
    {
        /// <summary>
        /// Aqui vamos criar o caminho do banco de dados para o UWP
        /// </summary>
        public string ObeterCaminho(string NomeArquivoBanco)
        {
            string CaminhoDaPastaUWP = ApplicationData.Current.LocalFolder.Path;//Aqui estamos achando a pasta para
            //Salva o banco de dados
            string CaminhoBanco = Path.Combine(CaminhoDaPastaUWP, NomeArquivoBanco);//Penultimo passo chamar a pasta para nosso banco de dados, para que o caminho se junte ao banco
            return CaminhoBanco; //Ultimo passo retorna o caminho especifico para o banco
        }
    }
}
