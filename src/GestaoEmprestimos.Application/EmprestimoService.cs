using GestaoEmprestimos.Domain.Entities;
using GestaoEmprestimos.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoEmprestimos.Application
{
    public class EmprestimoService
    {
        private readonly List<Material> _materiais = new();
        private readonly List<Estudante> _estudantes = new();
        private readonly List<Professor> _professores = new();
        private readonly List<Emprestimo> _emprestimos = new();

        public void CadastrarMaterial(Material material) => _materiais.Add(material);
        public void CadastrarEstudante(Estudante estudante) => _estudantes.Add(estudante);
        public void CadastrarProfessor(Professor professor) => _professores.Add(professor);

        public List<Material> ListarMateriais() => _materiais;
        public List<Estudante> ListarEstudantes() => _estudantes;
        public List<Professor> ListarProfessores() => _professores;
        public List<Emprestimo> ListarHistorico(int estudanteId) => _emprestimos.Where(e => e.Estudante.Id == estudanteId).ToList();

        public void RealizarEmprestimo(int id, int estudanteId, int professorId, int materialId, int diasPrazo)
        {
            var estudante = _estudantes.FirstOrDefault(e => e.Id == estudanteId) ?? throw new Exception("Estudante não encontrado.");
            var professor = _professores.FirstOrDefault(p => p.Id == professorId) ?? throw new Exception("Professor não encontrado.");
            var material = _materiais.FirstOrDefault(m => m.Id == materialId) ?? throw new Exception("Material não encontrado.");

            // A regra de negócio do domínio vai validar a quantidade disponível aqui dentro do construtor
            var emprestimo = new Emprestimo(id, estudante, professor, material, diasPrazo);
            _emprestimos.Add(emprestimo);
            
            // Simula a baixa no estoque da memória
            var index = _materiais.FindIndex(m => m.Id == materialId);
            _materiais[index] = new Material(material.Id, material.Titulo, material.Tipo, material.Descricao, material.AreaConhecimento, material.NivelIndicado, material.QuantidadeDisponivel - 1);
        }
    }
}
