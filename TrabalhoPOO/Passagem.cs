public class Passagem : ICancelavel
{
    private List<VooProgramado> voosProgramados;
    private TipoTarifa tipoTarifa;
    private Passageiro passageiro;
    private int numeroBagagens;
    private Moeda moeda;
    private double valorTotal;
    private static double TAXAFIXA = 0.10;
    private bool statusPassagem;
    public bool Check_In { get; set; }

    private List<RegistroStatus> historicoStatus;

    public Passagem(List<VooProgramado> voosProgramados, TipoTarifa tipoTarifa, Passageiro passageiro, int numeroBagagens, Moeda moeda, double valorTotal)
    {
        this.voosProgramados = voosProgramados;
        this.tipoTarifa = tipoTarifa;
        this.passageiro = passageiro;
        this.numeroBagagens = numeroBagagens;
        this.moeda = moeda;
        this.valorTotal = valorTotal;
        this.statusPassagem = true;

        this.historicoStatus = new List<RegistroStatus> { new RegistroStatus("Passagem adquirida") };
        this.assentosReservados = new Dictionary<VooProgramado, string>();
    }

    public double CalcularRemuneracao()
    {
        return this.valorTotal * Passagem.TAXAFIXA / 100;
    }

    public void Cancelar()
    {
        if (!statusPassagem)
        {
            Console.WriteLine("A passagem já foi cancelada");
        }
        else
        {
            statusPassagem = false;
            historicoStatus.Add(new RegistroStatus("Passagem cancelada"));

            foreach (var voo in voosProgramados)
            {
                voo.Cancelar();
            }
            Console.WriteLine($"Passagem e todos os voos associados do passageiro {passageiro.getNome()} foram cancelados.");
        }
    }

    public void RealizarCheckIn()
    {
        historicoStatus.Add(new RegistroStatus("Check-in realizado"));
    }

    public void RealizarEmbarque()
    {
        historicoStatus.Add(new RegistroStatus("Embarque realizado"));
    }

    public void RegistrarNoShow()
    {
        historicoStatus.Add(new RegistroStatus("No show"));
    }

    public List<RegistroStatus> GetHistoricoStatus()
    {
        return historicoStatus;
    }

    public List<VooProgramado> GetVoosProgramados()
    {
        return voosProgramados;
    }

    public bool GetStatusPassagem()
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
