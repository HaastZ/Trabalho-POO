public class Funcionario
{
    private string nome;
    private string cpf;
    private string email;
    public Funcionario(string nome, string cpf, string email) 
    {
        this.nome = nome;
        this.cpf = cpf;
        this.email = email;
    }

    public string getNome() => this.nome;
    public string getCPF() => this.cpf;
    public string getEmail() => this.email;

}