public class Usuario
{
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
