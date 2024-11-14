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
    public bool Check_In {  get; set; }
    private Dictionary<VooProgramado, string> assentosReservados;
    public Passagem(List<VooProgramado> voosProgramados, TipoTarifa tipoTarifa, Passageiro passageiro, int numeroBagagens, Moeda moeda, double valorTotal)
    {
        this.voosProgramados = voosProgramados;
        this.tipoTarifa = tipoTarifa;
        this.passageiro = passageiro;
        this.numeroBagagens = numeroBagagens;
        this.moeda = moeda;
        this.valorTotal = valorTotal;
        this.statusPassagem = true;
        this.assentosReservados = new Dictionary<VooProgramado, string>();
    }

    public double CalcularRemuneracao()
    {
        double remuneracao;
        remuneracao = this.valorTotal * Passagem.TAXAFIXA / 100;
        return remuneracao;
    }

    public void Cancelar()
    {
        if (!statusPassagem)
        {
            Console.WriteLine("A passagem já foi cancelada");
        }
        else
        {
            this.statusPassagem = false;
            foreach (var voo in this.voosProgramados)
            {
                voo.Cancelar();
            }
            Console.WriteLine($"Passagem e todos os voos associados do passageiro {passageiro.getNome()} foram cancelados.");
        }
    }

    public List<VooProgramado> GetVoosProgramados()
    {
        return this.voosProgramados;
    }

    public bool GetStatusPassagem()
    {
        return this.statusPassagem;
    }

    public TipoTarifa GetTipoTarifa()
    {
        return this.tipoTarifa;
    }

    public Passageiro GetPassageiro()
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
