using System;
using CRUD;

namespace Console
{
    public class Program
    {
        public static void Main()
        {
            conexao Conexao = new conexao();

            Conexao.conectar();

            Funcionario funcionario = new Funcionario("Lucas", 20);
            Funcionario funcionario2 = new Funcionario("Rafael", 19);

            //Conexao.inserir(funcionario);

            Conexao.leitura();
            //Conexao.demitir(5);

            Conexao.atualizar(funcionario2, 6);
        }
    }
}

