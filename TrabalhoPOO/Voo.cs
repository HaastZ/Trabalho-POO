public class Voo
{
    private Aeroporto aeroportoOrigem;
    private Aeroporto aeroportoDestino;
    private DateTime dataHoraVoo;
    private string codigoVoo;
    private CompanhiaAerea companhiaAerea;
    private TipoTarifa valorTarifaBasica;
    private TipoTarifa valorTarifaExecutiva;
    private TipoTarifa valorTarifaPremium;
    private Moeda moeda;
    public Voo(Aeroporto origem, Aeroporto destino, DateTime dataHoraVoo, string codigoVoo, CompanhiaAerea companhiaAerea, TipoTarifa basica, TipoTarifa executiva, TipoTarifa premium, Moeda moeda) 
    {
        this.aeroportoOrigem = origem;
        this.aeroportoDestino = destino;
        this.dataHoraVoo = dataHoraVoo;
        this.codigoVoo = codigoVoo;
        this.companhiaAerea = companhiaAerea;
        this.valorTarifaBasica = basica;
        this.valorTarifaExecutiva = executiva;
        this.valorTarifaPremium = premium;
        this.moeda = moeda;
    }

    public Aeroporto getAeroportoOrigem() 
    {
        return this.aeroportoOrigem;
    }

    public Aeroporto getAeroportoDestino() 
    {
        return this.aeroportoDestino;
    }

    public DateTime getDataHoraVoo() 
    {
        return this.dataHoraVoo;
    }

    public string getCodigoVoo() 
    {
        return this.codigoVoo;
    }

    public CompanhiaAerea getCompanhiaAerea() 
    {
        return this.companhiaAerea;
    }

    public TipoTarifa getTarifaBasica() 
    {
        return this.valorTarifaBasica;
    }

    public TipoTarifa getTarifaExecutiva() 
    {
        return this.valorTarifaExecutiva;
    }

    public TipoTarifa getTarifaPremium() 
    {
        return this.valorTarifaPremium;
    }

    public Moeda getMoeda() 
    {
        return this.moeda;
    }

}