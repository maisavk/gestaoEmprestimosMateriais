namespace GestaoEmprestimos.Domain.Entities;

public class Aluno
{
    public string RegistroAcademico { get; private set; }
    public string Nome { get; private set; }

    public Aluno(string registroAcademico, string nome)
    {
        if (string.IsNullOrWhiteSpace(registroAcademico))
            throw new ArgumentException("O registro acadêmico é obrigatório.");

        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do aluno é obrigatório.");

        RegistroAcademico = registroAcademico;
        Nome = nome;
    }
}
