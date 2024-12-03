public class Aeroporto : ILog
{
    private string nome;
    private string sigla;
    private string cidade;
    private string estado;
    private string pais;
    public double Latitude { get; set; }
    public double Longitude { get; set; }


    public Aeroporto(string nome, string sigla, string cidade, string estado, string pais, double latitude, double longitude)
    {
        this.nome = nome;
        this.sigla = sigla;
        this.cidade = cidade;
        this.estado = estado;
        this.pais = pais;      
        Latitude = latitude;
        Longitude = longitude;
        RegistrarLog($"Criação do aeroporto {this.nome} {this.sigla}");
    }

    public string getNome() => this.nome;
    public string getSigla() => this.sigla;
    public string getCidade() => this.cidade;
    public string getEstado() => this.estado;
    public string getPais() => this.pais;
    
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