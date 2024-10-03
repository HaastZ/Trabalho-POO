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
            Funcionario temp = new Funcionario(nome, cpf, email);
            system.CadastrarFuncionario(temp);
            break;
        case 2:
            do
            {
                Console.WriteLine("Digite o nome do funcionário");
                nome = Console.ReadLine();
                temp = system.BuscarFuncionario(nome);
                if (temp == null) Console.WriteLine("Funcionário não consta no cadastro");
            } while (temp == null);
            Console.WriteLine("Digite o login");
            string login = Console.ReadLine();
            Console.WriteLine("Digite a senha");
            string senha = Console.ReadLine();
            Usuario user = new Usuario(temp,login,senha);
            break;
    }
} while (opt != 0);