using System;
using System.Collections.Generic;
using System.Text;
using SQLite;//Primeiro devemos importa a biblioteca do banco de dados 
using Xamarin.Forms;//Primeiro devemos importa a biblioteca do XamarinForms
using EstoquesBD.Modelos;//Quarta parte chamar a classe com elementos que iram para banco de dados
using System.Linq;

namespace EstoquesBD.Banco
{
  public  class AcessandoBancoDeDados
    {
        private SQLiteConnection _conexao;//Segundo chamar o SQLiteConnection
        public AcessandoBancoDeDados()//Construtor
        {
            ///apenas criar este var dep depois de ter passado pelos Dez passos adiantes
            var dep = DependencyService.Get<IConectado>();//O ultimo passo, instanciar o DependencyService.Get<ICaminho>();
            string caminho = dep.ObeterCaminho("database.sqlite");//Está string ira para os parametros do SQLiteConnection
            ///NÃO ESQUE ESTA PARTE DE CIMA E A ULTIMA PARTE, POR ISSO É IMPORTANTE VER ELA POR ULTIMO

            //O new SQLiteConnection(); é preciso intanciar o caminho para o banco de dados.
            //Porem a cada sistema operacional tem um caminho especifico
            //é preciso utiliza a DepedencyService;
            _conexao = new SQLiteConnection(caminho);//Terceiro criar um contrutor para chamar o metodo SQLiteConnection

            ///Aqui vamos criar a tabela Vaga, depois de ter feitos os dez passos

            _conexao.CreateTable<Produtos>();//Criamos a tabela para o banco de dados
        }
        public void Cadastro(Produtos produto) //Quinta parte criar um metodo para receber os valores da classe importada no quarto passo
        {

            _conexao.Insert(produto);//Aqui ira fazer o cadastro da vaga
        }
        public void Exclusao(Produtos produto)//Sexto passo metodo de exlusão para o Banco de dados, o id vai referenciar o objeto a ser excluido
        {
            _conexao.Delete(produto);//Aqui vai deletar a vaga
        }
        public void Atualizacao(Produtos produto)//Setimo passar, criar um metodo de atualização do BD
        {
            _conexao.Update(produto);//Aqui vai atualizar a vaga
        }
        public List<Produtos> Consultar() //Oitavo criar um metodo de consulta para Banco de dados
        {
            ///CRIANDO A CONSULTA DEPOIS DE TER FEITO OS DEZ PASSOS
          //  _conexao.Table<Vagas>().ToList();//Aqui estamos pegando todos as informações do nosso banco
            return _conexao.Table<Produtos>().ToList();
        }
        public Produtos ObterVagaPorId(int ID)//Nono passo criar um metodo que ira consulta a vaga especifica 
        {
            return _conexao.Table<Produtos>().ToList().Where(x => x.Id == ID).FirstOrDefault();//Aqui criamos 
            //Uma labda para busca no Banco com Where o valor do id deve ser o mesmo para o ID que ira receber
        }
        public List<Produtos> PesquisaPorNome(string Palavra)//Nono passo criar um metodo que ira consulta a vaga especifica 
        {
            return _conexao.Table<Produtos>().ToList().Where(x => x.NomeProduto.Contains(Palavra)).ToList(); //Aqui criamos 
            //Uma labda para busca no Banco com Where o valor do id deve ser o mesmo para o ID que ira receber
        }
        //Decimo passo criar a Inteface ICaminho, para criar um metodo 
        //Que retorne o caminho que pode ser salvo ou que está salvo nosso banco de dados
    }
}
