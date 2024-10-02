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