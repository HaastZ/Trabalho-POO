public class Voo
{
    private Aeroporto aeroportoOrigem;
    private Aeroporto aeroportoDestino;
    private DateTime dataHoraVoo;
    private string codigoVoo;
    private List<string> frequenciaSemanal;

    private string duracao;
    private CompanhiaAerea companhiaAerea;
    private TipoTarifa tipoTarifa; 
    private Moeda moeda;
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
        this.duracao = duracao;
    }

    public List<string> getFrequenciaSemanal() => this.frequenciaSemanal;
    public string getDuracao() => this.duracao;
    public Aeroporto getAeroportoOrigem() => this.aeroportoOrigem;
    public Aeroporto getAeroportoDestino() => this.aeroportoDestino;
    public DateTime getDataHoraVoo() => this.dataHoraVoo;
    public void setDataHoraVoo(DateTime dataHoraVoo) => this.dataHoraVoo = dataHoraVoo;
    public string getCodigoVoo() => this.codigoVoo;
    public CompanhiaAerea getCompanhiaAerea() => this.companhiaAerea;
    public TipoTarifa GetTipoTarifa() => this.tipoTarifa;
    public Moeda getMoeda() => this.moeda;
    public Voo Clonar() => (Voo)MemberwiseClone();
    
}