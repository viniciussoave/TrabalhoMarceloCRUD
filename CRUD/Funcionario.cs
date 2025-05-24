namespace CRUD
{
    public class Funcionario
    {
        public string nome { get; set; }
        public int idade { get; set; }

        public Funcionario(string nome, int idade)
        {
            this.nome = nome;
            this.idade = idade;
        }
    }
}
