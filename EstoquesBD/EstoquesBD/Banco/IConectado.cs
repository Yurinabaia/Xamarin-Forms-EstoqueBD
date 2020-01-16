using System;
using System.Collections.Generic;
using System.Text;

namespace EstoquesBD.Banco
{
  public  interface IConectado
    {
        string ObeterCaminho(string NomeArquivoBanco);//Aqui estamos criando um metodo que vai 
        //ter um parametro em string para pegar o caminho especifico do BD
        //A cada plataforma deve ser criado a pasta Banco e depois criar uma classe caminho.cs
    }
}
