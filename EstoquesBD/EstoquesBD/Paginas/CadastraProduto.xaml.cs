using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoquesBD.Modelos;
using EstoquesBD.Banco;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstoquesBD.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastraProduto : ContentPage
    {
        public CadastraProduto()
        {
            InitializeComponent();
        }
        public void SALVACADASTRO(object sender, EventArgs args)
        {
            //TODO - validar dados de cadastro
            Produtos pod = new Produtos();
            pod.NomeProduto = NOME.Text;
            pod.Vencimento = VENCIMENTO.Date;
            pod.produtoUtilidade = UTILIDADEDEPRODUTO.Text;
            pod.produtoQuantidade = int.Parse(QUANTIDADE.Text);
            pod.valor = double.Parse(VALOR.Text);
            pod.produtoDescricao = DESCRICAO.Text;

            AcessandoBancoDeDados banco = new AcessandoBancoDeDados();
            banco.Cadastro(pod);
            //TODO - voltar tela de pesquisa
            App.Current.MainPage = new NavigationPage(new PaginaInicial());
            ///O TODO FAZ COM QUE APAREÇAR INFORMAÇÕES A SER APRESENTADA NO PROGRAMA, NO LISTA DE TAREFAS VC PODE ACOMPANHAR
        }
    }
}