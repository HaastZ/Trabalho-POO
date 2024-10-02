public class Usuario
{
    private string login;
    private string senha;
    private Funcionario funcionario;
    public Usuario(Funcionario funcionario, string login, string senha) 
    {
        this.funcionario = funcionario;
        this.login = login;
        this.senha = senha;
    }

    public string getLogin () 
    {
        return this.login;
    }

    public string getSenha() 
    {
        return this.senha;
    }

    public Funcionario getFuncionario() 
    {
        return this.funcionario;
    }
}