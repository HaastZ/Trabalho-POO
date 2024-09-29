public class CompanhiaAerea
{
    private string nome;
    private string codigo;
    private string razaoSocial;
    private string cnpj;
    private double valorPrimeiraBagagem;
    private double valorBagagemAdicional;
    public CompanhiaAerea(string nome, string codigo, string razao, string cnpj, double valorPrimeiraBagagem, double valorBagagemAdicional) 
    {
        this.nome = nome;
        this.codigo = codigo;
        this.razaoSocial = razao;
        this.cnpj = cnpj;
        this.valorPrimeiraBagagem = valorPrimeiraBagagem;
        this.valorBagagemAdicional = valorBagagemAdicional;
    }

    public string getNome() 
    {
        return this.nome;
    }

    public string getCodigo() 
    {
        return this.codigo;
    }

    public string getRazaoSocial() 
    {
        return this.razaoSocial;
    }

    public string getCnpj() 
    {
        return this.cnpj;
    }

    public double getValorPrimeraBagagem() 
    {
        return this.valorPrimeiraBagagem;
    }

    public double getValorBagagemAdicional() 
    {
        return valorBagagemAdicional;
    }
}