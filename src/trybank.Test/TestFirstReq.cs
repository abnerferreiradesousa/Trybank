using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFirstReq
{
    [Theory(DisplayName = "Deve cadastrar contas com sucesso!")]
    [InlineData(1, 0, 0)]
    public void TestRegisterAccountSucess(int number, int agency, int pass)
    {       
        Trybank instance = new();
        instance.RegisterAccount(number, agency, pass);
        instance.Bank.Length.Should().Be(200); 
        // var instance = new Trybank();
        // instance.RegisterAccount(number, agency, pass);
        // instance.Bank[0, 0].Should().Be(1);
        // instance.Bank[0, 1].Should().Be(0);
        // instance.Bank[0, 2].Should().Be(0);
        // instance.Bank[0, 3].Should().Be(0);
    }

    [Theory(DisplayName = "Deve retornar ArgumentException ao cadastrar contas que já existem")]
    [InlineData(1, 1, 1)]
    // Mau feito...
    public void TestRegisterAccountException(int number, int agency, int pass)
    {     
        Trybank instance = new();
        instance.RegisterAccount(number, agency, pass);
        Action act = () => instance.RegisterAccount(number, agency, pass);
        act.Should().Throw<ArgumentException>().WithMessage("A conta já está sendo usada!");
        // var instance = new Trybank();
        // Action act = () => instance.RegisterAccount(number, agency, pass);
        // act.Should().Throw<ArgumentException>().WithMessage("A conta já está sendo usada!");
    }
}