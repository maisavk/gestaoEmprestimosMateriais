using System;

namespace GestaoEmprestimos.Domain.Entities;

public class Emprestimo
{
    public Guid Id { get; private set; }
    public Aluno Aluno { get; private set; }
    public Produto Produto { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime? DataDevolucao { get; private set; }

    public Emprestimo(Aluno aluno, Produto produto)
    {
        Aluno = aluno ?? throw new ArgumentNullException(nameof(aluno), "O aluno não pode ser nulo.");
        Produto = produto ?? throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");

        if (!produto.Disponivel)
            throw new InvalidOperationException("Não é possível emprestar um produto que já está ocupado.");

        Id = Guid.NewGuid();
        DataEmprestimo = DateTime.Now;
        Produto.AlterarDisponibilidade(false);
    }

    public void RegistrarDevolucao()
    {
        if (DataDevolucao.HasValue)
            throw new InvalidOperationException("Este empréstimo já foi devolvido.");

        DataDevolucao = DateTime.Now;
        Produto.AlterarDisponibilidade(true);
    }
}
