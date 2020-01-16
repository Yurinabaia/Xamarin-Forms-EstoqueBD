using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstoquesBD.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesProdutos : ContentPage
    {
        public DetalhesProdutos(Modelos.Produtos POD)
        {
            InitializeComponent();
            BindingContext = POD;//Apenas isso para carregas nossas pagina de vaga. kk
            TEXTOPRINCIPAL.Text = "PRODUTO " + POD.NomeProduto.ToString();
            DESCRICAO.Text = "Descrição: " + POD.produtoDescricao.ToString();
            UTILIDADE.Text = "Utilidade do produto: " + POD.produtoUtilidade.ToString();
            QUANTIDADE.Text = "Quantidade de produtos: " + POD.produtoQuantidade.ToString();
            VALOR.Text = "Valor do produto: " + POD.valor.ToString();
            VENCIMENTO.Text = "VENCIMENTO: " + POD.Vencimento.ToString();
        }
    }
}