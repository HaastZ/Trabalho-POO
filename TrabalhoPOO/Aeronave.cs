public class Aeronave
{
    private int capacidadePassageiros;
    private double capacidadeCarga;
    private int numeroFileiras;
    private int assentosPorFileira;

    public Aeronave(int capacidadePassageiros, double capacidadeCarga, int numeroFileiras, int assentosPorFileira)
    {
        this.capacidadePassageiros = capacidadePassageiros;
        this.capacidadeCarga = capacidadeCarga;
        this.numeroFileiras = numeroFileiras;
        this.assentosPorFileira = assentosPorFileira;
    }

    public int GetCapacidadePassageiros()
    {
        return capacidadePassageiros;
    }

    public double GetCapacidadeCarga()
    {
        return capacidadeCarga;
    }

    public int GetNumeroFileiras()
    {
        return numeroFileiras;
    }

    public int GetAssentosPorFileira()
    {
        return assentosPorFileira;
    }
}
