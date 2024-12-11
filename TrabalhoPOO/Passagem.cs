public class Passagem : ICancelavel, ILog
{
    private List<VooProgramado> voosProgramados;
    private List<CartaoEmbarque> cartoesEmbarque;
    private TipoTarifa tipoTarifa;
    private Passageiro passageiro;
    private int numeroBagagens;
    private Moeda moeda;
    private double valorTotal;
    private static double TAXAFIXA = 0.10;
    private StatusPassagem statusPassagem;
    private Dictionary<VooProgramado, string> assentosReservados;
    public Passagem(List<VooProgramado> voosProgramados, TipoTarifa tipoTarifa, Passageiro passageiro, int numeroBagagens, Moeda moeda, double valorTotal)
    {
        this.voosProgramados = voosProgramados;
        this.tipoTarifa = tipoTarifa;
        this.passageiro = passageiro;
        this.numeroBagagens = numeroBagagens;
        this.moeda = moeda;
        this.valorTotal = valorTotal;
        this.statusPassagem = StatusPassagem.Adquirida;
        this.assentosReservados = new Dictionary<VooProgramado, string>();
        this.cartoesEmbarque = new List<CartaoEmbarque>();
        RegistrarLog($"Passagem do passageiro {passageiro.getNome()} criada.");
    }

    public double CalcularRemuneracao()
    {
        return this.valorTotal * Passagem.TAXAFIXA / 100;
    }

    public void Cancelar()
    {
        statusPassagem = StatusPassagem.Cancelada;
        foreach (var voo in voosProgramados)
        {
            voo.Cancelar();
            RegistrarLog($"Cancelamento de todos os voos associados á passagem do passageiro {passageiro.getNome()}");
        }
        RegistrarLog($"Cancelamento da passagem do passageiro {passageiro.getNome()}");
    }

    public void RealizarCheckIn() {
        this.statusPassagem = StatusPassagem.CheckinRealizado;
        RegistrarLog($"Checkin Realizado - Status da passagem: {this.statusPassagem}");
    }

    public void RealizarEmbarque(){
        this.statusPassagem = StatusPassagem.EmbarqueRealizado;
        RegistrarLog($"Embarque realizado - Status da passagem: {this.statusPassagem}");
    }

    public void RegistrarNoShow(){
        this.statusPassagem = StatusPassagem.NoShow;
        RegistrarLog($"Embarque não realizado - Status da passagem: {this.statusPassagem}");
    }

    public List<VooProgramado> GetVoosProgramados() => voosProgramados;
    public StatusPassagem GetStatusPassagem() => statusPassagem;
    public StatusPassagem SetStatusPassagem(StatusPassagem status) => this.statusPassagem = status;
    public TipoTarifa GetTipoTarifa() => this.tipoTarifa;
    public Passageiro GetPassageiro() => this.passageiro; 
    public int getNumeroBagagens() => numeroBagagens;
    public Moeda GetMoeda() => moeda;
    public double getValorTotal() => valorTotal;

    public void ReservarAssento(VooProgramado vooProgramado, string assento)
    {
        if (vooProgramado.ReservarAssento(assento))
        {
            assentosReservados[vooProgramado] = assento;
            Console.WriteLine($"Assento {assento} reservado no voo programado {vooProgramado.GetVoo().getCodigoVoo()}");
        }
        else
        {
            Console.WriteLine($"Assento {assento} não está disponível no voo programado {vooProgramado.GetVoo().getCodigoVoo()}");
        }
    }

    public void VerificarNoShowEmbarque()
    {
        if (statusPassagem != StatusPassagem.Cancelada && statusPassagem != StatusPassagem.EmbarqueRealizado && statusPassagem != StatusPassagem.NoShow)
        {
            bool vooPartiu = true;

            foreach (var vooProg in voosProgramados)
            {
                DateTime dataHoraAtual = DateTime.Now;
                if (dataHoraAtual >= vooProg.GetDataHoraPartida())
                {
                    continue;
                }
                else
                {
                    vooPartiu = false;
                    break;
                }
            }

            if (vooPartiu)
            {
                RegistrarNoShow();
                Console.WriteLine($"Passageiro {passageiro.getNome()} não embarcou e foi marcado como NO SHOW.");
            }
            else
            {
                Console.WriteLine($"Ainda há voos que não partiram para a passagem do passageiro {passageiro.getNome()}.");
            }
        }
    }

    public Dictionary<VooProgramado, string> GetAssentosReservados() => assentosReservados;
    public void AdicionarCartaoEmbarque(CartaoEmbarque cartao) => this.cartoesEmbarque.Add(cartao);
    public List<CartaoEmbarque> GetCartoesEmbarque() => this.cartoesEmbarque;

    public void RegistrarLog(string operacao) {
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
