public class Passageiro
{
    private string nome;
    private string sobrenome;
    private TipoDocumento tipoDocumento;
    private string numeroDocumento;
    public Passageiro(string nome, string sobrenome, TipoDocumento tipoDocumento, string numeroDocumento) 
    {
        this.nome = nome;
        this.sobrenome = sobrenome;
        this.tipoDocumento = tipoDocumento;
        this.numeroDocumento = numeroDocumento;
    }

    public string getNome() 
    {
        return this.nome;
    }

    public string getSobrenome() 
    {
        return this.sobrenome;
    }

    public TipoDocumento GetTipoDocumento() 
    {
        return this.tipoDocumento;
    }

    public string getNumeroDocumento() 
    {
        return this.numeroDocumento;
    }
}