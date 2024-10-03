// See https://aka.ms/new-console-template for more information
using TrabalhoPOO;

SistemaAgenciaViagens system = new SistemaAgenciaViagens();
int opt = 0;
do
{
    Console.WriteLine("-------MENU-------");
    Console.WriteLine("1)Cadastrar Funcionário");
    Console.WriteLine("2)Cadastrar Usuário");
    Console.WriteLine("3)Cadastrar Companhia Aérea");
    Console.WriteLine("4)Cadastrar Voo");
    Console.WriteLine("5)Cadastrar Passagem");
    Console.WriteLine("6)Buscar voos por data de ida e volta");
    Console.WriteLine("7)Buscar voos com conexão");
    Console.WriteLine("0)Sair");
    opt = int.Parse(Console.ReadLine());
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


    }
} while (opt != 0);