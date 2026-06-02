# 1. Documento de Escopo e Requisitos do Sistema

## 1.1. Contextualização Operacional
Este sistema foi projetado para centralizar, organizar e automatizar o fluxo de atendimento do suporte técnico de uma empresa de tecnologia. À medida que a operação se expande, os chamados deixam de ser genéricos e passam a exigir tratamentos especializados. A arquitetura desenvolvida utiliza os pilares da Orientação a Objetos (Encapsulamento, Herança e Polimorfismo) para segmentar essas demandas sem gerar duplicidade de código no Domínio.

## 1.2. Mapeamento de Atores
* **Solicitante (Usuário):** Ponto de partida do fluxo. Interage com a interface para relatar a falha, fornecendo os dados brutos como nome, descrição e o contexto inicial do problema.
* **Técnico de Suporte (Operador):** Responsável pela resolução da falha. Interage com o sistema para consumir os prazos calculados de atendimento (SLA) e dispara o encerramento seguro do chamado após a conclusão do serviço.

## 1.3. Requisitos Funcionais (RF)
* **RF01 - Especialização de Chamados via Herança:** O sistema deve suportar a criação de três categorias estritas de chamados: Infraestrutura, Sistema Interno e Segurança da Informação, herdando todas as propriedades básicas da classe mãe.
* **RF02 - Cálculo Automatizado de SLA:** O sistema deve calcular de forma automática o prazo máximo de atendimento (em horas) no momento em que o objeto é instanciado, cruzando a prioridade definida com as regras de desconto de cada tipo de chamado.
* **RF03 - Ciclo de Vida do Status:** O chamado deve nascer obrigatoriamente com o status 'Aberto'. O sistema deve fornecer um mecanismo seguro para transicionar o status para 'Encerrado', bloqueando alterações diretas nas propriedades.
* **RF04 - Geração de Relatório de Resumo:** O sistema deve ser capaz de emitir uma string formatada contendo o resumo completo do chamado, fundindo as informações gerais da classe base com os dados especializados da classe filha.
