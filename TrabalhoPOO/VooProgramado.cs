public class VooProgramado : ICancelavel
{
    private Voo voo;
    public DateTime dataHoraPartida;
    private Aeronave aeronave;
    private bool statusVoo;
    private Dictionary<string, bool> assentosDisponiveis;

    public VooProgramado(Voo voo, DateTime dataHoraPartida, Aeronave aeronave)
    {
        this.voo = voo;
        this.dataHoraPartida = dataHoraPartida;
        this.aeronave = aeronave;
        this.statusVoo = true;
        this.assentosDisponiveis = new Dictionary<string, bool>();

        int numeroFileiras = aeronave.GetNumeroFileiras();
        int assentosPorFileira = aeronave.GetAssentosPorFileira();

        for (int row = 1; row <= numeroFileiras; row++)
        {
            for (int seatNum = 0; seatNum < assentosPorFileira; seatNum++)
            {
                char seatLetter = (char)('A' + seatNum);
                string seat = row.ToString() + seatLetter;
                assentosDisponiveis[seat] = true;
            }
        }
    }

    public void Cancelar()
    {
        if (!statusVoo)
        {
            Console.WriteLine("O voo programado já está cancelado");
        }
        else
        {
            this.statusVoo = false;
            Console.WriteLine($"Voo programado para {this.dataHoraPartida} foi cancelado");
        }
    }

    public bool GetStatusVoo()
    {
        return this.statusVoo;
    }

    public Voo GetVoo()
    {
        return this.voo;
    }

    public bool IsAssentoDisponivel(string assento)
    {
        if (assentosDisponiveis.ContainsKey(assento))
        {
            return assentosDisponiveis[assento];
        }
        else
        {
            throw new Exception("Assento inválido.");
        }
    }

    public bool ReservarAssento(string assento)
    {
        if (assentosDisponiveis.ContainsKey(assento))
        {
            if (assentosDisponiveis[assento])
            {
                assentosDisponiveis[assento] = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            throw new Exception("Assento inválido.");
        }
    }

    public void LiberarAssento(string assento)
    {
        if (assentosDisponiveis.ContainsKey(assento))
        {
            assentosDisponiveis[assento] = true;
        }
        else
        {
            throw new Exception("Assento inválido.");
        }
    }

    public List<string> GetAssentosDisponiveis()
    {
        List<string> assentosLivres = new List<string>();
        foreach (var assento in assentosDisponiveis)
        {
            if (assento.Value)
            {
                assentosLivres.Add(assento.Key);
            }
        }
        return assentosLivres;
    }
}
