public class VooProgramado : ICancelavel
{
    private Voo voo;
    private DateTime dataHoraPartida;
    private Aeronave aeronave;
    private bool statusVoo;

    public VooProgramado(Voo voo, DateTime dataHoraPartida, Aeronave aeronave) 
    {
        this.voo = voo;
        this.dataHoraPartida = dataHoraPartida;
        this.aeronave = aeronave;
        this.statusVoo = true;
    }

    public void Cancelar() {
        if(!statusVoo) {
            Console.WriteLine("O voo programado já está cancelado");
        }
        else {
            statusVoo = false;
            Console.WriteLine($"Voo programado para {this.dataHoraPartida} foi cancelado");
        }
    }
}