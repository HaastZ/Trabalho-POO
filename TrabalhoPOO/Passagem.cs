public class Passagem : ICancelavel
{
    private List<Voo> voos;
    private TipoTarifa tipoTarifa;
    private Passageiro passageiro;
    private int numeroBagagens;
    private Moeda moeda;
    private double valorTotal;
    private static double TAXAFIXA = 0.10;
    private List<VooProgramado> voosProgramados;
    private bool statusPassagem;
    public Passagem(List<VooProgramado> voosProgramados, TipoTarifa tipoTarifa, Passageiro passageiro, int numeroBagagens, Moeda moeda, double valorTotal)
    {
        this.voosProgramados = voosProgramados;
        this.tipoTarifa = tipoTarifa;
        this.passageiro = passageiro;
        this.numeroBagagens = numeroBagagens;
        this.moeda = moeda;
        this.valorTotal = valorTotal;
        this.statusPassagem = true;
    }

    public Passagem(List<Voo> voos, TipoTarifa tipoTarifa, Passageiro passageiro, int numeroBagagens)
    {
        this.voos = voos;
        this.tipoTarifa = tipoTarifa;
        this.passageiro = passageiro;
        this.numeroBagagens = numeroBagagens;
    }

    public double CalcularRemuneracao() 
    {
        double remuneracao;
        remuneracao = this.valorTotal * Passagem.TAXAFIXA / 100;
        return remuneracao;
    }

    public void Cancelar() 
    {
        if(!statusPassagem) 
        {
            Console.WriteLine("A passagem já foi cancelada");
        }
        else 
        {
            statusPassagem = false;
            Console.WriteLine($"Passagem de {passageiro.getNome()} foi cancelada");
        }
    }

    public List<VooProgramado> GetVooProgramado() 
    {
        return this.voosProgramados;
    }

    public bool GetStatusPassagem() 
    {
        return this.statusPassagem;
    }

    public List<Voo> getVoos() 
    {
        return this.voos;
    }

    public TipoTarifa GetTipoTarifa() 
    {
        return this.tipoTarifa;
    }

    public Passageiro GetPassageiro() 
    {
        return this.passageiro;
    }

    public int getNumeroBagagens() 
    {
        return this.numeroBagagens;
    }

    public Moeda GetMoeda() 
    {
        return this.moeda;
    }

    public double getValorTotal() 
    {
        return this.valorTotal;
    }
}