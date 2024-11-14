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

    public string getNome() => this.nome;
    public string getCodigo() => this.codigo;
    public string getRazaoSocial() => this.razaoSocial;
    public string getCnpj() => this.cnpj;
    public double getValorPrimeraBagagem() => this.valorPrimeiraBagagem;
    public double getValorBagagemAdicional() => valorBagagemAdicional;
}