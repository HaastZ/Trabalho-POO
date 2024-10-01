public class TipoDocumento
{
    private string RG;
    private string CPF;
    private string passaporte;
    public TipoDocumento(string RG, string CPF, string passaporte) 
    {
        this.RG = RG;
        this.CPF = CPF;
        this.passaporte = passaporte;
    }

    public string getRG() 
    {
        return this.RG;
    }

    public string getCPF() 
    {
        return this.CPF;
    }

    public string getPassaporte() 
    {
        return this.passaporte;
    }
}