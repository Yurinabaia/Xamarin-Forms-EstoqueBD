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
    public partial class EditarProduto : ContentPage
    {
        private Produtos pod { get; set; }

        public EditarProduto(Produtos produtos)
        {
            InitializeComponent();
            this.pod = produtos;
            NOME.Text = pod.NomeProduto;
            VENCIMENTO.Date = pod.Vencimento;
            UTILIDADEDEPRODUTO.Text = pod.produtoUtilidade;
            QUANTIDADE.Text = pod.produtoQuantidade.ToString();
            VALOR.Text = pod.valor.ToString();
            DESCRICAO.Text = pod.produtoDescricao;
        }
        public void SALVAEDITADO(object sender, EventArgs args)
        {
            //TODO - validar dados de cadastro
            pod.NomeProduto = NOME.Text;
            pod.Vencimento = VENCIMENTO.Date;
            pod.produtoUtilidade = UTILIDADEDEPRODUTO.Text;
            pod.produtoQuantidade = int.Parse(QUANTIDADE.Text);
            pod.valor = double.Parse(VALOR.Text);
            pod.produtoDescricao = DESCRICAO.Text;

            AcessandoBancoDeDados banco = new AcessandoBancoDeDados();
            banco.Atualizacao(pod);
            //TODO - voltar tela de pesquisa
            App.Current.MainPage = new NavigationPage(new PaginaInicial());
            ///O TODO FAZ COM QUE APAREÇAR INFORMAÇÕES A SER APRESENTADA NO PROGRAMA, NO LISTA DE TAREFAS VC PODE ACOMPANHAR
        }
    }
}