namespace GestaoEmprestimos.Domain.ValueObjects
{
    public class RecursoAcessibilidade
    {
        public string Nome { get; init; }
        public string Descricao { get; init; }

        public RecursoAcessibilidade(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
