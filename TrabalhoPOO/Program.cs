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
        Aeroporto aeroportoGuarulhos = new Aeroporto("Aeroporto Internacional de São Paulo", "GRU", "São Paulo", "SP", "Brasil", -23.428008, -46.4922292);
        Aeroporto aeroportoJFK = new Aeroporto("Aeroporto Internacional John F. Kennedy", "JFK", "Nova York", "NY", "Estados Unidos", 40.642923, -73.805145);
        Aeroporto aeroportoConfins = new Aeroporto("Aeroporto Internacional de Belo Horizonte", "CNF", "Belo Horizonte", "MG", "Brasil", -19.6355567, -43.966558);
        Aeroporto aeroportoBrasilia = new Aeroporto("Aeroporto Internacional de Brasília", "BSB", "Brasília", "BSB", "Distrito Federal", -15.8706905, -47.9219233);
        CompanhiaAerea companhia = new CompanhiaAerea("Companhia Aérea GOL", "GOL", "GOL Linhas Aéreas S/A", "00.000.000/0001-00", 50.0, 80.0);
        CompanhiaAerea azul = new CompanhiaAerea("Azul Linhas Aéreas", "AD", "AZUL LINHAS AÉREAS BRASILEIRAS S.A", "09.296.295/0014-84", 80.0, 100.0);
        List<string> frequenciaSemanal = ["segunda", "quarta", "sexta"];
        Voo voo = new Voo(aeroportoGuarulhos, aeroportoJFK, DateTime.Now.AddDays(10), "1234567", companhia, TipoTarifa.Basica, Moeda.BRL, frequenciaSemanal, "10:30", "10:00", 250);
        Console.WriteLine("Chegada do Voo de Guarulhos até Nova York:" + voo.CalcularHorarioPrevistoChegada().ToString());
        Voo voo2 = new Voo(aeroportoJFK, aeroportoGuarulhos, DateTime.Now.AddDays(10).AddHours(1), "9876543", companhia, TipoTarifa.Executiva, Moeda.BRL, frequenciaSemanal, "12:00", "11:00", 280);
        Voo voo3 = new Voo(aeroportoConfins, aeroportoJFK, DateTime.Now.AddDays(10).AddHours(2), "0043212", companhia, TipoTarifa.Basica, Moeda.USD, frequenciaSemanal, "09:00", "08:00", 580);
        Voo voo4 = new Voo(aeroportoJFK, aeroportoConfins, DateTime.Now.AddDays(10).AddHours(3), "9954300", azul, TipoTarifa.Premium, Moeda.BRL, frequenciaSemanal, "15:00", "14:00", 740);
        Voo voo5 = new Voo(aeroportoGuarulhos, aeroportoJFK, DateTime.Now.AddDays(10).AddHours(4), "000987", azul, TipoTarifa.Executiva, Moeda.USD, frequenciaSemanal, "07:30", "06:00", 250);
        Voo voo6 = new Voo(aeroportoJFK, aeroportoConfins, DateTime.Now.AddDays(12).AddHours(5), "11735400", azul, TipoTarifa.Basica, Moeda.BRL, frequenciaSemanal, "09:00", "10:00", 540);
        Passageiro passageiro1 = new Passageiro("Vinicius", "Almeida", TipoDocumento.CPF, "12345", "vinicius@email.com");
        Passageiro passageiro2 = new Passageiro("Lucas", "Bryan", TipoDocumento.CPF, "12345678", "lucas@gmail.com");
        Passageiro passageiro3 = new Passageiro("Artur", "Moreira", TipoDocumento.RG, "MG9123863", "artur@gmail.com");
        Passageiro passageiro4 = new Passageiro("Ricardo", "Alencar", TipoDocumento.CPF, "563725", "ricardo@gmail.com");
        Passageiro passageiro5 = new Passageiro("Gabriel", "Marinho", TipoDocumento.PASSAPORTE, "0129384", "gabriel@email.com");
        Passageiro passageiro6 = new Passageiro("Felipe", "Henrique", TipoDocumento.CPF, "8239412", "felipe@email.com");
        Passageiro passageiro7 = new Passageiro("Tarsis", "Augustus", TipoDocumento.RG, "MG98127263", "tarsis@email.com");
        Aeronave aeronave = new Aeronave(0000001, 180, 2000.0, 30, 3);
        Aeronave aeronave2 = new Aeronave(0000002, 180, 3000.0, 30, 4);
        Aeronave aeronave3 = new Aeronave(0000003, 180, 4000.0, 30, 5);
        Aeronave aeronave4 = new Aeronave(0000004, 180, 5000.0, 30, 6);
        Aeronave aeronave5 = new Aeronave(0000005, 180, 6000.0, 30, 7);
        Aeronave aeronave6 = new Aeronave(0000006, 180, 7000.0, 30, 8);
        VooProgramado vooProgramado = new VooProgramado(voo, voo.getDataHoraVoo(), aeronave);
        VooProgramado vooProgramado2 = new VooProgramado(voo2, voo2.getDataHoraVoo(), aeronave2);
        VooProgramado vooProgramado3 = new VooProgramado(voo3, voo3.getDataHoraVoo(), aeronave3);
        VooProgramado vooProgramado4 = new VooProgramado(voo4, voo4.getDataHoraVoo(), aeronave4);
        VooProgramado vooProgramado5 = new VooProgramado(voo5, voo5.getDataHoraVoo(), aeronave5);
        VooProgramado vooProgramado6 = new VooProgramado(voo6, voo6.getDataHoraVoo(), aeronave6);
        system.InstanciaVoosPorDiaDaSemana(voo);
        List<VooProgramado> voosPassagem1 = new List<VooProgramado>{
            new VooProgramado(voo, voo.getDataHoraVoo(), aeronave),
            new VooProgramado(voo2, voo2.getDataHoraVoo(), aeronave)
        };
        List<VooProgramado> voosPassagem2 = new List<VooProgramado>{
            new VooProgramado(voo3, voo3.getDataHoraVoo(), aeronave2),
            new VooProgramado(voo4, voo4.getDataHoraVoo(), aeronave2)
        };
        List<VooProgramado> voosPassagem3 = new List<VooProgramado>{
            new VooProgramado(voo5, voo5.getDataHoraVoo(), aeronave3),
            new VooProgramado(voo6, voo6.getDataHoraVoo(), aeronave3)
        };
        Passagem passagem = new Passagem(voosPassagem1, TipoTarifa.Basica, passageiro1, 4, Moeda.BRL, 4000);
        Passagem passagem2 = new Passagem(voosPassagem2, TipoTarifa.Executiva, passageiro2, 5, Moeda.BRL, 3000);
        Passagem passagem3 = new Passagem(voosPassagem3, TipoTarifa.Premium, passageiro3, 6, Moeda.USD, 2000);

        do
        {
            Console.WriteLine("\n-------MENU-------\n");
            Console.WriteLine("1) Cadastrar Funcionário");
            Console.WriteLine("2) Cadastrar Usuário");
            Console.WriteLine("3) Cadastrar Companhia Aérea");
            Console.WriteLine("4) Cadastrar Aeroporto");
            Console.WriteLine("5) Cadastrar Voo");
            Console.WriteLine("6) Cadastrar Passagem");
            Console.WriteLine("7) Buscar Voos Diretos em uma data específica");
            Console.WriteLine("8) Adquirir passagem do passageiro comum");
            Console.WriteLine("9) Realizar CheckIn do passageiro");
            Console.WriteLine("10) Buscar voos com conexão em uma data específica");
            Console.WriteLine("11) Adquirir passagem de passageiroVIP e gerar o bilhete");
            Console.WriteLine("12) Cancelar um voo do passageiro");
            Console.WriteLine("13) Mostrar arquivo de log");

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
                        system.CadastrarCompanhia(azul);
                        // Listagem de Companhias Cadastradas
                        Console.WriteLine($"\n{system.GetCompanhias().Count} Companhias Cadastradas:\n");
                        foreach (var companhias in system.GetCompanhias())
                        {
                            Console.WriteLine($"{companhias.getNome()}\nCodigo: {companhias.getCodigo()}\nRazaoSocial: {companhias.getRazaoSocial()}\nCNPJ: {companhias.getCnpj()}\nValor da Primeira Bagagem: {companhias.getValorPrimeraBagagem()}\nBagagens Adicionais: {companhias.getValorBagagemAdicional()}\n");
                        }
                        break;
                    }

                case 4:// Cadastro de Aeroportos
                    {
                        Console.WriteLine("\nCadastro de Aeroporto");
                        system.CadastrarAeroporto(aeroportoGuarulhos);
                        system.CadastrarAeroporto(aeroportoJFK);
                        system.CadastrarAeroporto(aeroportoConfins);
                        system.CadastrarAeroporto(aeroportoBrasilia);

                        // Aeroportos Cadastrados
                        Console.WriteLine($"\n{system.GetAeroportos().Count} Aeroportos Cadastrados:\n");
                        foreach (var aeroporto in system.GetAeroportos())
                        {
                            Console.WriteLine($"{aeroporto.getNome()}\nSigla: {aeroporto.getSigla()}\nPais: {aeroporto.getPais()}\nEstado: {aeroporto.getEstado()}\nCidade: {aeroporto.getCidade()}\n");
                        }
                        break;
                    }

                case 5:// Cadastro de Voos
                    {
                        Console.WriteLine("\nCadastro de Voos");
                        system.CadastrarVoo(voo);
                        system.CadastrarVoo(voo2);
                        system.CadastrarVoo(voo3);
                        system.CadastrarVoo(voo4);
                        system.CadastrarVoo(voo5);
                        system.CadastrarVoo(voo6);
                        system.CadastrarVoosProgramados(vooProgramado);
                        system.CadastrarVoosProgramados(vooProgramado2);
                        system.CadastrarVoosProgramados(vooProgramado3);
                        system.CadastrarVoosProgramados(vooProgramado4);
                        system.CadastrarVoosProgramados(vooProgramado5);
                        system.CadastrarVoosProgramados(vooProgramado6);

                        // Voos Cadastrados
                        Console.WriteLine($"\n{system.GetVoos().Count} Voos cadastrados:\n");
                        foreach (var voos in system.GetVoos())
                        {
                            Console.WriteLine($"Código do voo: {voos.getCodigoVoo()}\nAeroporto de origem: {voos.getAeroportoOrigem().getNome()}\nAeroporto de destino: {voos.getAeroportoDestino().getNome()}\nData de ida: {voos.getDataHoraVoo()}\nTipo da Tarifa: {voos.GetTipoTarifa()}\nMoeda do voo: {voos.getMoeda()}\n");
                        }
                        break;
                    }

                case 6:// Cadastro de Passagens
                    {
                        Console.WriteLine("\nCadastro de Passagens");
                        system.CadastrarPassagem(passagem);
                        system.CadastrarPassagem(passagem2);
                        system.CadastrarPassagem(passagem3);

                        // Passagens Cadastradas
                        Console.WriteLine($"\n{system.GetPassagens().Count} Passagens Cadastradas:\n");
                        foreach (var pass in system.GetPassagens())
                        {
                            Console.Write($"Passagem do passageiro {pass.GetPassageiro().getNome()} {pass.GetPassageiro().GetSobrenome()}\nVoos da passagem:");
                            foreach (var Voo in pass.GetVoosProgramados())
                            {
                                Console.Write($"\n{Voo.GetVoo().getAeroportoOrigem().getNome()} para {Voo.GetVoo().getAeroportoDestino().getNome()}");
                            }

                            Console.WriteLine($"\nTipo da tarifa: {pass.GetTipoTarifa()}\n" + $"Numero de bagagens: {pass.getNumeroBagagens()}\n" +
                            $"Moeda da passagem: {pass.GetMoeda()}\n" +
                            $"Valor total: {pass.GetMoeda()}{pass.getValorTotal()}");
                            Console.WriteLine($"Status da passagem: {pass.GetStatusPassagem()}\n");

                        }
                        break;
                    }

                case 7:// Busca de Voos por data específica
                    {
                        DateTime dataBusca = DateTime.Now.AddDays(10);
                        List<Voo> voosEncontrados = system.BuscarVoos(aeroportoGuarulhos, aeroportoJFK, dataBusca);
                        Console.WriteLine("\nBuscando um voo por data específica");
                        
                        if (voosEncontrados.Count == 0)
                        {
                            Console.WriteLine("Nenhum voo encontrado para a data fornecida!");
                        }
                        else
                        {
                            foreach (var v in voosEncontrados)
                            {
                                Console.WriteLine($"- Horário do Voo: {v.getDataHoraVoo()}");
                                Console.WriteLine($"  Duração: {v.CalcularTempoViagem()} horas");
                                Console.WriteLine($"  Horário de Chegada Estimado: {voo.CalcularHorarioPrevistoChegada()}");
                                Console.WriteLine($"  Valor da Passagem: {passagem.GetMoeda()} {passagem.getValorTotal()}");
                                Console.WriteLine();
                            }
                        }
                        break;
                    }


                case 8:// Adiquirindo passagem para um passageiro comum e gerando o bilhete
                    {
                        Console.WriteLine("\nAdquirindo passagem de um passageiro comum e gerando o bilhete\n");
                        Console.WriteLine($"Passagem do passageiro {passagem2.GetPassageiro().getNome()} {passagem2.GetPassageiro().GetSobrenome()} {passagem2.GetStatusPassagem()}");
                        Console.WriteLine("\nBilhete");
                        Bilhete bilhete = new Bilhete(passagem2);
                        Console.WriteLine(bilhete);
                        break;
                    }

                case 9:// Passageiro realiza check in e o embarque
                    {
                        Console.WriteLine($"\nRealizando checkin do passageiro {passagem2.GetPassageiro().getNome()} {passagem2.GetPassageiro().GetSobrenome()} e o embarque");
                        system.RealizarCheckIn(passagem2);
                        Console.WriteLine("\nCartão de Embarque:");
                        foreach (var cartao in passagem2.GetCartoesEmbarque())
                        {
                            Console.WriteLine(cartao);
                        }
                        Console.WriteLine($"Status da Passagem: {passagem2.GetStatusPassagem()}");
                        break;
                    }

                case 10:
                    {
                        // FAZER CORRETAMENTE O VOO COM CONEXÃO
                        Console.WriteLine("Buscando voos com conexão em uma data específica");
                        DateTime dataBusca = DateTime.Now.AddDays(10).AddHours(6);
                        List<(Voo, Voo)> voosEncontrados = system.BuscarVoosComConexao(aeroportoGuarulhos, aeroportoConfins, dataBusca.Date);
                        if (voosEncontrados.Count == 0)
                        {
                            Console.WriteLine("Nenhum voo encontrado para os critérios especificados.");
                        }
                        else
                        {
                            foreach (var (vooOrigem, vooConexao) in voosEncontrados)
                            {
                                Console.WriteLine("Voo de Origem:");
                                Console.WriteLine($"- Horário do Voo: {vooOrigem.getDataHoraVoo()}");
                                Console.WriteLine($"  Horário de Chegada: {vooOrigem.CalcularHorarioPrevistoChegada()}");
                                Console.WriteLine();

                                Console.WriteLine("Voo de Conexão:");
                                Console.WriteLine($"- Horário do Voo: {vooConexao.getDataHoraVoo()}");
                                Console.WriteLine($"  Horário de Chegada: {vooConexao.CalcularHorarioPrevistoChegada()}");
                                Console.WriteLine();
                            }
                        }
                        break;
                    }

                case 11:
                    {
                        Console.WriteLine("Adquirindo passagem do passageiro VIP");
                        system.AscenderPassageiroVIP(passageiro2, companhia);
                        Bilhete bilhete = new Bilhete(passagem2);
                        Console.WriteLine(bilhete);
                        foreach (var passVIP in system.GetPassageirosVIPs())
                        {
                            Console.WriteLine($"O passageiro {passVIP.getNome()} {passVIP.GetSobrenome()} tem {passVIP.GetFranquiaPassagemGratuita()} franquia de bagagem gratuita e suas Franquias adicionais vão ficar R$ {system.CalcularDescontoPassageiroVIP(passageiro2, companhia)}");
                            Console.WriteLine("---------");

                        }
                        break;
                    }

                case 12:
                    {
                        Console.WriteLine("Cancelando um voo do passageiro");
                        system.CancelarVooPassageiroVIP(passageiro2, vooProgramado2);
                        passagem2.Cancelar();
                        passagem2.GetStatusPassagem();
                        break;
                    }
                case 13:
                    {
                        Console.WriteLine("Mostrando arquivo de log");
                        string caminho = EncontrarArquivo.Localizar();
                        string[] linhas = File.ReadAllLines(caminho);
                        foreach(string linha in linhas) 
                        {
                            Console.WriteLine(linha);
                        }
                    }
                    break;
            }
        }
        while (opt != 0);
    }
}