namespace GestaoEmprestimos.Domain.Entities
{
    public class Professor
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Siape { get; private set; }

        public Professor(int id, string nome, string siape)
        {
            Id = id;
            Nome = nome;
            Siape = siape;
        }
    }
}
