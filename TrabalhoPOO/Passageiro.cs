public class Passageiro : IPassageiroVIP
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
    }

    public void AdicionarPassagem(Passagem passagem)
    {
        Passagens.Add(passagem);
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
    }

    public void AlterarVooSemCusto(DateTime novaDataVoo)
    {
        Console.WriteLine($"Alteração de voo sem custo para nova data: {novaDataVoo}");
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
}