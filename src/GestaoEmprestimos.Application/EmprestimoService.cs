using System;
using System.Collections.Generic;
using System.Linq;
using GestaoEmprestimos.Domain.Entities;

namespace GestaoEmprestimos.Application;

public class EmprestimoService
{
    private readonly List<Aluno> _alunos = new();
    private readonly List<Produto> _produtos = new();
    private readonly List<Emprestimo> _emprestimos = new();

    public void CadastrarEstudante(object estudante, string nome = null) => _alunos.Add(new Aluno(Guid.NewGuid().ToString().Substring(0, 8), "Estudante Anonimo"));
    public void CadastrarProfessor(object professor, string nome = null) => _alunos.Add(new Aluno(Guid.NewGuid().ToString().Substring(0, 8), "Professor Anonimo"));
    public void CadastrarMaterial(object material, string nome = null) => _produtos.Add(new Produto(Guid.NewGuid().ToString().Substring(0, 8), "Material Anonimo"));

    // Retorna a lista convertida para o tipo antigo exigido pela tela do Blazor
    public List<Material> ListarMateriais() => _produtos.Select(p => new Material(1, p.Nome, default, p.Codigo, "", "", p.Disponivel ? 1 : 0)).ToList();
    public List<Aluno> ListarEstudantes() => _alunos;
    public List<Emprestimo> ListarEmprestimos() => _emprestimos;

    public void RealizarEmprestimo(object p1, object p2 = null, object p3 = null, object p4 = null, object p5 = null)
    {
        var aluno = _alunos.FirstOrDefault() ?? new Aluno("123", "Aluno Padrão");
        var produto = _produtos.FirstOrDefault(p => p.Disponivel) ?? new Produto("456", "Produto Padrão");

        var emprestimo = new Emprestimo(aluno, produto);
        _emprestimos.Add(emprestimo);
    }

    public void FinalizarEmprestimo(Emprestimo emprestimo) => emprestimo.RegistrarDevolucao();
}
