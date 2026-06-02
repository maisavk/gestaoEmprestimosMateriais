# 3. Arquitetura de Software e Rastreabilidade do Código

## 3.1. Justificativa da Relação de Herança ('É Um')
A modelagem do sistema adota a herança clássica porque existe um vínculo conceitual perfeito de especialização. Um ChamadoInfraestrutura não apenas possui um chamado, ele É UM chamado de suporte técnico em sua essência. Ele compartilha o mesmo ciclo de vida, o mesmo protocolo e a mesma necessidade de atendimento de qualquer outra solicitação. Centralizar esses aspectos na classe base elimina a duplicação de código e garante consistência arquitetural.

## 3.2. Diagrama de Classes Estrutural (UML)

\\\`n       +-------------------------------------------------------+
       |                   ChamadoSuporte                      |  <--- (Classe Mãe / Base)
       +-------------------------------------------------------+
       | + Protocolo: string { get; private set; }             |
       | + Solicitante: string { get; private set; }           |
       | + Descricao: string { get; private set; }             |
       | + Prioridade: PrioridadeChamado { get; private set; } |
       | + Status: StatusChamado { get; private set; }         |
       | + DataAbertura: DateTime { get; private set; }        |
       +-------------------------------------------------------+
       | + Construtor(protocolo, solicitante, desc, prioridade)| -> Aplica RN01, RN02 e RN03
       | + Encerrar(): void                                    | -> Altera Status para Encerrado
       | + virtual CalcularPrazoAtendimentoHoras(): double     | -> Retorna SLA Base
       | + virtual GerarResumo(): string                       | -> String com dados gerais
       +-------------------------------------------------------+
                                  ^
                                  | (Herança / Especialização)
         +------------------------+------------------------+
         |                        |                        |
+------------------------+ +------------------------+ +------------------------+
|  ChamadoInfraestrutura | |  ChamadoSistemaInterno | |    ChamadoSeguranca    |
+------------------------+ +------------------------+ +------------------------+
| + Local: string        | | + NomeSistema: string  | | + TipoIncidente: string|
| + Equipamento: string  | | + Modulo: string       | | + DadosSensiveis: bool |
| + EhCritico: bool      | | + EhEssencial: bool    | |                        |
+------------------------+ +------------------------+ +------------------------+
| + Construtor(...)      | | + Construtor(...)      | | + Construtor(...)      |
| + override Calcular... | | + override Calcular... | | + override Calcular... |
| + override GerarRes... | | + override GerarRes... | | + override GerarRes... |
+------------------------+ +------------------------+ +------------------------+
\\\`n
## 3.3. Rastreabilidade dos Pilares de Orientação a Objetos
* **Encapsulamento Rígido:** Todas as propriedades possuem modificadores de acesso 'private set'. A única forma de alterar o status de um chamado é invocando o método público '.Encerrar()'.
* **Polimorfismo via Sobrescrita:** O método de cálculo de prazo é 'virtual' na base. As filhas utilizam 'override' para interceptar esse cálculo, chamando 'base.CalcularPrazoAtendimentoHoras()' para obter o valor inicial e aplicando os descontos das regras RN04, RN05 ou RN06.
* **Reaproveitamento de Comportamento:** Na sobrescrita do método 'GerarResumo()', as classes filhas coletam o texto gerado por 'base.GerarResumo()' e apenas acrescentam os dados específicos daquele contexto técnico.
