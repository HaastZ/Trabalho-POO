
public class Voo : ILog
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
    public TimeSpan TempoViagem { get; set; }
    public double VelocidadeMedia { get; set; }
    public DateTime HorarioPrevistoChegada { get; set; }

    public Voo(Aeroporto origem, Aeroporto destino, DateTime dataHoraVoo, string codigoVoo, CompanhiaAerea companhiaAerea, TipoTarifa tipoTarifa, Moeda moeda, double velocidadeMedia)
    {
        this.aeroportoOrigem = origem;
        this.aeroportoDestino = destino;
        this.dataHoraVoo = dataHoraVoo;
        this.codigoVoo = codigoVoo;
        this.companhiaAerea = companhiaAerea;
        this.tipoTarifa = tipoTarifa;
        this.moeda = moeda;
        VelocidadeMedia = velocidadeMedia;
        TempoViagem = CalcularTempoViagem();
        HorarioPrevistoChegada = CalcularHorarioPrevistoChegada();
        RegistrarLog($"Criação do voo {this.codigoVoo}");
    }
    public Voo(Aeroporto origem, Aeroporto destino, DateTime dataHoraVoo, string codigoVoo, CompanhiaAerea companhiaAerea, TipoTarifa tipoTarifa, Moeda moeda, List<string> frequenciaSemanal, string horaPartida, string duracao, double velocidadeMedia)
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
        VelocidadeMedia = velocidadeMedia;
        TempoViagem = CalcularTempoViagem();
        HorarioPrevistoChegada = CalcularHorarioPrevistoChegada();
        RegistrarLog($"Criação do voo {this.codigoVoo}");
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

    private double CalculaDistanciaEntreAeroportos()
    {
        return 110.57 * Math.Sqrt(Math.Pow(aeroportoDestino.Longitude - aeroportoOrigem.Longitude, 2) + Math.Pow(aeroportoDestino.Latitude - aeroportoOrigem.Latitude, 2));
    }
    public TimeSpan CalcularTempoViagem()
    {
        double distancia = CalculaDistanciaEntreAeroportos();
        double tempo = distancia / VelocidadeMedia;
        int horas = (int)tempo; // A quantidade de horas é a parte inteira do número tempo;
        tempo = tempo - horas; // Agora vamos olhar apenas a parte decimal
        int minutos = (int)(tempo * 60); // Os minutos são a parte decimal multiplicada por 60
        return new TimeSpan(horas, minutos, 0);  // Novo TimeSpan com as horas e os minutos e 0 segundos;        
    }
    public DateTime CalcularHorarioPrevistoChegada()
    {
        return dataHoraVoo.Add(TempoViagem);
    }
    public void RegistrarLog(string operacao)
    {
        try
        {
            string mensagem = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {operacao}";
            File.AppendAllText(EncontrarArquivo.Localizar(), mensagem + Environment.NewLine);
        }
        catch (Exception e)
        {
            throw new Exception($"Ocorreu um erro ao registrar no log: {e}");
            throw;
        }
    }



}