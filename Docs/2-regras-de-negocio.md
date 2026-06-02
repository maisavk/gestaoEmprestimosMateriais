# 2. Matriz de Regras de Negócio e Consistência do Domínio

## 2.1. Validações de Consistência (Classe Base)
Para garantir que nenhum objeto inválido ou corrompido exista na memória da aplicação, o construtor da classe base (ChamadoSuporte) aplica as seguintes validações mandatórias antes de concluir a criação:
* **RN01 - Obrigatoriedade de Campos:** O número do protocolo, o nome do solicitante e a descrição do problema são campos estritamente obrigatórios. Caso a interface envie valores nulos, vazios ou compostos apenas por espaços em branco, o sistema dispara uma exceção (ArgumentException), interrompendo o fluxo imediatamente.
* **RN02 - Consistência Temporal:** A data de abertura do chamado deve ser capturada no momento exato da criação do objeto. O sistema bloqueia qualquer tentativa de registrar chamados com datas futuras em relação ao relógio do servidor.
* **RN03 - Imutabilidade do Estado Inicial:** O status de um chamado recém-criado não pode ser definido por parâmetros externos; ele é fixado nativamente como 'StatusChamado.Aberto'.

## 2.2. Matriz Base de Prazos (SLA Padrão)
O tempo limite de atendimento inicial é governado estritamente pela prioridade atribuída ao problema:
* Prioridade Baixa: SLA base de 72 horas para atendimento.
* Prioridade Média: SLA base de 48 horas para atendimento.
* Prioridade Alta: SLA base de 24 horas para atendimento.
* Prioridade Crítica: SLA base de 8 horas para atendimento.

## 2.3. Regras de Redução de Prazo por Especialização (Polimorfismo)
As classes derivadas devem sobrescrever o método de cálculo de prazo para aplicar descontos no tempo de atendimento com base na gravidade técnica do cenário:
* **RN04 - Atenuação em Infraestrutura:** Se o chamado for de Infraestrutura e o equipamento afetado for catalogado como 'Crítico' (ex: servidores, roteadores de borda), o prazo final de atendimento calculado pela base é reduzido pela metade (50% de desconto no tempo).
* **RN05 - Atenuação em Sistemas Internos:** Se o chamado for de Sistema Interno e a aplicação afetada for classificada como 'Essencial' (ex: ERP de faturamento), o prazo padrão estabelecido pela prioridade é reduzido em 25%.
* **RN06 - Atenuação em Segurança:** Se o chamado pertencer à categoria de Segurança da Informação e envolver a exposição ou vazamento de 'Dados Sensíveis' (LGPD), o prazo de atendimento é reduzido pela metade (50% de desconto no tempo) para mitigar o risco.
