public class Moeda
{
    private string tipoMoeda;
    private double valor;

    // Iniciador
    public Moeda(string tipoMoeda, double valor)
    {
        this.tipoMoeda = tipoMoeda;
        this.valor = valor;
    }

    // Método que "pega" a informação de qual tipo de moeda será usada no Voo
    public string GetTipoMoeda()
    {
        return this.tipoMoeda;
    }

    // Método que "pega" a informação do valor do voo
    public double GetValor()
    {
        return this.valor;
    }

    // Método de conversão de USD para BRL (ou vice-versa)
    public string ConverterMoeda(string moedaVoo)
    {
        double valorConvertido = 0; //Variável que armazena o valor do voo após converção
        double taxaConversaoBRLParaUSD = 5.45; // Considerando a taxa de conversão de 1 USD = 5,45 BRL

        if (this.tipoMoeda == "BRL")
        {
            valorConvertido = valor; // Se as moedas forem iguais, o valor é o mesmo
        }
        else if (this.tipoMoeda == "USD")
        {
            valorConvertido = valor/taxaConversaoBRLParaUSD; // Converter de real para dólar
        }
        else
        {
            throw new Exception("Conversão de moeda não suportada.\r\nNosso sistema ultiliza o real como base e apenas converte para Dolar em casos de Voos Internacionais! :)");
        }

        // Verifica moedaVoo e formata o valor como nos Exemplos: R$500,00 e US$100,00
        if (moedaVoo == "BRL")
        {
            return "R$" + valorConvertido.ToString("N2");
        }
        else if (moedaVoo == "USD")
        {
            return "US$" + valorConvertido.ToString("N2");
        }
        else
        {
            throw new Exception("Conversão de moeda não suportada.\r\nNosso sistema ultiliza o real como base e apenas converte para Dolar em casos de Voos Internacionais! :)");
        }
    }
}
