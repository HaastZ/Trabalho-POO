public class Aeronave
{
    private int IdAeronave;
    private int capacidadePassageiros;
    private double capacidadeCarga;
    private int numeroFileiras;
    private int assentosPorFileira;

    public Aeronave(int id, int capacidadePassageiros, double capacidadeCarga, int numeroFileiras, int assentosPorFileira)
    {
        this.IdAeronave = id;
        this.capacidadePassageiros = capacidadePassageiros;
        this.capacidadeCarga = capacidadeCarga;
        this.numeroFileiras = numeroFileiras;
        this.assentosPorFileira = assentosPorFileira;
    }

    public int GetCapacidadePassageiros() => capacidadePassageiros;
    public double GetCapacidadeCarga() => capacidadeCarga;
    public int GetNumeroFileiras() => numeroFileiras;
    public int GetAssentosPorFileira() => assentosPorFileira;

}
