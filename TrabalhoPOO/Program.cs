// See https://aka.ms/new-console-template for more information
using TrabalhoPOO;
internal class Program
{
    public static void Main(string[] args)
    {
        SistemaAgenciaViagens system = new SistemaAgenciaViagens();
        int opt = 0;

        // Instanciando os objetos para teste
        Funcionario Vinicius = new Funcionario("Vinicius", "123.123.123-123", "email@email.com");
        Funcionario Lucas = new Funcionario("Lucas", "123.123.123-123", "lucas@email.com");
        Aeroporto aeroporto1 = new Aeroporto("Aeroporto Internacional de São Paulo", "GRU", "São Paulo", "SP", "Brasil");
        Aeroporto aeroporto2 = new Aeroporto("Aeroporto Internacional John F. Kennedy", "JFK", "Nova York", "NY", "Estados Unidos");
        Aeroporto aeroporto3 = new Aeroporto("Aeroporto Internacional de Belo Horizonte", "CNF", "Belo Horizonte", "MG", "Brasil");
        Aeroporto aeroporto4 = new Aeroporto("Aeroporto Internacional de Brasília", "BSB", "Brasília", "BSB", "Distrito Federal");
        DateTime dataIda = new DateTime(2024, 05, 07, 14, 30, 00);
        DateTime dataIdaVoo2 = new DateTime(2024, 10, 01, 19, 00, 00);
        CompanhiaAerea companhia = new CompanhiaAerea("Companhia Aérea GOL", "GOL", "GOL Linhas Aéreas S/A", "00.000.000/0001-00", 50.0, 80.0);
        List<string> frequenciaSemanal = ["segunda", "quarta", "sexta"];
        Voo voo = new Voo(aeroporto1, aeroporto2, dataIda, "1234567", companhia, TipoTarifa.Basica, Moeda.BRL, frequenciaSemanal, "10:30", "10:00");
        Voo voo2 = new Voo(aeroporto3, aeroporto4, dataIdaVoo2, "9876543", companhia, TipoTarifa.Executiva, Moeda.BRL);
        Passageiro passageiro1 = new Passageiro("Vinicius", "Almeida", TipoDocumento.CPF, "12345", "vinicius@email.com");
        Passageiro passageiro2 = new Passageiro("Lucas", "Bryan", TipoDocumento.CPF, "12345678", "lucas@gmail.com");
        Passageiro passageiro3 = new Passageiro("Artur", "Moreira", TipoDocumento.RG, "MG9123863", "artur@gmail.com");
        Passageiro passageiro4 = new Passageiro("Ricardo", "Alencar", TipoDocumento.CPF, "563725", "ricardo@gmail.com");
        Passageiro passageiro5 = new Passageiro("Gabriel", "Marinho", TipoDocumento.PASSAPORTE, "0129384", "gabriel@email.com");
        Passageiro passageiro6 = new Passageiro("Felipe", "Henrique", TipoDocumento.CPF, "8239412", "felipe@email.com");
        Passageiro passageiro7 = new Passageiro("Tarsis", "Augustus", TipoDocumento.RG, "MG98127263", "tarsis@email.com");
        Aeronave aeronave = new Aeronave(180, 2000.0, 30, 6);
        VooProgramado vooProgramado = new VooProgramado(voo, dataIda, aeronave);
        VooProgramado vooProgramado2 = new VooProgramado(voo2, dataIdaVoo2, aeronave);
        system.InstanciaVoosPorDiaDaSemana(voo);
        Passagem passagem = new Passagem(system.GetVoosProgramados(), TipoTarifa.Basica, passageiro1, 4, Moeda.BRL, 4000);

        foreach (var a in system.GetVoosProgramados())
        {
            Console.WriteLine(a.GetVoo().getAeroportoOrigem().getNome(), a.GetVoo().getAeroportoDestino().getNome(), a.GetDataHoraPartida());
        }

        do
        {
            Console.WriteLine("\n-------MENU-------\n");
            Console.WriteLine("1) Cadastrar Funcionário");
            Console.WriteLine("2) Cadastrar Usuário");
            Console.WriteLine("3) Cadastrar Companhia Aérea");
            Console.WriteLine("4) Cadastrar Aeroporto");
            Console.WriteLine("5) Cadastrar Voo");
            Console.WriteLine("6) Cadastrar Passagem");
            Console.WriteLine("7) Buscar Voos por Data de Ida e Volta");
            Console.WriteLine("8) Buscar Voos com Conexão");
            Console.WriteLine("9) Buscar Passagens dos Passageiros");
            Console.WriteLine("10) Cancelar Voo");
            Console.WriteLine("11) Visualizar Bilhete");
            Console.WriteLine("12) Reservar Assento em Passagem");
            Console.WriteLine("13) Ascender Passageiro para VIP");
            Console.WriteLine("14) Cancelar Voo do PassageiroVIP");
            Console.WriteLine("15) Alterar Voo do PassageiroVIP");
            Console.WriteLine("16) Visualizar Historico de voos dos Passageiros");
            Console.WriteLine("17) Realizar Check-in");
            Console.WriteLine("18) Registrar Embarque do passageiro");

            Console.WriteLine("0) Sair\n");
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
                            Console.WriteLine($"Aeroporto de origem: {voos.getAeroportoOrigem().getNome()}, Aeroporto de destino: {voos.getAeroportoDestino().getNome()}, Data de ida: {voos.getDataHoraVoo()}, Tipo da Tarifa: {voos.GetTipoTarifa()}, moeda do voo: {voos.getMoeda()}");
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
                            Console.Write($"Passagem de {pass.GetPassageiro().getNome()}, Voos da passagem: ");
                            var voos = pass.GetVoosProgramados();
                            if (voos != null && voos.Count > 0)
                            {
                                foreach (var Voo in voos)
                                {
                                    Console.Write($"{Voo.GetVoo().getAeroportoOrigem().getNome()} para {Voo.GetVoo().getAeroportoDestino().getNome()} ");
                                }
                            }
                            else
                            {
                                Console.Write("Nenhum voo programado para esta passagem");
                            }
                            Console.WriteLine($"\nTipo da tarifa: {pass.GetTipoTarifa()}, " + $"Numero de bagagens: {pass.getNumeroBagagens()}, " +
                            $"Moeda da passagem: {pass.GetMoeda()}, " +
                            $"Valor total: {pass.getValorTotal()}");
                            Console.WriteLine("");
                            Console.WriteLine($"Status da passagem do passageiro {pass.GetPassageiro().getNome()}: {pass.GetStatusPassagem()}");

                        }
                        break;
                    }

                case 7:// Busca de Voos
                    {
                        Console.WriteLine("\nBuscando um voo por data de ida e data de volta\n");
                        DateTime dataVolta = new DateTime(2024, 09, 10, 20, 00, 00);
                        List<Voo> voosEncontrados = system.BuscarVoos(aeroporto1, aeroporto2, dataIda, dataVolta);

                        if (voosEncontrados.Count == 0)
                        {
                            Console.WriteLine("Nenhum voo encontrado para as datas fornecidas.");
                        }
                        else
                        {
                            foreach (var v in voosEncontrados)
                            {
                                Console.WriteLine($"Voos encontrados: \n{v.getAeroportoOrigem().getNome()} para {v.getAeroportoDestino().getNome()} \nPela: {v.getCompanhiaAerea().getNome()}\ndata de ida: ${dataIda}, data de volta: ${dataVolta}");
                            }
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
                        List<Passagem> passagensDoPassageiro = system.BuscarPassagem(passageiro1);

                        if (passagensDoPassageiro.Count == 0)
                        {
                            Console.WriteLine("Nenhuma passagem encontrada para o este passageiro.");
                        }
                        else
                        {
                            foreach (var passagensPassageiro in passagensDoPassageiro)
                            {
                                Console.WriteLine($"Passageiro: {passagensPassageiro.GetPassageiro().getNome()};");
                                foreach (var vooPassagem in passagensPassageiro.GetVoosProgramados())
                                {
                                    Console.WriteLine($"Passagens: {vooPassagem.GetVoo().getAeroportoOrigem().getNome()} para {vooPassagem.GetVoo().getAeroportoDestino().getNome()}, pela: {vooPassagem.GetVoo().getCompanhiaAerea().getNome()}");
                                }
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

                case 11:
                    {
                        Bilhete bilhete = new Bilhete(passagem);
                        Console.WriteLine(bilhete);
                        break;
                    }

                case 12:
                    {
                        Console.WriteLine("Reservar Assento em Aeronave");

                        string nomePassageiro = "Vinicius";
                        Console.WriteLine($"Informe o nome do passageiro: {nomePassageiro}");

                        Passageiro passageiroEncontrado = null;
                        if (passageiro1.getNome() == nomePassageiro)
                        {
                            passageiroEncontrado = passageiro1;
                        }

                        if (passageiroEncontrado != null)
                        {
                            List<Passagem> passagensDoPassageiro = system.BuscarPassagem(passageiroEncontrado);
                            if (passagensDoPassageiro.Count > 0)
                            {
                                Passagem passagemSelecionada = passagensDoPassageiro[0];

                                Console.WriteLine("Voos na passagem:");
                                int index = 1;
                                foreach (var vooProg in passagemSelecionada.GetVoosProgramados())
                                {
                                    Console.WriteLine($"{index}) Voo: {vooProg.GetVoo().getCodigoVoo()} Data: {vooProg.GetDataHoraPartida()}");
                                    index++;
                                }

                                int vooIndex = 1;
                                Console.WriteLine($"Informe o número do voo para reservar assento: {vooIndex}");
                                VooProgramado vooProgramadoSelecionado = passagemSelecionada.GetVoosProgramados()[vooIndex - 1];


                                List<string> assentosDisponiveis = vooProgramadoSelecionado.GetAssentosDisponiveis();
                                Console.WriteLine("Assentos disponíveis:");
                                foreach (var assento in assentosDisponiveis)
                                {
                                    Console.Write(assento + " ");
                                }
                                Console.WriteLine();

                                string assentoEscolhido = assentosDisponiveis[0];
                                Console.WriteLine($"Informe o assento desejado: {assentoEscolhido}");
                                system.ReservarAssento(passagemSelecionada, vooProgramadoSelecionado, assentoEscolhido);
                            }
                            else
                            {
                                Console.WriteLine("Nenhuma passagem encontrada para este passageiro.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Passageiro não encontrado.");
                        }
                        break;
                    }
                case 13:
                    {
                        system.AscenderPassageiroVIP(passageiro1, companhia);
                        system.AscenderPassageiroVIP(passageiro2, companhia);
                        system.AscenderPassageiroVIP(passageiro3, companhia);
                        system.AscenderPassageiroVIP(passageiro4, companhia);
                        system.AscenderPassageiroVIP(passageiro5, companhia);
                        Console.WriteLine("---Lista de Passageiros VIPs---");
                        foreach (var passVIP in system.GetPassageirosVIPs())
                        {
                            Console.WriteLine($"O passageiro {passVIP.getNome()} {passVIP.GetSobrenome()} tem {passVIP.GetFranquiaPassagemGratuita()} franquia de passagem gratuita e suas Franquias adicionais gratuitas vão ficar R$ {system.CalcularDescontoPassageiroVIP(passageiro1, companhia)}");
                            Console.WriteLine("---------");
            
                        }
                        break;

                    }
                case 14:
                    {
                        system.CancelarVooPassageiroVIP(passageiro1, vooProgramado);
                        system.CancelarVooPassageiroVIP(passageiro6, vooProgramado);

                        break;
                    }
                case 15:
                    {
                        system.AlterarVooPassageiroVIP(passageiro1, vooProgramado);
                        system.AlterarVooPassageiroVIP(passageiro7, vooProgramado);
                        break;
                    }
                case 16:
                    {
                        passageiro1.AdicionarPassagem(passagem);
                        List<VooProgramado> historicoVoosOrdenado = passageiro1.consultarHistoricoVoos();
                        Console.WriteLine($"Historico de voos do passageiro {passageiro1.getNome()} em ordem cronológica:");
                        foreach (var voos in historicoVoosOrdenado)
                        {
                            Console.WriteLine($"Voo de {voos.GetVoo().getAeroportoOrigem().getNome()} para {voos.GetVoo().getAeroportoDestino().getNome()}\nData de partida: {voos.GetVoo().getDataHoraVoo()}");
                        }
                        break;
                    }
                   case 17:
                    {
                        system.RealizarCheckIn(passagem);
                        Console.WriteLine("\nCartões de Embarque:");
                        foreach (var cartao in passagem.GetCartoesEmbarque())
                        {
                            Console.WriteLine(cartao);
                        }
                        passagem.RealizarCheckIn();
                        Console.WriteLine($"Status da Passagem: {passagem.GetStatusPassagem()}");
                        break;
                    }
                    case 18:
                    {

                        break;
                    }
            }
        }
        while (opt != 0);
    }
}