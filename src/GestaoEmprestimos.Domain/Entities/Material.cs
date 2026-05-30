using GestaoEmprestimos.Domain.Enums;
using GestaoEmprestimos.Domain.ValueObjects;

namespace GestaoEmprestimos.Domain.Entities
{
    public class Material
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public TipoMaterial Tipo { get; private set; }
        public string Descricao { get; private set; }
        public string AreaConhecimento { get; private set; }
        public string NivelIndicado { get; private set; }
        public int QuantidadeDisponivel { get; private set; }
        public List<RecursoAcessibilidade> RecursosAcessibilidade { get; private set; } = new();

        public Material(int id, string titulo, TipoMaterial tipo, string descricao, string areaConhecimento, string nivelIndicado, int quantidadeDisponivel)
        {
            if (quantidadeDisponivel < 0)
                throw new ArgumentException("A quantidade disponível não pode ser negativa.");

            Id = id;
            Titulo = titulo;
            Tipo = tipo;
            Descricao = descricao;
            AreaConhecimento = areaConhecimento;
            NivelIndicado = nivelIndicado;
            QuantidadeDisponivel = quantidadeDisponivel;
        }
    }
}
