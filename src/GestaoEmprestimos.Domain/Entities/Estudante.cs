namespace GestaoEmprestimos.Domain.Entities
{
    public class Estudante
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Matricula { get; private set; }

        public Estudante(int id, string nome, string matricula)
        {
            Id = id;
            Nome = nome;
            Matricula = matricula;
        }
    }
}
