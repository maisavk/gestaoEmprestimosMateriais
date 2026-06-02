namespace GestaoEmprestimos.Domain.Entities;

public class Produto
{
    public string Codigo { get; private set; }
    public string Nome { get; private set; }
    public bool Disponivel { get; private set; }

    public Produto(string codigo, string nome)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("O código do produto é obrigatório.");

        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do produto é obrigatório.");

        Codigo = codigo;
        Nome = nome;
        Disponivel = true;
    }

    public void AlterarDisponibilidade(bool disponivel)
    {
        Disponivel = disponivel;
    }
}
