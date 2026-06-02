# 3. Modelagem do Domínio
## 3.1. Relação de Herança ("É Um")
* ChamadoInfraestrutura -> É UM -> ChamadoSuporte
* ChamadoSistemaInterno -> É UM -> ChamadoSuporte
* ChamadoSeguranca -> É UM -> ChamadoSuporte
## 3.2. Estrutura
* Propriedades com 'private set' para proteger o estado interno.
* Validação centralizada no construtor da base, acionada por 'base(...)' nas filhas.
* Métodos 'virtual' na base e 'override' nas filhas para o cálculo do prazo e resumo.
