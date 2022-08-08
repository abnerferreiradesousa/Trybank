using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestThirdReq
{
    [Theory(DisplayName = "Deve devolver o saldo em uma conta logada")]
    [InlineData(0)]
    public void TestCheckBalanceSucess(int balance)
    {        
        var instance = new Trybank();
        instance.Login(0, 0, 0);
        var res = instance.CheckBalance();
        res.Should().Be(balance);

    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestCheckBalanceWithoutLogin(int balance)
    {        
        var instance = new Trybank();
        instance.Logged = false;
        instance.Bank[0, 0] = balance;
        Action act = () => instance.CheckBalance();
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");

    }

    [Theory(DisplayName = "Deve depositar um saldo em uma conta logada")]
    [InlineData(10)]
    public void TestDepositSucess(int value)
    {        
        var instance = new Trybank();
        instance.Login(0, 0, 0);
        instance.Logged = true;
        instance.loggedUser = 0;
        instance.Deposit(10);
        var res =  instance.Bank[instance.loggedUser, 3];
        res.Should().Be(value);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(10)]
    public void TestDepositWithoutLogin(int value)
    {        
        var instance = new Trybank();
        instance.Logged = false;
        Action act = () => instance.Deposit(value);
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve sacar um valor em uma conta logada")]
    [InlineData(0, 0)]
    public void TestWithdrawSucess(int balance, int value)
    {        
        var instance = new Trybank();
        instance.Login(0, 0, 0);
        instance.Logged = true;
        instance.loggedUser = 1;
        instance.Withdraw(balance);
        var res =  instance.Bank[instance.loggedUser, 3];
        res.Should().Be(value);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de saldo insuficiente")]
    [InlineData(10)]
    public void TestWithdrawWithoutLogin(int value)
    {        
        var instance = new Trybank();
        instance.Login(0, 0, 0);
        instance.Logged = true;
        instance.loggedUser = 1;
        Action act = () => instance.Withdraw(value);
        act.Should().Throw<InvalidOperationException>().WithMessage("Saldo insuficiente");
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0, 0)]
    public void TestWithdrawWithoutBalance(int balance, int value)
    {        
        var instance = new Trybank();
        instance.Bank[0, 3] = balance;
        instance.Login(0, 0, 0);
        instance.Logged = false;
        instance.loggedUser = 1;
        Action act = () => instance.Withdraw(value);
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }
}