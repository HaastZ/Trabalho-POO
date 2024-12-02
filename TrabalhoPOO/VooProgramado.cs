public class VooProgramado : ICancelavel
{
    private Voo voo;
    private DateTime dataHoraPartida;
    private Aeronave aeronave;
    private StatusVoo statusVoo;
    private Dictionary<string, bool> assentosDisponiveis;

    public VooProgramado(Voo voo, DateTime dataHoraPartida, Aeronave aeronave)
    {
        this.voo = voo;
        this.dataHoraPartida = dataHoraPartida;
        this.aeronave = aeronave;
        this.statusVoo = StatusVoo.Ativo;
        this.assentosDisponiveis = new Dictionary<string, bool>();
        RegistrarLog("Criação de voo Programado");


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
        this.statusVoo = StatusVoo.Cancelado;
        Console.WriteLine($"Voo programado para {this.dataHoraPartida} foi cancelado");
        RegistrarLog($"Cancelamento de voo Programado. Status: {this.statusVoo}");
    }

    public StatusVoo GetStatusVoo() => this.statusVoo;
    public Voo GetVoo() => this.voo;
    public DateTime GetDataHoraPartida() => this.dataHoraPartida;
    public void SetDataHoraPartida(DateTime data) => this.dataHoraPartida = data;
    
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