public class Passageiro : IPassageiroVIP, ILog
{
    private string nome;
    private string sobrenome;
    private TipoDocumento tipoDocumento;
    private string numeroDocumento;
    private string email;
    private static int FranquiaPassagemGratuita = 0;
    private List<Passagem> Passagens = new List<Passagem>();
    public Passageiro(string nome, string sobrenome, TipoDocumento tipoDocumento, string numeroDocumento, string email) 
    {
        this.nome = nome;
        this.sobrenome = sobrenome;
        this.tipoDocumento = tipoDocumento;
        this.numeroDocumento = numeroDocumento;
        this.email = email;
        RegistrarLog($"Criação do passageiro {this.nome} {this.sobrenome}");
    }

    public void AdicionarPassagem(Passagem passagem)
    {
        Passagens.Add(passagem);
        RegistrarLog($"Passagem adicionada para o passageiro {this.nome}");
    }

    public List<VooProgramado> consultarHistoricoVoos()
    {
        List<VooProgramado> historicoVoos = new List<VooProgramado>();

        foreach (var passagem in Passagens)
        {
            if (passagem.GetPassageiro() == this)
            {
                foreach (var voo in passagem.GetVoosProgramados())
                {
                    if (!historicoVoos.Contains(voo))
                    {
                        historicoVoos.Add(voo);
                    }
                }
            }
        }

        return historicoVoos.OrderBy((v) => v.GetVoo().getDataHoraVoo()).ToList();
    }

    public void CancelarVooSemCusto(ICancelavel voo)
    {
        voo.Cancelar();
        Console.WriteLine($"O passageiro {this.nome} cancelou um voo sem custo adicional");
        RegistrarLog($"Voo sem custo adicional do passageiro {this.nome} cancelado.");
    }

    public void AlterarVooSemCusto(DateTime novaDataVoo)
    {
        foreach(var pass in Passagens) 
        {
            foreach(var voos in pass.GetVoosProgramados()) 
            {
                voos.SetDataHoraPartida(novaDataVoo);
            }
        }
        Console.WriteLine($"Alteração de voo sem custo para nova data: {novaDataVoo}");
        RegistrarLog($"Alteração da data do voo do passageiro {this.nome} para {novaDataVoo}");
    }

    public double CalcularFranquiaBagagem(double valorBaseFranquia)
    {
        return valorBaseFranquia / 2;
    }

    public int SetFranquiaPassagemGratuita(int franquia) => Passageiro.FranquiaPassagemGratuita = franquia;
    public int GetFranquiaPassagemGratuita() => Passageiro.FranquiaPassagemGratuita;
    public string getNome() => nome;
    public string GetSobrenome() => sobrenome;
    public TipoDocumento GetTipoDocumento() => tipoDocumento;
    public string GetNumeroDocumento() => numeroDocumento;
    public string GetEmail() => email;

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