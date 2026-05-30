using GestaoEmprestimos.Domain.Enums;

namespace GestaoEmprestimos.Domain.Entities
{
    public class Emprestimo
    {
        public int Id { get; private set; }
        public Estudante Estudante { get; private set; }
        public Professor ProfessorSolicitante { get; private set; }
        public Material Material { get; private set; }
        public DateTime DataRetirada { get; private set; }
        public DateTime PrazoDevolucao { get; private set; }
        public SituacaoEmprestimo Situacao { get; private set; }

        public Emprestimo(int id, Estudante estudante, Professor professorSolicitante, Material material, int diasPrazo)
        {
            if (material.QuantidadeDisponivel <= 0)
                throw new InvalidOperationException("Material indisponível para empréstimo.");

            Id = id;
            Estudante = estudante;
            ProfessorSolicitante = professorSolicitante;
            Material = material;
            DataRetirada = DateTime.Now;
            PrazoDevolucao = DateTime.Now.AddDays(diasPrazo);
            Situacao = SituacaoEmprestimo.Solicitado;
        }
    }
}
