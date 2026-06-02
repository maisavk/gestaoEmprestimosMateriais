# 2. Regras de Negócio (RN)
## 2.1. Validações (Classe Base)
* **RN01:** Protocolo, solicitante e descrição são obrigatórios (não nulos/vazios).
* **RN02:** Data de abertura não pode ser futura.
* **RN03:** Status inicial deve ser sempre 'Aberto'.
## 2.2. SLA Padrão
* Baixa: 72h | Média: 48h | Alta: 24h | Crítica: 8h
## 2.3. Descontos por Tipo
* **Infraestrutura:** Se o equipamento for crítico, o prazo cai pela metade (-50%).
* **Sistema Interno:** Se o sistema for essencial, o prazo reduz em 25%.
* **Segurança:** Se envolver dados sensíveis, o prazo cai pela metade (-50%).
