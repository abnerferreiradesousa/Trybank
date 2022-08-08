using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFourthReq
{
    [Theory(DisplayName = "Deve transefir um valor com uma conta logada")]
    [InlineData(2, 3)]
    public void TestTransferSucess(int balance, int value)
    {        
        var instance = new Trybank();
        instance.Logged = true;
        instance.RegisterAccount(3, 3, 3);
        instance.RegisterAccount(2, 2, 2);
        instance.loggedUser = 0;
        instance.Bank[0, 3] = 5;
        instance.Transfer(2, balance, value);
        instance.Bank[1, 3].Should().Be(3);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestTransferWithoutLogin(int value)
    {        
        var instance = new Trybank();
        instance.Logged = false;
        Action act = () => instance.Transfer(0, 0, value);
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve lançar uma exceção de saldo insuficiente")]
    [InlineData(0, 10)]
    public void TestTransferWithoutBalance(int balance, int value)
    {        
        var instance = new Trybank();
        instance.Logged = true;
        instance.RegisterAccount(3, 3, 3);
        instance.RegisterAccount(2, 2, 2);
        instance.loggedUser = 0;
        Action act = () => instance.Transfer(0, balance, value);
        act.Should().Throw<InvalidOperationException>().WithMessage("Saldo insuficiente");
    }
}
