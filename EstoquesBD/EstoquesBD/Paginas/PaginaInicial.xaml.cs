using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstoquesBD.Banco;
using EstoquesBD.Modelos;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EstoquesBD.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicial : ContentPage
    {
        List<Produtos> listando { get; set; }
        public PaginaInicial()
        {
            InitializeComponent();
            AcessandoBancoDeDados banco = new AcessandoBancoDeDados();
            listando = banco.Consultar();
            LISTAPRODUTO.ItemsSource = listando;
            LBLprodtuo.Text = "Quantidade de produtos " + listando.Count.ToString();
        }
        public void IrPaginasProdutos(object sender, EventArgs args) //Todo botão possuir object sender, EventArgs args 
        {
            Navigation.PushAsync(new CadastraProduto());
        }
        public void IrMeusProdutos(object sender, EventArgs args) //Todo botão possuir object sender, EventArgs args 
        {
            Navigation.PushAsync(new MeusProdutos());
        }
        public void IrMaisDetalhes(object sender, EventArgs args) //Todo botão possuir object sender, EventArgs args 
        {
            Label lblDetalhe = (Label)sender;
            TapGestureRecognizer tapgest = (TapGestureRecognizer)lblDetalhe.GestureRecognizers[0];//Aqui estamos pegando o toque na label
            Produtos POD = tapgest.CommandParameter as Produtos;//Aqui estamos pegando a propriedade dela que e uma Vagas e colocando para ser um botão
            Navigation.PushAsync(new DetalhesProdutos(POD));//Aqui estamos fazendo a ação do GestureRecognizer
        }
        public void FiltraProduto(object sender, TextChangedEventArgs args) //Todo TextChanged="FiltraVaga"  
                                                                         //possuir um object sender, TextChangedEventArgs args;
        {
            LISTAPRODUTO.ItemsSource = listando.Where(x => x.NomeProduto.Contains(args.NewTextValue)).ToList();
        }
    }
}