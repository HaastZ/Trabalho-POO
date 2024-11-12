public class Voo
{
    private Aeroporto aeroportoOrigem;
    private Aeroporto aeroportoDestino;
    private DateTime dataHoraVoo;
    private string codigoVoo;
    private List<string> frequenciaSemanal;
    private string horaPartida;
    private string duracao;
    private CompanhiaAerea companhiaAerea;
    private TipoTarifa tipoTarifa; private Moeda moeda;
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
    public Voo(Aeroporto origem, Aeroporto destino, DateTime dataHoraVoo, string codigoVoo, CompanhiaAerea companhiaAerea, TipoTarifa tipoTarifa, Moeda moeda, List<string> frequenciaSemanal, string horaPartida, string duracao)
    {
        this.aeroportoOrigem = origem;
        this.aeroportoDestino = destino;
        this.dataHoraVoo = dataHoraVoo;
        this.codigoVoo = codigoVoo;
        this.companhiaAerea = companhiaAerea;
        this.tipoTarifa = tipoTarifa;
        this.moeda = moeda;
        this.frequenciaSemanal = frequenciaSemanal;
        this.horaPartida = horaPartida;
        this.duracao = duracao;
    }

    public List<string> getFrequenciaSemanal()
    {
        return frequenciaSemanal;
    }
    public string getHoraPartida()
    {
        return horaPartida;
    }
    public string getDuracao()
    {
        return duracao;
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
    public void setDataHoraVoo(DateTime dataHoraVoo)
    {
        this.dataHoraVoo = dataHoraVoo;
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
    public Voo Clonar()
    {
        return (Voo)MemberwiseClone();
    }
}