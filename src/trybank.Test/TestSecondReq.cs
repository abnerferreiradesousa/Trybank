using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestSecondReq
{
    [Theory(DisplayName = "Deve logar em uma conta!")]
    [InlineData(0, 0, 0)]
    public void TestLoginSucess(int number, int agency, int pass)
    {        
        // throw new NotImplementedException();   

        var instance = new Trybank();
        instance.Login(number, agency, pass);
        instance.Logged.Should().Be(true);
        instance.loggedUser.Should().Be(49);
    }

    [Theory(DisplayName = "Deve retornar exceção ao tentar logar em conta já logada")]
    [InlineData(0, 0, 0)]
    public void TestLoginExceptionLogged(int number, int agency, int pass)
    {      
        // throw new NotImplementedException();   

        var instance = new Trybank();
        instance.Logged = true;
        Action act = () => instance.Login(number, agency, pass);
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário já está logado");
    }

    [Theory(DisplayName = "Deve retornar exceção ao errar a senha")]
    [InlineData(0, 2, 1)]
    public void TestLoginExceptionWrongPass(int number, int agency, int pass)
    {        
        // throw new NotImplementedException();   

        var instance = new Trybank();
        instance.RegisterAccount(number, agency, pass);
        Action act = () => instance.Login(number, agency, 23);
        act.Should().Throw<ArgumentException>().WithMessage("Senha incorreta");

    }

    [Theory(DisplayName = "Deve retornar exceção ao digitar conta que não existe")]
    [InlineData(1, 0, 0)]
    public void TestLoginExceptionNotFounded(int number, int agency, int pass)
    {        
        // throw new NotImplementedException();   

        var instance = new Trybank();
        Action act = () => instance.Login(number, agency, pass);
        act.Should().Throw<ArgumentException>().WithMessage("Agência + Conta não encontrada");
    }

    [Theory(DisplayName = "Deve sair de uma conta!")]
    [InlineData(0, 0, 0)]
    public void TestLogoutSucess(int number, int agency, int pass)
    {   
        // throw new NotImplementedException();   

        var instance = new Trybank();
        instance.Login(number, agency, pass);
        instance.Logout();
        instance.Logged.Should().Be(false);
        instance.loggedUser.Should().Be(-99);
    }

    [Theory(DisplayName = "Deve retornar exceção ao sair quando não está logado")]
    [InlineData(1, 1, 1)]
    public void TestLogoutExceptionNotLogged(int number, int agency, int pass)
    {        
        // throw new NotImplementedException();   

        var instance = new Trybank();
        instance.RegisterAccount(number, agency, pass);
        Action act = () => instance.Logout();
        act.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

}
