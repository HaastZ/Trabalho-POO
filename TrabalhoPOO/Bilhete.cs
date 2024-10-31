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
            var sobrenome = passageiro.getSobrenome();
            var cpf = passageiro.getNumeroDocumento();

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine( $"Nome: {nome}{sobrenome}          CPF: {cpf}");

            foreach (var vooProgramado in passagem.GetVooProgramado())
            {
                var origem = vooProgramado.GetOrigem();
                var destino = vooProgramado.GetDestino(); 

                Console.WriteLine();
                Console.WriteLine( $"Origem: {origem}          Destino: {destino}");
            }

            Console.WriteLine("-------------------------------------------------");
        }
}
