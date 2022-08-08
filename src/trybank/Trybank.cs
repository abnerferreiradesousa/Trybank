namespace trybank;

public class Trybank
{
    // public static void Main(string[] args)  
    // { 
        
    // }
    public bool Logged;
    public int loggedUser;
    
    //0 -> Número da conta
    //1 -> Agência
    //2 -> Senha
    //3 -> Saldo
    public int[,] Bank;
    public int registeredAccounts;
    private int maxAccounts = 50;
    public Trybank()
    {
        loggedUser = -99;
        registeredAccounts = 0;
        Logged = false;
        Bank = new int[maxAccounts, 4];
    }

    public void RegisterAccount(int number, int agency, int pass)
    {
        try 
        {
            for (int i = 0; i < Bank.GetLength(0); i++)
            {
                if(Bank[i, 0] == number && Bank[i, 1] == agency)
                {
                    throw new ArgumentException("A conta já está sendo usada!");
                }
            }

            Bank[registeredAccounts, 0] = number;
            Bank[registeredAccounts, 1] = agency;
            Bank[registeredAccounts, 2] = pass;
            Bank[registeredAccounts, 3] = 0;
            registeredAccounts++;

            Console.Write(Bank[0, 1]);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            throw;
        }
    }

    public void Login(int number, int agency, int pass)
    {
        try
        {
            if(Logged)
                throw new AccessViolationException("Usuário já está logado");

            for (int i = 0; i < Bank.GetLength(0); i += 1)
            {
                if(Bank[i, 0] == number && Bank[i, 1] == agency)
                {
                    if(Bank[i, 2] != pass)
                    {
                        throw new ArgumentException("Senha incorreta");
                    }
                    else 
                    {
                        Logged = true;
                        loggedUser = i;
                    }
                }
                else {
                    throw new ArgumentException("Agência + Conta não encontrada");
                }
            }
        }
        catch(ArgumentException ex)
        {
            Console.Write(ex.Message);
            throw ex;
        }
        
    }

    public void Logout()
    {
        try 
        {
            if(!Logged)
                throw new AccessViolationException("Usuário não está logado");

            Logged = false;
            loggedUser = -99;
        }
        catch(Exception ex)
        {
            Console.Write(ex.Message);
            throw;
        }

    }

    public int CheckBalance()
    {
        try
        {
            if(Logged)
                return Bank[loggedUser, 3];

            throw new AccessViolationException("Usuário não está logado");
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            throw;
        }
    }

    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        throw new NotImplementedException();
    }

    public void Deposit(int value)
    {
        try
        {
            if(Logged) 
            {
                Bank[loggedUser, 3] = Bank[loggedUser, 3] + value;
            }
            else {
                throw new AccessViolationException("Usuário não está logado");
            }
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            throw;
        }
    }

    public void Withdraw(int value)
    {
        try 
        {
            if(Logged)
            {
                int calc = Bank[loggedUser, 3] - value;
                if(calc >= 0) 
                    Bank[loggedUser, 3] = calc;
                else {
                   throw new InvalidOperationException("Saldo insuficiente");
                }
            }
            else {
                throw new AccessViolationException("Usuário não está logado");
            }  
        }
        catch (InvalidOperationException ex)
        {
            Console.Write(ex.Message);
            throw;
        }
        catch (AccessViolationException ex)
        {
            Console.Write(ex.Message);
            throw;
        }
    }
}
