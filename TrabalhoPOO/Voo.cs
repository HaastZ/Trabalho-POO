public class Voo
{
    private Aeroporto aeroportoOrigem;
    private Aeroporto aeroportoDestino;
    private DateTime dataHoraVoo;
    private string codigoVoo;
    private CompanhiaAerea companhiaAerea;
    private TipoTarifa tipoTarifa;    private Moeda moeda;
    public Voo(Aeroporto origem, Aeroporto destino, DateTime dataHoraVoo, string codigoVoo, CompanhiaAerea companhiaAerea, TipoTarifa tipoTarifa, Moeda moeda) 
    {
        this.aeroportoOrigem = origem;
        this.aeroportoDestino = destino;
        this.dataHoraVoo = dataHoraVoo;
        this.codigoVoo = codigoVoo;
        this.companhiaAerea = companhiaAerea;
        this.tipoTarifa = tipoTarifa;
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

    public TipoTarifa GetTipoTarifa() 
    {
        return this.tipoTarifa;
    }

    public Moeda getMoeda() 
    {
        return this.moeda;
    }
}