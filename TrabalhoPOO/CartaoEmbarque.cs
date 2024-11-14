public class CartaoEmbarque
{
    private Passageiro passageiro;
    private VooProgramado vooProgramado;
    private string assento;
    private DateTime horarioEmbarque;

    public CartaoEmbarque(Passageiro passageiro, VooProgramado vooProgramado, string assento)
    {
        this.passageiro = passageiro;
        this.vooProgramado = vooProgramado;
        this.assento = assento;
        this.horarioEmbarque = vooProgramado.GetDataHoraPartida().AddMinutes(-40);
    }

    public override string ToString()
    {
        string cartao = "----------------------------------\n";
        cartao += $"Nome: {passageiro.getNome()} {passageiro.GetSobrenome()}\n";
        cartao += $"Origem: {vooProgramado.GetVoo().getAeroportoOrigem().getNome()}\n";
        cartao += $"Destino: {vooProgramado.GetVoo().getAeroportoDestino().getNome()}\n";
        cartao += $"Horário de embarque: {horarioEmbarque}\n";
        cartao += $"Horário da viagem: {vooProgramado.GetDataHoraPartida()}\n";
        cartao += $"Assento: {assento}\n";
        cartao += "----------------------------------";
        return cartao;
    }
}
