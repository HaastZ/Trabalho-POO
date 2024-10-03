// See https://aka.ms/new-console-template for more information
using TrabalhoPOO;

SistemaAgenciaViagens system = new SistemaAgenciaViagens();
int opt = 0;
do
{
    Console.WriteLine("-------MENU-------");
    Console.WriteLine("1)Cadastrar Funcionário");
    Console.WriteLine("2)Cadastrar Usuário do funcionário");
    Console.WriteLine("3)Cadastrar Companhia Aérea");
    Console.WriteLine("4)Cadastrar Aeroporto");
    Console.WriteLine("5)Cadastrar Voo");
    Console.WriteLine("6)Cadastrar Passagem");
    Console.WriteLine("7)Buscar voos por data de ida e volta");
    Console.WriteLine("8)Buscar voos com conexão");
    Console.WriteLine("0)Sair");
    opt = int.Parse(Console.ReadLine());

    // Verifica se a entrada é válida
    if (!int.TryParse(Console.ReadLine(), out opt))
    {
        Console.WriteLine("Entrada inválida. Por favor, digite um número.");
        continue; // Volta ao menu
    }

    switch (opt)
    {
        case 1:
            Console.WriteLine("Digite o nome do funcionário:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o cpf do funcionário:");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite o e-mail do funcionário");
            string email = Console.ReadLine();
            Funcionario funcionariotemp = new Funcionario(nome, cpf, email);
            system.CadastrarFuncionario(funcionariotemp);
            break;
        case 2:
            do
            {
                Console.WriteLine("Digite o nome do funcionário");
                nome = Console.ReadLine();
                funcionariotemp = system.BuscarFuncionario(nome);
                if (funcionariotemp == null) Console.WriteLine("Funcionário não consta no cadastro");
            } while (funcionariotemp == null);
            Console.WriteLine("Digite o login");
            string login = Console.ReadLine();
            Console.WriteLine("Digite a senha");
            string senha = Console.ReadLine();
            Usuario user = new Usuario(funcionariotemp, login, senha);
            break;
        case 3:
            Console.WriteLine("Digite o nome da companhia:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o codigo da companhia:");
            string codigo = Console.ReadLine();
            Console.WriteLine("Digite a razão social da companhia:");
            string razao = Console.ReadLine();
            Console.WriteLine("Digite o CNPJ da companhia:");
            string cnpj = Console.ReadLine();
            Console.WriteLine("Digite o valor da primeira bagagem:");
            double valorPrimeirabagagem = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor da bagagem adicional:");
            double valorBagagemAdicional = double.Parse(Console.ReadLine());
            CompanhiaAerea comptemp = new CompanhiaAerea(nome, codigo, razao, cnpj, valorPrimeirabagagem, valorBagagemAdicional);
            system.CadastrarCompanhia(comptemp);
            break;
        case 4:
            Console.WriteLine("Digite o nome do Aeroporto");
            nome = Console.ReadLine();
            Console.WriteLine("Digite a sigla do Aeroporto:");
            string sigla = Console.ReadLine();
            Console.WriteLine("Digite a cidade do Aeroporto");
            string cidade = Console.ReadLine();
            Console.WriteLine("Digite o estado do Aeroporto");
            string estado = Console.ReadLine();
            Console.WriteLine("Digite o país do Aeroporto");
            string pais = Console.ReadLine();
            Aeroporto aerotemp = new Aeroporto(nome, sigla, cidade, estado, pais);
            system.CadastrarAeroporto(aerotemp);
            break;
        case 5:
            Console.WriteLine("Digite o nome do Aeroporto de Origem");
            nome = Console.ReadLine();
            Aeroporto origem = system.BuscaAeroportoPorNome(nome);
            Console.WriteLine("Digite o nome do Aeroporto de Destino");
            nome = Console.ReadLine();
            Aeroporto destino = system.BuscaAeroportoPorNome(nome);
            Console.WriteLine("Digite o dia do voo");
            int dia = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o mês do voo");
            int mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ano do voo");
            int ano = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a hora do voo");
            int hora = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite os minutos do voo");
            int min = int.Parse(Console.ReadLine());
            DateTime dataHoraVoo = new DateTime(ano, mes, dia, hora, min, 0);
            Console.WriteLine("Digite o codigo do voo");
            codigo = Console.ReadLine();
            comptemp = null;
            do
            {
                Console.WriteLine("Digite o codigo da companhia aérea");
                string codigocompanhia = Console.ReadLine();
                comptemp = system.BuscaCompanhiaPorCodigo(codigocompanhia);
                if (comptemp == null) Console.WriteLine("Companhia não consta no cadastro");
            } while(comptemp == null);
            Console.WriteLine("Digite o valor da tarifa básica");
            double valorTarifaBasica = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor da tarifa executiva");
            double valorTarifaExecutiva = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor da tarifa premium");
            double valorTarifaPremium = double.Parse(Console.ReadLine());
            TipoTarifa tarifatemp = new TipoTarifa(valorTarifaBasica, valorTarifaExecutiva,valorTarifaPremium);
            Console.WriteLine("Digite o tipo de moeda (BRL ou USD)");
            string tipomoeda = Console.ReadLine();
            Console.WriteLine("Digite o valor total do voo");
            double valor = double.Parse(Console.ReadLine());
            Moeda moedatemp = new Moeda(tipomoeda, valor);
            Voo vootemp = new Voo(origem, destino, dataHoraVoo, codigo, comptemp, tarifatemp, tarifatemp, tarifatemp, moedatemp);
            system.CadastrarVoo(vootemp);
            break;
    }
} while (opt != 0);
