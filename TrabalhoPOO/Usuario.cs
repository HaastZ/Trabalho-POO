public class Usuario : ILog
{
    private string login;
    private string senha;
    private Funcionario funcionario;
    public Usuario(Funcionario funcionario, string login, string senha) 
    {
        this.funcionario = funcionario;
        this.login = login;
        this.senha = senha;
        RegistrarLog($"Usuario do funcionario {funcionario.getNome()} criado.");
    }

    public string getLogin () => this.login;
    public string getSenha() => this.senha;
    public Funcionario getFuncionario() => this.funcionario;

    public void RegistrarLog(string operacao) {
        try
        {
            string mensagem = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {operacao}";
            File.AppendAllText(EncontrarArquivo.Localizar(), mensagem + Environment.NewLine);
        }
        catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao registrar no log: {e}");
            throw;
        }
    }
    
}