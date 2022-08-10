using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFirstReq
{
    [Theory(DisplayName = "Deve cadastrar contas com sucesso!")]
    [InlineData(1, 1, 1)]
    public void TestRegisterAccountSucess(int number, int agency, int pass)
    {       
        Trybank instance = new();
        instance.RegisterAccount(number, agency, pass);
        instance.Bank.Length.Should().Be(200); 
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
    }
}