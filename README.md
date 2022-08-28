# Boas-vindas ao repositório do projeto TryBank

Abaixo estão as regras de negócio seguidas durante o desenvolvimento desse Desafio Agregador.

# Requisitos

Boas-vindas ao TryBank, uma iniciativa de implementar um serviço de banco financeiro para sua instituição do coração.💚

Você recebeu a demanda de criar a versão inicial do TryBank, bem como seus testes. Nesse projeto, você tem como objetivo construir um banco que contenha contas. Além disso, deve criar e validar os processos de cadastro, login, saque, depósito e transferência do saldo dessas contas. 

De olho na dica👀: Faça uma boa separação de responsabilidades e crie testes estruturados, garantindo assim que a evolução desse sistema ocorra facilmente.
 

## 1 - O programa deve cadastrar novas contas
Crie a lógica do seu requisito no arquivo src/trybank/Trybank.cs.

<details>
  <summary>O programa deve permitir o cadastro de novas contas</summary><br />

Crie esse requisito na função `RegisterAccount()`

Se essa combinação de **número e agência** já existir, você deverá lançar uma exceção do tipo `ArgumentException` com a mensagem `A conta já está sendo usada!`.

Caso contrário, a função deve armazenar os dados no array `Bank` na próxima posição disponível marcada por `registeredAccounts`

Caso tudo corra bem, a função deve incrementar a variável registeredAccounts;

</details>

<details>
  <summary>Crie os testes para o cadastro de contas</summary><br />

Crie esse requisito em `src/trybank.Test/TestFirstReq.cs`

Em `TestRegisterAccountSucess`, crie a lógica para verificar se a função `RegisterAccount` cadastra os dados passados por parâmetro.

Em `TestRegisterAccountException`, crie a lógica para verificar se a função `RegisterAccount`retorna uma exceção quando é passada uma conta que já existe.
De olho na dica 👀: Confira o lançamento de exceção e a mensagem que é retornada na exceção
</details>

## 2 - A pessoa usuária deve conseguir fazer Login e Logout
Crie a lógica do seu requisito no arquivo src/trybank/Trybank.cs.

<details>
  <summary>O programa deve permitir o Login da pessoa usuária</summary><br />

Crie esse requisito na função `Login()`

O estado de pessoa usuária logada é controlado pela variável `Logged`


- **Se já houver uma pessoa usuária logada**, você deverá lançar uma exceção do tipo `AccessViolationException` com a mensagem `Usuário já está logado`


 **Caso contrário**, a função deve procurar por essa combinação de número e agência.

-   **Se encontrado e a senha for correta**, a função deve alterar o estado da variável `Logged` e armazenar a posição da pessoa usuária logada na variável `loggedUser` (será útil futuramente para as próximas funções, fica a dica!)

-   **Se encontrado e a senha for incorreta**, você deve lançar uma exceção do tipo `ArgumentException` com a mensagem `Senha incorreta`

-   Se não for encontrada a combinação de `número e agência`, você deve lançar uma exceção do tipo `ArgumentException`com a mensagem `Agência + Conta não encontrada`


</details>

<details>
  <summary>O programa deve permitir o Logout do usário</summary><br />

Crie esse requisito na função `Logout()`

O estado de pessoa usuária logada é controlado pela variável `Logged`

**Se não houver uma pessoa usuária logada**, você deverá lançar uma exceção do tipo `AccessViolationException` com a mensagem `Usuário não está logado`

**Caso contrário**, a função deve alterar o estado da variável `Logged` e o índice de pessoa usuária `loggedUser` de volta para `-99`
</details>

<details>
  <summary>Crie os testes para o Login</summary><br />

Crie esse requisito em `src/trybank.Test/TestSecondReq.cs`

Em `TestLoginSucess`, crie a lógica para verificar se a função `Login` consegue alterar o estado da variável Logged.

Em `TestLoginExceptionLogged`, crie a lógica para verificar se a função `Login` retorna uma exceção quando é executada com uma conta já logada.

Em `TestLoginExceptionWrongPass`, crie a lógica para verificar se a função `Login` retorna uma exceção quando uma senha incorreta é passada.

Em `TestLoginExceptionNotFounded`, crie a lógica para verificar se a função `Login` retorna uma exceção quando uma combinação de número e agência não existe no array Bank.
</details>

<details>
  <summary>Crie os testes para o Logout</summary><br />

Crie esse requisito em `src/trybank.Test/TestSecondReq.cs`

Em `TestLogoutSucess`, crie a lógica para verificar se a função `Logout` consegue alterar o estado da variável Logged.

Em `TestLogoutExceptionNotLogged`, crie a lógica para verificar se a função `Logou` retorna uma exceção quando é executada sem uma conta já logada.

</details>

## 3 - O programa deve permitir checar o saldo, depositar e sacar dinheiro
Crie a lógica do seu requisito no arquivo src/trybank/Trybank.cs.

<details>
  <summary>O programa deve permitir verificar o saldo na conta da pessoa usária logada</summary><br />

Crie esse requisito na função `CheckBalance()`

**Se não houver uma pessoa usuária logada**, você deverá lançar uma exceção do tipo `AccessViolationException` com a mensagem `Usuário já está logado`

**Caso contrário**, a função deve retornar o saldo na conta da pessoa usuária logada.
</details>

<details>
  <summary>O programa deve permitir o depósito de um valor na conta da pessoa usária logada</summary><br />

Crie esse requisito na função `Deposit()`

**Se não houver uma pessoa usuária logada**, você deverá lançar uma exceção do tipo `AccessViolationException` com a mensagem `Usuário já está logado`

**Caso contrário**, a função deve adicionar o valor passado por parâmetro para o saldo da pessoa usuária logada.
</details>

<details>
  <summary>O programa deve permitir o saque de um valor na conta da pessoa usuária logada</summary><br />

Crie esse requisito na função `Withdraw()`

**Se não houver uma pessoa usuária logada**, você deverá lançar uma exceção do tpo `AccessViolationException`, com a mensagem `Usuário já está logado`

**Caso contrário**, a função deve retirar o valor passado por parâmetro para o saldo da pessoa usuária logada.
  Se o saldo da conta da pessoa usuária logada for insuficiente para fazer o saque, você deve lançar uma exceção do tipo `InvalidOperationException` com a mensagem `Saldo insuficiente`
</details>

<details>
  <summary>Crie os testes para Checar o Saldo</summary><br />

Crie esse requisito em `src/trybank.Test/TestThirdReq.cs`

Em `TestCheckBalanceSucess`, crie a lógica para verificar se a função `CheckBalance` consegue retornar corretamente o saldo de uma conta já logada.
  De olho na dica👀: Insira uma conta diretamente no array Bank ou use a função Login que já foi testada 🤗

Em `TestCheckBalanceWithoutLogin`, crie a lógica para verificar se a função `CheckBalance` retorna uma exceção quando é executada sem uma conta logada.

</details>

<details>
  <summary>Crie os testes para o Deposito</summary><br />

Crie esse requisito em `src/trybank.Test/TestThirdReq.cs`

Em `TestDepositSucess`, crie a lógica para verificar se a função `Deposit` consegue alterar o saldo de uma conta já logada.  

Em `TestDepositWithoutLogin`, crie a lógica para verificar se a função `Deposit` retorna uma exceção quando é executada sem uma conta logada.

</details>

<details>
  <summary>Crie os testes para o Sacar</summary><br />

Crie esse requisito em `src/trybank.Test/TestThirdReq.cs`

Em `TestWithdrawSucess`, crie a lógica para verificar se a função `Withdraw` consegue alterar o saldo de uma conta já logada.  

Em `TestWithdrawWithoutLogin`, crie a lógica para verificar se a função `Withdraw` retorna uma exceção quando é executada sem uma conta logada.

Em `TestWithdrawWithoutBalance`, crie a lógica para verificar se a função `Withdraw` retorna uma exceção quando o saldo da conta não é suficiente.

</details>

## 4 - O programa deve transferir dinheiro entre contas
Crie a lógica do seu requisito no arquivo src/trybank/Trybank.cs.

<details>
  <summary>O programa deve permitir a transferência de saldo entre uma pessoa usuária logada e uma conta existente</summary><br />

Crie esse requisito na função `    public void Transfer(int destinationNumber, int destinationAgency, int value)
()`

**Se não houver uma pessoa usuária logada**, você deverá lançar uma exceção do tipo `AccessViolationException`, com a mensagem `Usuário já está logado`

Se o saldo da conta da pessoa usuária logada for insuficiente para fazer a transferência, você deve lançar uma exceção do tipo `InvalidOperationException` com a mensagem `Saldo insuficiente`

**Caso contrário**, a função deve transferir o valor passado por parâmetro do saldo da pessoa usuária logada para o saldo da conta passada por parâmetro.
</details>

<details>
  <summary>Crie os testes para a Transferência</summary><br />

Crie esse requisito em `src/trybank.Test/TestThirdReq.cs`

Em `TestTransferSucess`, crie a lógica para verificar se a função `Transfer` consegue alterar o saldo de uma conta já logada e mover o valor para outra conta passada por parâmetro.  

Em `TestTransferWithoutLogin`, crie a lógica para verificar se a função `Transfer` retorna uma exceção quando é executada sem uma conta logada.

Em `TestTransferWithoutBalance`, crie a lógica para verificar se a função `Transfer` retorna uma exceção quando o saldo da conta logada não é suficiente.

</details>

Este projeto envolve os conhecimentos de estruturas de controle condicional e de repetição, além das exceções e seu controle sobre o fluxo de trabalho. A partir deste desafio, você certamente será uma pessoa mais bem preparada para os desafios do mercado de trabalho! #VQV 🚀
