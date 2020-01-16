using System;
using System.Collections.Generic;
using System.Text;
using SQLite;//Primeiro devemos chamar a biblioteca do banco


namespace EstoquesBD.Modelos
{
    [Table("Produto")]//Segundo devemos criar o nome da tabela
   public class Produtos
    {
        //Terceiro devemos instanciar os elementos da tabela do banco de dados
        [PrimaryKey, AutoIncrement]//Quarto passo criar uma chave primaria para não ocorre expction e 
                                   //AutoIncrement para incrementa automaticamente
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string produtoDescricao { get; set; }
        public string produtoUtilidade { get; set; }
        public int produtoQuantidade { get; set; }
        public double valor { get; set; }
        public DateTime Vencimento { get; set; }
    }
}
