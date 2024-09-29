public class TipoTarifa
{
    private double tarifaBasica;
    private double tarifaExecutiva;
    private double tarifaPremium;
    public TipoTarifa(double tarifaBasica, double tarifaExecutiva, double tarifaPremium) 
    {
        this.tarifaBasica = tarifaBasica;
        this.tarifaExecutiva = tarifaExecutiva;
        this.tarifaPremium = tarifaPremium;
    }

    public double getTarifaBasica() 
    {
        return this.tarifaBasica;
    }

    public double getTarifaExecutiva() 
    {
        return this.tarifaExecutiva;
    }

    public double getTarifaPremium() 
    {
        return this.tarifaPremium;
    }
}