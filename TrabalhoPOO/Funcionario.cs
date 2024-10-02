public class Funcionario
{
<<<<<<< HEAD
    private string nome;
    private string cpf;
    private string email;
    public Funcionario(string nome, string cpf, string email) 
    {
        this.nome = nome;
        this.cpf = cpf;
        this.email = email;
    }

    public string getNome() 
    {
        return this.nome;
    }

    public string getCPF() 
    {
        return this.cpf;
    }

    public string getEmail() 
    {
        return this.email;
    }
}
=======
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
>>>>>>> e6fa8904df4ef6923ec4d3dca348bd451ad93c03
