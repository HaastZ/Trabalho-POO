public class Bilhete
{
    private Passagem passagem;
    public Bilhete(Passagem passagem)
    {
        this.passagem = passagem;
    }

    public override string ToString()
    {
        try
        {
            var passageiro = passagem.GetPassageiro();
            var bilhete = $"-----------------------------------------------------\n";
            bilhete += $"Nome do passageiro: {passageiro.getNome()} {passageiro.GetSobrenome()} | Tipo do Documento: {passageiro.GetTipoDocumento()}\n\n";
            bilhete += $"Origem: {passagem.GetVoosProgramados()[0].GetVoo().getAeroportoOrigem().getNome()}\n";
            bilhete += $"Destino: {passagem.GetVoosProgramados()[0].GetVoo().getAeroportoDestino().getNome()}\n";
            bilhete += $"Código do voo: {passagem.GetVoosProgramados()[0].GetVoo().getCodigoVoo()}\n";
            bilhete += $"Valor da passagem: {passagem.getValorTotal()} {passagem.GetMoeda()}\n";
            bilhete += $"Data da viagem: {passagem.GetVoosProgramados()[0].GetDataHoraPartida()}\n";
            bilhete += $"-----------------------------------------------------";

            return bilhete;
        }
        catch (Exception e)
        {
            throw new Exception($"Ocorreu algum erro ao gerar o bilhete, tente novamente: {e}");
        }
    }
}
