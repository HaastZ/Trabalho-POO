public class Passagem : ICancelavel
{
    private List<VooProgramado> voosProgramados;
    private TipoTarifa tipoTarifa;
    private Passageiro passageiro;
    private int numeroBagagens;
    private Moeda moeda;
    private double valorTotal;
    private static double TAXAFIXA = 0.10;
    private StatusPassagem statusPassagem;
    public bool Check_In { get; set; }
    private Dictionary<VooProgramado, string> assentosReservados;
    private List<StatusPassagem> historicoStatus;

    public Passagem(List<VooProgramado> voosProgramados, TipoTarifa tipoTarifa, Passageiro passageiro, int numeroBagagens, Moeda moeda, double valorTotal)
    {
        this.voosProgramados = voosProgramados;
        this.tipoTarifa = tipoTarifa;
        this.passageiro = passageiro;
        this.numeroBagagens = numeroBagagens;
        this.moeda = moeda;
        this.valorTotal = valorTotal;
        this.statusPassagem = StatusPassagem.Adquirida;

        this.historicoStatus = new List<StatusPassagem>();
        this.assentosReservados = new Dictionary<VooProgramado, string>();
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
            Console.WriteLine($"Passagem e todos os voos associados do passageiro {passageiro.getNome()} foram cancelados.");
    }

    public void RealizarCheckIn()
    {
        historicoStatus.Add(StatusPassagem.CheckinRealizado);
    }

    public void RealizarEmbarque()
    {
        historicoStatus.Add(StatusPassagem.EmbarqueRealizado);
    }

    public void RegistrarNoShow()
    {
        historicoStatus.Add(StatusPassagem.NoShow);
    }

    public List<StatusPassagem> GetHistoricoStatus()
    {
        return historicoStatus;
    }

    public List<VooProgramado> GetVoosProgramados()
    {
        return voosProgramados;
    }

    public StatusPassagem GetStatusPassagem()
    {
        return statusPassagem;
    }

    public TipoTarifa GetTipoTarifa()
    {
        return tipoTarifa;
    }

    public Passageiro GetPassageiro()
    {
        return passageiro;
    }

    public int getNumeroBagagens()
    {
        return numeroBagagens;
    }

    public Moeda GetMoeda()
    {
        return moeda;
    }

    public double getValorTotal()
    {
        return valorTotal;
    }

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

    public Dictionary<VooProgramado, string> GetAssentosReservados()
    {
        return assentosReservados;
    }
}
