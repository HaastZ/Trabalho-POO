public class Passagem : ICancelavel
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
    public bool Check_In { get; set; }
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
        }
    }

    public void RealizarCheckIn() => this.statusPassagem = StatusPassagem.CheckinRealizado;
    public void RealizarEmbarque() => this.statusPassagem = StatusPassagem.EmbarqueRealizado;
    public void RegistrarNoShow() => this.statusPassagem = StatusPassagem.NoShow;
    public List<VooProgramado> GetVoosProgramados() => voosProgramados;
    public StatusPassagem GetStatusPassagem() => statusPassagem;
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

    public Dictionary<VooProgramado, string> GetAssentosReservados() => assentosReservados;
    public void AdicionarCartaoEmbarque(CartaoEmbarque cartao) => this.cartoesEmbarque.Add(cartao);
    public List<CartaoEmbarque> GetCartoesEmbarque() => this.cartoesEmbarque;
    

}
