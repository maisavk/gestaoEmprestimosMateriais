# Gestão de Empréstimos de Materiais

Sistema corporativo em C# focado nos pilares da Orientação a Objetos, encapsulamento rígido e arquitetura segregada em camadas (Clean Architecture / DDD), garantindo a consistência do domínio e isolamento das regras de negócio.

## 🏗️ Arquitetura e Estrutura
* **GestaoEmprestimos.Domain:** Entidades puras (Aluno, Produto, Emprestimo) com validações rígidas de consistência no construtor.
* **GestaoEmprestimos.Application:** EmprestimoService atuando como camada de orquestração entre as regras de negócio e as interfaces.
* **GestaoEmprestimos.Infrastructure:** Suporte infraestrutural e persistência de dados.
* **GestaoEmprestimos.ConsoleApp / Blazor:** Interfaces visuais (CLI e Web) que consomem os serviços compartilhados.

## 🔒 Princípios e Regras de Negócio
1. **Encapsulamento Rígido:** Propriedades utilizam 'private set', blindando o estado interno. Alterações ocorrem estritamente por métodos de negócio (ex: .RegistrarDevolucao()).
2. **Validação Automática:** Construtores validam campos obrigatórios (como RA e códigos), disparando exceções imediatamente caso recebam dados inválidos.
3. **Controle de Fluxo:** O domínio gerencia automaticamente a disponibilidade do material no momento do empréstimo e da devolução.

## 🚀 Como Executar
dotnet run --project src/GestaoEmprestimos.Blazor
