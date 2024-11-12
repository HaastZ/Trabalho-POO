using TrabalhoPOO;
public interface IPassageiroVIP
{
    void CancelarVooSemCusto(ICancelavel voo);
    void AlterarVooSemCusto(DateTime novaDataVoo);
    double CalcularFranquiaBagagem(double valorBaseFranquia);
}