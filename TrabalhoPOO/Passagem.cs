public class Passagem
{
    private List<Voo> voos;
    private TipoTarifa tipoTarifa;
    private Passageiro passageiro;
    private int numeroBagagens;
    private Moeda moeda;
    private double valorTotal;
    private static double TAXAFIXA = 10;
    public Passagem(List<Voo> voos, TipoTarifa tipoTarifa, Passageiro passageiro, int numeroBagagens, Moeda moeda, double valorTotal)
    {
        this.voos = voos;
        this.tipoTarifa = tipoTarifa;
        this.passageiro = passageiro;
        this.numeroBagagens = numeroBagagens;
        this.moeda = moeda;
        this.valorTotal = valorTotal;
    }

    public List<Voo> CalcularRemuneracao() 
    {
        return null;
    }

    public List<Voo> getVoos() 
    {
        return this.voos;
    }

    public TipoTarifa GetTipoTarifa() 
    {
        return this.tipoTarifa;
    }

    public Passageiro GetPassgeiro() 
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