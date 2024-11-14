public class Aeroporto
{
    private string nome;
    private string sigla;
    private string cidade;
    private string estado;
    private string pais;

    public Aeroporto(string nome, string sigla, string cidade, string estado, string pais)
    {
        this.nome = nome;
        this.sigla = sigla;
        this.cidade = cidade;
        this.estado = estado;
        this.pais = pais;
    }

    public string getNome() => this.nome;
    public string getSigla() => this.sigla;
    public string getCidade() => this.cidade;
    public string getEstado() => this.estado;
    public string getPais() => this.pais;

}