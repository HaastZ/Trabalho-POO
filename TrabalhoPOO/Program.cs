// See https://aka.ms/new-console-template for more information
using TrabalhoPOO;
internal class Program
{
    private static void Main(string[] args)
    {
        SistemaAgenciaViagens system = new SistemaAgenciaViagens();
        int opt = 0;

        // Instanciando os objetos para teste
        Funcionario Vinicius = new Funcionario("Vinicius", "123.123.123-123", "email@email.com");
        Funcionario Lucas = new Funcionario("Lucas", "123.123.123-123", "lucas@email.com");
        Aeroporto aeroporto1 = new Aeroporto("Aeroporto Internacional de São Paulo", "GRU", "São Paulo", "SP", "Brasil");
        Aeroporto aeroporto2 = new Aeroporto("Aeroporto Internacional John F. Kennedy", "JFK", "Nova York", "NY", "Estados Unidos");
        DateTime dataIda = new DateTime(2024, 05, 07, 14, 30, 00);
        TipoTarifa tarifa = new TipoTarifa(10, 20, 30);
        Moeda moeda = new Moeda("BRL", 1000);
        CompanhiaAerea companhia = new CompanhiaAerea("Companhia Aérea GOL", "GOL", "GOL Linhas Aéreas S/A", "00.000.000/0001-00", 50.0, 80.0);
        List<string> frequenciaSemanal = ["segunda", "quarta", "sexta"];
        Voo voo = new Voo(aeroporto1, aeroporto2, dataIda, "1234567", companhia, tarifa, moeda, frequenciaSemanal, "10:30", "10:00");
        TipoDocumento tipoDocumento = new TipoDocumento("MG-123-123-123", "123.123.123-123", "12345678");
        Passageiro passageiro = new Passageiro("Vinicius", "Almeida", tipoDocumento, "12345");
        Aeronave aeronave = new Aeronave();
        VooProgramado vooProgramado = new VooProgramado(voo, dataIda, aeronave);
        system.InstanciaVoosPorDiaDaSemana(voo);
        Passagem passagem = new Passagem(system.GetVoosProgramados(), tarifa, passageiro, 4, moeda, 4000);

        Console.WriteLine(passagem.GetPassageiro());
        do
        {
            Console.WriteLine("\n-------MENU-------\n");
            Console.WriteLine("1)Cadastrar Funcionário");
            Console.WriteLine("2)Cadastrar Usuário");
            Console.WriteLine("3)Cadastrar Companhia Aérea");
            Console.WriteLine("4)Cadastrar Aeroporto");
            Console.WriteLine("5)Cadastrar Voo");
            Console.WriteLine("6)Cadastrar Passagem");
            Console.WriteLine("7)Buscar Voos por Data de Ida e Volta");
            Console.WriteLine("8)Buscar Voos com Conexão");
            Console.WriteLine("9)Buscar Passagens dos Passageiros");
            Console.WriteLine("10)Cancelar Voo");
            Console.WriteLine("11)Visualizar Bilhete");
            Console.WriteLine("0)Sair\n");
            opt = int.Parse(Console.ReadLine());

            switch (opt)
            {
                case 1: //Cadastro de Funcionário
                    {
                        Console.WriteLine("\nCadastro de Funcionario");
                        system.CadastrarFuncionario(Vinicius);
                        system.CadastrarFuncionario(Lucas);

                        // Listagem de Funcionários Cadastrados
                        Console.WriteLine("\nFuncionarios Cadastrados:\n");
                        foreach (var funcionario in system.GetFuncionarios())
                        {
                            Console.WriteLine($"Nome: {funcionario.getNome()}, CPF: {funcionario.getCPF()}, Email: {funcionario.getEmail()}");
                        }
                        break;
                    }

                case 2: // Cadastro Funcionario (na aplicação, como um usuário)
                    {
                        Console.WriteLine("\nCadastro de Usuarios de funcionarios");
                        Usuario vinicius = new Usuario(Vinicius, "vinicius.login", "senha123");
                        Usuario lucas = new Usuario(Lucas, "lucas.login", "lucas123");
                        system.CadastrarUsuario(vinicius);
                        system.CadastrarUsuario(lucas);

                        //Listagem de Usuarios Cadastrados
                        Console.WriteLine("\nUsuarios Cadastrados:\n");
                        foreach (var usuario in system.GetUsuarios())
                        {
                            Console.WriteLine($"Usuario de: {usuario.getFuncionario().getNome()}: Login: {usuario.getLogin()}, Senha: {usuario.getSenha()}");
                        }
                        break;
                    }

                case 3: // Cadastro de Companhias Aéreas
                    {
                        Console.WriteLine("\nCadastro de CompanhiaAerea");
                        system.CadastrarCompanhia(companhia);

                        // Listagem de Companhias Cadastradas
                        Console.WriteLine("\nCompanhias Cadastradas:\n");
                        foreach (var companhias in system.GetCompanhias())
                        {
                            Console.WriteLine($"Nome: {companhias.getNome()}, Codigo: {companhias.getCodigo()}, RazaoSocial: {companhias.getRazaoSocial()}, CNPJ: {companhias.getCnpj()}, Valor da Primeira Bagagem: {companhias.getValorPrimeraBagagem()}, Bagagens Adicionais: {companhias.getValorBagagemAdicional()}");
                        }
                        break;
                    }

                case 4:// Cadastro de Aeroportos
                    {
                        Console.WriteLine("\nCadastro de Aeroporto");
                        system.CadastrarAeroporto(aeroporto1);
                        system.CadastrarAeroporto(aeroporto2);


                        // Aeroportos Cadastrados
                        Console.WriteLine("\nAeroportos Cadastrados:\n");
                        foreach (var aeroporto in system.GetAeroportos())
                        {
                            Console.WriteLine($"Nome: {aeroporto.getNome()}");
                        }
                        break;
                    }

                case 5:// Cadastro de Voos
                    {
                        Console.WriteLine("\nCadastro de Voos");
                        system.CadastrarVoo(voo);

                        // Voos Cadastrados
                        Console.WriteLine("\nVoos cadastrados:\n");
                        foreach (var voos in system.GetVoos())
                        {
                            Console.WriteLine($"Aeroporto de origem: {voos.getAeroportoOrigem().getNome()}, Aeroporto de destino: {voos.getAeroportoDestino().getNome()}, Data de ida: {voos.getDataHoraVoo()}, Tipo da Tarifa: {voos.GetTipoTarifa().getTarifaBasica()}, moeda do voo: {voos.getMoeda().GetTipoMoeda()}");
                        }
                        break;
                    }

                case 6:// Cadastro de Passagens
                    {
                        Console.WriteLine("\nCadastro de Passagens");
                        system.CadastrarPassagem(passagem);


                        // Passagens Cadastradas
                        Console.WriteLine("\nPassagens Cadastradas:\n");
                        foreach (var pass in system.GetPassagens())
                        {
                            Console.Write($"Passagem de: {pass.GetPassageiro().getNome()}, Voos da passagem: ");
                            var voos = pass.GetVooProgramado();
                            if (voos != null && voos.Count > 0)
                            {
                                foreach (var Voo in voos)
                                {
                                    Console.Write($"{Voo.GetVoo()} ");
                                }
                            }
                            else
                            {
                                Console.Write("Nenhum voo programado para esta passagem");
                            }
                            Console.WriteLine($", Tipo da tarifa: {pass.GetTipoTarifa().getTarifaBasica()}, " + $"Numero de bagagens: {pass.getNumeroBagagens()}, " +
                            $"Moeda da passagem: {pass.GetMoeda().GetTipoMoeda()}, " +
                            $"Valor total: {pass.getValorTotal()}");
                        }
                        break;
                    }

                case 7:// Busca de Voos
                    {
                        Console.WriteLine("\nBuscando um voo por data de ida e data de volta\n");
                        DateTime dataVolta = new DateTime(2024, 09, 10, 20, 00, 00);
                        List<Voo> voosEncontrados = system.BuscarVoos(aeroporto1, aeroporto2, dataIda, dataVolta);
                        foreach (var v in voosEncontrados)
                        {
                            Console.WriteLine($"Voos encontrados: \n{v.getAeroportoOrigem().getNome()} para {v.getAeroportoDestino().getNome()} \nPela: {v.getCompanhiaAerea().getNome()}\ndata de ida: ${dataIda}, data de volta: ${dataVolta}");
                        }
                        break;
                    }

                case 8:// Busca Voo com Conexão
                    {
                        Console.WriteLine("\nBuscando voo com conexão:\n");
                        List<Voo> voosComConexao = system.BuscarVoosComConexao(aeroporto1, aeroporto2, dataIda);
                        if (voosComConexao.Count == 0)
                        {
                            Console.WriteLine("Nenhum voo com conexão encontrado");
                        }
                        else
                        {
                            foreach (var voosConexao in voosComConexao)
                            {
                                Console.WriteLine($"Conexão: {voosConexao.getAeroportoOrigem().getNome()} para {voosConexao.getAeroportoDestino().getNome()}, pela {voosConexao.getCompanhiaAerea().getNome()}");
                            }
                        }
                        break;
                    }

                case 9:// Busca Passagens do Passageiro
                    {
                        Console.WriteLine("\nBuscando passagens dos passageiros\n");
                        List<Passagem> passagensDoPassageiro = system.BuscarPassagem(passageiro);
                        foreach (var passagensPassageiro in passagensDoPassageiro)
                        {
                            Console.WriteLine($"Passageiro: {passagensPassageiro.GetPassageiro().getNome()};");
                            foreach (var vooPassagem in passagensPassageiro.getVoos())
                            {
                                Console.WriteLine($"Passagens: {vooPassagem.getAeroportoOrigem().getNome()} para {vooPassagem.getAeroportoDestino().getNome()}, pela: {vooPassagem.getCompanhiaAerea().getNome()}");
                            }
                        }
                        break;
                    }
                    
                case 10:
                    {
                        Console.WriteLine("Cancelamento de Voo e Passagens");
                        Console.WriteLine($"Status do voo: {vooProgramado.GetStatusVoo()} (false - cancelado, true - ativo)");
                        system.Cancelar(vooProgramado);
                        Console.WriteLine($"Status do voo após cancelamento: {vooProgramado.GetStatusVoo()}");
                        Console.WriteLine($"Status da passagem: {passagem.GetStatusPassagem()} (false - cancelada, true - ativa)");
                        system.Cancelar(passagem);
                        Console.WriteLine($"Status da passagem após cancelamento: {passagem.GetStatusPassagem()}");
                        break;
                    }
                    
                case 11: // Exibir Bilhete
                    {
                        // Cria o bilhete para a passagem fornecida
                        Bilhete bilhete = new Bilhete(passagem);
                        Console.WriteLine(bilhete.ToString()); 
                        break;
                    }
              }
           }
        while (opt != 0);
    }
}
