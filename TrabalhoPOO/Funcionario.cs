public class Funcionario
{
  public string nome { get; private set; }
  public string cpf { get; private set; }
  public string email { get; private set; }

  //construtor
  public Funcionario(string nome, string cpf, string email)
  {
    this.nome = nome;
    this.cpf = cpf;
    this.email = email;
  }
}
