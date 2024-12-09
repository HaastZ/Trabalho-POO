public class Bilhete
{
    private Passagem passagem;
    public Bilhete(Passagem passagem)
    {
        this.passagem = passagem;
    }

    public override string ToString()
    {
        if (passagem == null || passagem.GetPassageiro() == null || passagem.GetVoosProgramados() == null || passagem.GetVoosProgramados().Count == 0)
        {   
            return "Não é possível exibir o bilhete: dados incompletos.";
        }
        foreach (var vooProg in passagem.GetVoosProgramados())
        {
            Voo voo = vooProg.GetVoo();
            if (voo.getAeroportoOrigem() == null || voo.getAeroportoDestino() == null)
            {
                return "Não é possível exibir o bilhete: alguns voos não têm origem ou destino definidos.";
            }
        }

        var passageiro = passagem.GetPassageiro();
        var bilhete = $"-----------------------------------------------------\n";
        bilhete += $"Nome: {passageiro.getNome()} {passageiro.GetSobrenome()} Tipo Documento: {passageiro.GetTipoDocumento()}\n\n";

        foreach (var vooProg in passagem.GetVoosProgramados())
        {
            Voo voo = vooProg.GetVoo();
            bilhete += $"Origem: {voo.getAeroportoOrigem().getNome()}   ";
            bilhete += $"Destino: {voo.getAeroportoDestino().getNome()}\n";
        }

        bilhete += $"-----------------------------------------------------";

        return bilhete;
    }
}
