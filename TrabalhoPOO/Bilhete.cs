public class Bilhete
{
    private Passagem passagem;
    public Bilhete(Passagem passagem)
    {
        this.passagem = passagem;
    }

    public override string ToString()
    {
        if (passagem == null || passagem.GetPassageiro() == null || passagem.getVoos() == null || passagem.getVoos().Count == 0)
        {
            return "Não é possível exibir o bilhete: dados incompletos.";
        }

        // Verificar se todos os voos têm origem e destino definidos
        foreach (var voo in passagem.getVoos())
        {
            if (voo.getAeroportoOrigem() == null || voo.getAeroportoDestino() == null)
            {
                return "Não é possível exibir o bilhete: alguns voos não têm origem ou destino definidos.";
            }
        }

        var passageiro = passagem.GetPassageiro();
        var bilhete = $"-----------------------------------------------------\n";
        bilhete += $"Nome: {passageiro.getNome()} {passageiro.getSobrenome()}     {passageiro.GetTipoDocumento()}: {passageiro.getNumeroDocumento()}\n\n";

        foreach (var voo in passagem.getVoos())
        {
            bilhete += $"Origem: {voo.getAeroportoOrigem().getNome()}   ";
            bilhete += $"Destino: {voo.getAeroportoDestino().getNome()}\n";
        }

        bilhete += $"-----------------------------------------------------";

        return bilhete;
    }
}
