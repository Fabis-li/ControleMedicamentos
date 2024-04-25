# Controle de Medicamentos
## Projeto
Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2024

---

## Detalhes
Com a necessidade de controlar os estoques das farm�cias dos postos de sa�de de Lages, foi proposto pelo secret�rio da sa�de Jo�o do Nascimento, a cria��o de um sistema simples para a gest�o do estoque de rem�dios dos postos de sa�de de Lages, para assim atender melhor a popula��o nos bairros.

Eles desejam otimizar o controle de estoque das farm�cias para facilitar e agilizar o processo de distribui��o de rem�dios aos pacientes. Os postos utilizam formul�rios de papel para armazenar as informa��es das quantidades de rem�dios dispon�veis nos estoques.

Atualmente, os pacientes requisitam um medicamento e ao fazer a requisi��o o funcion�rio do posto verifica a disponibilidade do medicamento no sistema e caso o mesmo esteja dispon�vel o atendente d� baixa no sistema (atualiza a quantidade) e entrega o medicamento ao paciente que j� esteja cadastrado.

---

## Funcionalidades
1. Controle de Medicamentos
- Registrar Medicamento: O registro de um medicamento ir� ser formado por: nome, descri��o e quantidade do estoque. Caso o mesmo j� esteja cadastrado, � atualizado a quantidade.
- Visualizar Medicamentos: Exibe uma lista exibindo detalhes de todos os medicamentos registrados, tamb�m dever� exibir quais medicamentos est�o em falta (<20 unidades).
- Editar Medicamentos: Oferece a possibilidade de modificar informa��es de um medicamento existente.
- Excluir Medicamentos: Permite remover um medicamento do sistema, atualizando a lista de medicamentos registrados.
2. Controle de Paciente
- Registrar Paciente: O paciente dever� ser registrado com as seguintes informa��es: nome, telefone e cart�o do SUS.
- Visualizar Pacientes: Exibe uma lista exibindo detalhes de todos os medicamentos registrados.
- Editar Pacientes: Oferece a possibilidade de modificar informa��es de um paciente cadastrado.
- Excluir Pacientes: Permite remover um registro de paciente do sistema.
3. Controle de Requisi��es
- Registrar Requisi��o: O paciente poder� registrar uma nova requisi��o que incluir�: data da requisi��o, dados do paciente, dados do medicamento e a quantidade do medicamento requisitada.
- Visualizar Requisi��es: Exibe uma lista exibindo detalhes de todas as requisi��es registradas.
- Visualizar Requisi��es de um Paciente: Permite visualizar uma lista de requisi��es realizadas por um paciente espec�fico.
- Ao fazer uma requisi��o de medicamento, ser� necess�rio verificar se a quantidade do mesmo est� dispon�vel no estoque. Tamb�m ser� necess�rio subtrair esta quantidade do registro do estoque.

Ao fazer uma requisi��o de medicamento, ser� necess�rio verificar se a quantidade do mesmo est� dispon�vel no estoque. Tamb�m ser� necess�rio subtrair esta quantidade do registro do estoque.

---
## Requisitos
- .NET SDK (recomendado .NET 8.0 ou superior) para compila��o e execu��o do projeto.

---
## Como Usar
### Clone o Reposit�rio
```
git clone https://github.com/academia-do-programador/controle-medicamentos-2024.git
```
### Navegue at� a pasta raiz da solu��o
```
cd controle-medicamentos-2024
```
### Restaure as depend�ncias
```
dotnet restore
```
### Navegue at� a pasta do projeto
```
cd ControleMedicamentos.ConsoleApp
```
### Execute o projeto
```
dotnet run
```
