using System;
using GestaoEmprestimos.Application;
using GestaoEmprestimos.Domain.Entities;
using GestaoEmprestimos.Domain.Enums;

namespace GestaoEmprestimos.ConsoleApp
{
    class Program
    {
        private static readonly EmprestimoService _service = new();
        private static int _idContadorEmprestimo = 100;

        static void Main(string[] args)
        {
            // 1. LISTANDO VÁRIOS MATERIAIS INICIAIS (Resolve ponto 1)
            _service.CadastrarEstudante(new Estudante(1, "Maisa Vendrame", "2026001"));
            _service.CadastrarProfessor(new Professor(1, "Prof. Clodoaldo", "SIAPE123"));
            
            _service.CadastrarMaterial(new Material(1, "Livro em Braille - Cálculo I", TipoMaterial.Braille, "Material Adaptado", "Exatas", "Superior", 2));
            _service.CadastrarMaterial(new Material(2, "Audiolivro - História do Brasil", TipoMaterial.Audio, "Áudio com descrição", "Humanas", "Médio", 1));
            _service.CadastrarMaterial(new Material(3, "Mapa Rel relevo Tátil", TipoMaterial.Tatil, "Maquete tátil geográfica", "Geografia", "Fundamental", 3));
            _service.CadastrarMaterial(new Material(4, "Apostila Fonte Ampliada - Química", TipoMaterial.Ampliado, "Letras tamanho 24", "Exatas", "Médio", 0)); // Já começa zerado

            string opcao = "";
            while (opcao != "0")
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTÃO DE EMPRÉSTIMOS DE MATERIAIS ===");
                Console.WriteLine("1. Ver Estoque e Materiais Disponíveis");
                Console.WriteLine("2. Realizar Novo Empréstimo (Escolhendo Material)");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        // MOSTRA O ESTOQUE ATUALIZADO EM TEMPO REAL (Resolve ponto 3)
                        Console.WriteLine("\n--- CONSULTA DE ESTOQUE ATUALIZADO ---");
                        Console.WriteLine("----------------------------------------------------------------------");
                        foreach (var m in _service.ListarMateriais())
                        {
                            string statusEstoque = m.QuantidadeDisponivel > 0 ? $"{m.QuantidadeDisponivel} unidades" : "INDISPONÍVEL (ZERADO)";
                            Console.WriteLine($"ID: {m.Id} | {m.Titulo.PadRight(32)} | Tipo: {m.Tipo.ToString().PadRight(9)} | Estoque: {statusEstoque}");
                        }
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("\n--- NOVO EMPRÉSTIMO ---");
                        
                        // EXIBE O MENU DE MATERIAIS PARA ESCOLHA (Resolve ponto 2)
                        Console.WriteLine("Materiais disponíveis para escolha:");
                        foreach (var m in _service.ListarMateriais())
                        {
                            Console.WriteLine($"  [{m.Id}] - {m.Titulo} (Disponível: {m.QuantidadeDisponivel})");
                        }
                        
                        Console.Write("\nDigite o ID do material que deseja pegar emprestado: ");
                        if (int.TryParse(Console.ReadLine(), out int idEscolhido))
                        {
                            try
                            {
                                _idContadorEmprestimo++;
                                // Executa a regra passando o ID que você escolheu no menu
                                _service.RealizarEmprestimo(_idContadorEmprestimo, 1, 1, idEscolhido, 7);
                                
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n[SUCESSO] Empréstimo registrado! O estoque foi reduzido.");
                                Console.ResetColor();
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\n[BLOQUEADO PELO PRD]: {ex.Message}");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
