public class Moeda
{
    private string BRL;
    private string USD;
    public Moeda(string BRL, string USD) 
    {
        this.BRL = BRL;
        this.USD = USD;
    }

    public string getBRL() 
    {
        return this.BRL;
    }

    public string getUSD() 
    {
        return this.USD;
    }
}