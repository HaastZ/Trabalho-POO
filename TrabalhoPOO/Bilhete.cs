public class Bilhete
{
        private Passagem passagem;
        public Bilhete(Passagem passagem)
        {
            this.passagem = passagem;
        }

        public void CriarBilhete()
        {
            var passageiro = passagem.GetPassageiro();
            var nome = passageiro.getNome();
            var cpf = passageiro.getNumeroDocumento();

            Console.WriteLine("-------------------------------------");
            Console.WriteLine( $"Nome: {nome}          CPF: {cpf}");

            foreach (var vooProgramado in passagem.GetVooProgramado())
            {
                var origem = vooProgramado.GetOrigem();
                var destino = vooProgramado.GetDestino(); 

                Console.WriteLine();
                Console.WriteLine($"Origem: {origem}   Destino: {destino}");
            }

            Console.WriteLine("-------------------------------------");
        }
}
