public class Usuario
{
<<<<<<< HEAD
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
=======
  public string login { get; private set; }
  public string senha { get; private set; }
  public Funcionario funcionario { get; private set; }

  // construtor
  public Usuario(Funcionario funcionario, string login, string senha)
  {
    this.funcionario = funcionario;
    this.login = login;
    this.senha = senha;
  }
}
>>>>>>> e6fa8904df4ef6923ec4d3dca348bd451ad93c03
