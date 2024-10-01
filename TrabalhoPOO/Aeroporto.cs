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

    public string getNome()
    {
        return this.nome;
    }

    public string getSigla()
    {
        return this.sigla;
    }

    public string getCidade()
    {
        return this.cidade;
    }

    public string getEstado()
    {
        return this.estado;
    }

    public string getPais()
    {
        return this.pais;
    }
}