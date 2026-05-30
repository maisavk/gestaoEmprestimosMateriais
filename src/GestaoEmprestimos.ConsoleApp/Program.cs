using System;
using GestaoEmprestimos.Application;
using GestaoEmprestimos.Domain.Entities;
using GestaoEmprestimos.Domain.Enums;

namespace GestaoEmprestimos.ConsoleApp
{
    class Program
    {
        private static readonly EmprestimoService _service = new();

        static void Main(string[] args)
        {
            // Dados Iniciais de Teste
            _service.CadastrarEstudante(new Estudante(1, "Maisa Vendrame", "2026001"));
            _service.CadastrarProfessor(new Professor(1, "Prof. Clodoaldo", "SIAPE123"));
            _service.CadastrarMaterial(new Material(1, "Livro em Braille - Cálculo I", TipoMaterial.Braille, "Material Adaptado", "Exatas", "Superior", 1)); // Apenas 1 disponível

            string opcao = "";
            while (opcao != "0")
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE GESTÃO DE EMPRÉSTIMOS DE MATERIAIS ===");
                Console.WriteLine("1. Listar Materiais Disponíveis");
                Console.WriteLine("2. Solicitar Empréstimo (Testar Fluxo Sucesso)");
                Console.WriteLine("3. Forçar Erro (Testar Regra de Estoque Esgotado)");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("\n--- Materiais no Sistema ---");
                        foreach (var m in _service.ListarMateriais())
                            Console.WriteLine($"ID: {m.Id} | {m.Titulo} | Qtd: {m.QuantidadeDisponivel}");
                        Console.ReadKey();
                        break;

                    case "2":
                        try
                        {
                            _service.RealizarEmprestimo(101, 1, 1, 1, 7);
                            Console.WriteLine("\n[SUCESSO] Empréstimo registrado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\n[ERRO CONHECIDO]: {ex.Message}");
                        }
                        Console.ReadKey();
                        break;

                    case "3":
                        try
                        {
                            Console.WriteLine("\nTentando pegar o mesmo material de novo (Estoque estará 0)...");
                            _service.RealizarEmprestimo(102, 1, 1, 1, 7);
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n[REGRA DE NEGÓCIO DO PRD BATEU]: {ex.Message}");
                            Console.ResetColor();
                        }
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
