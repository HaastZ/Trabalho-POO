public static class EncontrarArquivo
{
    public static string Localizar() 
    {
        try
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectRoot, "RegistroLog", "log.txt");
            return filePath;
        }
        catch (Exception e)
        {
            throw new Exception($"Arquivo não encontrado: {e}");
        }
    }
}