namespace TrabalhoPOO
{
    internal class SistemaAgenciaViagens : ILog
    {
        /// <summary>
        /// Classe responsável por gerenciar os cadastros e login do sistema
        /// </summary>
        private List<Funcionario> funcionarios;
        private List<Usuario> usuarios;
        private List<CompanhiaAerea> companhiasAereas;
        private List<Aeroporto> aeroportos;
        private List<Voo> voos;
        private List<Passagem> passagens;
        private List<VooProgramado> voosProgramados;
        private List<Passageiro> passageirosVIP;
        // Métodos getters e setters para as listas
        public SistemaAgenciaViagens()
        {
            this.funcionarios = new List<Funcionario>();
            this.usuarios = new List<Usuario>();
            this.companhiasAereas = new List<CompanhiaAerea>();
            this.aeroportos = new List<Aeroporto>();
            this.voos = new List<Voo>();
            this.passagens = new List<Passagem>();
            this.voosProgramados = new List<VooProgramado>();
            this.passageirosVIP = new List<Passageiro>();
            RegistrarLog("Criação de SistemaAgenciaViagens");
        }
        public void CadastrarFuncionario(Funcionario funcionario)
        {
            if (!funcionarios.Contains(funcionario)) // Verifica se o funcionário já está na lista
            {
                funcionarios.Add(funcionario);
                RegistrarLog($"Funcionario {funcionario.getNome()} Cadastrado.");
            }
            else
            {
                Console.WriteLine($"Funcionário {funcionario.getNome()} já cadastrado.");
            }

        }
        public List<Funcionario> GetFuncionarios()
        {
            return funcionarios;
        }

        public Funcionario BuscarFuncionario(string nome)
        {
            Funcionario temp = null;
            foreach (Funcionario f in funcionarios)
            {
                if (f.getNome() == nome)
                {
                    temp = f;
                    return temp;
                }
            }
            return temp;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
            RegistrarLog($"Usuario do Funcionario {usuario.getFuncionario().getNome()} Cadastrado.");
        }

        public List<Usuario> GetUsuarios()
        {
            return usuarios;
        }

        public void CadastrarCompanhia(CompanhiaAerea companhia)
        {
            companhiasAereas.Add(companhia);
            RegistrarLog($"Companhia {companhia.getNome()} cadastrada.");
        }

        public List<CompanhiaAerea> GetCompanhias()
        {
            return companhiasAereas;
        }

        public void CadastrarAeroporto(Aeroporto aeroporto)
        {
            aeroportos.Add(aeroporto);
            RegistrarLog($"Aeroporto {aeroporto.getNome()} cadastrado.");
        }

        public List<Aeroporto> GetAeroportos()
        {
            return aeroportos;
        }
        public void CadastrarVoo(Voo voo)
        {
            // Percorre a lista de voos de trás para frente
            for (int i = voos.Count - 1; i >= 0; i--)
            {
                // Verifica se o voo com o mesmo código já existe
                if (voo.getCodigoVoo() == voos[i].getCodigoVoo())
                {
                    // Remove o voo duplicado
                    voos.RemoveAt(i);
                }
            }
            voos.Add(voo);

            RegistrarLog($"Voo {voo.getAeroportoOrigem().getNome()} para {voo.getAeroportoDestino().getNome()} cadastrado.");
        }

        public List<Voo> GetVoos()
        {
            return voos;
        }

        public void CadastrarVoosProgramados(VooProgramado vooProgramado)
        {
            // Percorre a lista de voos de trás para frente
            for (int i = voosProgramados.Count - 1; i >= 0; i--)
            {
                // Verifica se o voo com o mesmo código já existe
                if (vooProgramado.GetVoo().getCodigoVoo() == voosProgramados[i].GetVoo().getCodigoVoo())
                {
                    // Remove o voo duplicado
                    voosProgramados.RemoveAt(i);
                }
            }
            voosProgramados.Add(vooProgramado);
            RegistrarLog($"Voo Programado {vooProgramado.GetVoo().getCodigoVoo()} cadastrado.");
        }

        public List<VooProgramado> GetVoosProgramados()
        {
            return voosProgramados;
        }

        //Eu gosto assim, amostradinho, vou logo fazer sua passagem
        public void CadastrarPassagem(Passagem passagem)
        {
            // Percorre a lista de voos de trás para frente
            if (!passagens.Contains(passagem)) // Verifica se o funcionário já está na lista
            {
                passagens.Add(passagem);
                RegistrarLog($"Passagem do passageiro {passagem.GetPassageiro().getNome()} cadastrada");
            }
            else
            {
                Console.WriteLine($"Passagem do passageiro {passagem.GetPassageiro().getNome()} já cadastrada.");
            }
        }

        public List<Passagem> GetPassagens()
        {
            return passagens;
        }

        public List<Passageiro> GetPassageirosVIPs()
        {
            return this.passageirosVIP;
        }

        // Método de login
        /// <summary>
        /// Verifica se as credenciais de login batem com as de algum usuário
        /// </summary>
        /// <param name="login">Credencial de login</param>
        /// <param name="senha">Senha de login</param>
        /// <returns>Retorna o usuário referente ao login, retorna null se não houver usuário com essas credenciais</returns>
        public Usuario LoginFuncionario(string login, string senha)
        {
            foreach (Usuario user in usuarios)
            {

                if (user.getLogin() == login && user.getSenha() == senha) { return user; }
            }
            return null;
        }
        /// <summary>
        /// Busca voos cuja data de origem ou de saída batam com as datas específicadas
        /// </summary>
        /// <param name="origem">Aeroporto de origem</param>
        /// <param name="destino">Aeroporto de destino</param>
        /// <param name="dataSaida">Data de saída</param>
        /// <param name="dataVolta">Data da volta</param>
        /// <returns>Lista contendo todos os voos</returns>
        public List<Voo> BuscarVoos(Aeroporto origem, Aeroporto destino, DateTime dataSaida, DateTime? dataVolta)
        {
            List<Voo> resp = new List<Voo>();

            foreach (Voo v in voos)
            {
                if (v.getAeroportoOrigem().Equals(origem) &&
                    v.getAeroportoDestino().Equals(destino) &&
                    v.getDataHoraVoo().Date == dataSaida.Date)
                {
                    resp.Add(v);
                }
            }

            return resp;
        }
        public List<(Voo, Voo)> BuscarVoosComConexao(Aeroporto origem, Aeroporto destino, DateTime data)
        {
            List<(Voo, Voo)> voosComConexao = new List<(Voo, Voo)>();

            foreach (Voo vooOrigem in voos)
            {
                if (vooOrigem.getAeroportoOrigem() == origem && vooOrigem.getDataHoraVoo().Date == data)
                {
                    foreach (Voo vooConexao in voos)
                    {
                        // Verificar se o vooConexao parte do destino do vooOrigem e chega ao destino final
                        if (vooConexao.getAeroportoOrigem() == vooOrigem.getAeroportoDestino() &&
                            vooConexao.getAeroportoDestino() == destino)
                        {
                            // Verificar se o horário do vooConexao é depois do horário de chegada do vooOrigem
                            DateTime horarioChegadaOrigem = vooOrigem.CalcularHorarioPrevistoChegada();
                            if (vooConexao.getDataHoraVoo() > horarioChegadaOrigem &&
                                (vooConexao.getDataHoraVoo() - horarioChegadaOrigem).TotalHours >= 1) // Conexão de pelo menos 1 hora
                            {
                                // Adicionar o par de voos (vooOrigem, vooConexao) à lista
                                voosComConexao.Add((vooOrigem, vooConexao));
                            }
                        }
                    }
                }
            }

            return voosComConexao;
        }


        public Voo BuscaVooPorCodigo(string codigo)
        {
            foreach (Voo v in voos)
            {
                if (v.getCodigoVoo() == codigo) return v;
            }
            return null;
        }
        public Aeroporto BuscaAeroportoPorNome(string nome)
        {
            foreach (Aeroporto a in aeroportos)
            {
                if (a.getNome() == nome) return a;
            }
            return null;
        }

        public CompanhiaAerea BuscaCompanhiaPorCodigo(string codigo)
        {
            foreach (CompanhiaAerea c in companhiasAereas)
            {
                if (c.getCodigo() == codigo) return c;
            }
            return null;
        }
        public Passagem EmitirPassagem(List<VooProgramado> voosSelecionados, TipoTarifa tipoTarifa, Passageiro passageiro, int numeroBagagens, Dictionary<VooProgramado, string> assentos)
        {
            double valorTotal = 1000.0;

            Passagem novaPassagem = new Passagem(voosSelecionados, tipoTarifa, passageiro, numeroBagagens, Moeda.BRL, valorTotal);

            foreach (var item in assentos)
            {
                VooProgramado vooProgramado = item.Key;
                string assento = item.Value;
                novaPassagem.ReservarAssento(vooProgramado, assento);
            }

            passagens.Add(novaPassagem);
            return novaPassagem;
        }

        public void ReservarAssento(Passagem passagem, VooProgramado vooProgramado, string assento)
        {
            passagem.ReservarAssento(vooProgramado, assento);
        }

        public void InstanciaVoosPorDiaDaSemana(Voo voo)
        {
            DateTime diaDeHoje = DateTime.Now;
            for (int i = 0; i < voo.getFrequenciaSemanal().Count; i++)
            {
                switch (voo.getFrequenciaSemanal()[i])
                {
                    case "segunda":
                        for (int j = 1; j <= 30; j++)
                        {
                            if ((int)diaDeHoje.DayOfWeek == 1)
                            {
                                Voo temp = voo.Clonar();
                                temp.setDataHoraVoo(diaDeHoje);
                                CadastrarVoo(temp);
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave(0098635, 180, 2000.0, 30, 6));
                                CadastrarVoosProgramados(temp2);
                            }
                            diaDeHoje = diaDeHoje.AddDays(1);
                        }
                        diaDeHoje = DateTime.Now;
                        break;
                    case "terça":
                        for (int j = 1; j <= 30; j++)
                        {
                            if ((int)diaDeHoje.DayOfWeek == 2)
                            {
                                Voo temp = voo.Clonar();
                                temp.setDataHoraVoo(diaDeHoje);
                                CadastrarVoo(temp);
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave(0098635, 180, 2000.0, 30, 6));
                                CadastrarVoosProgramados(temp2);
                            }
                            diaDeHoje = diaDeHoje.AddDays(1);
                        }
                        diaDeHoje = DateTime.Now;
                        break;
                    case "quarta":
                        for (int j = 1; j <= 30; j++)
                        {
                            if ((int)diaDeHoje.DayOfWeek == 3)
                            {
                                Voo temp = voo.Clonar();
                                temp.setDataHoraVoo(diaDeHoje);
                                CadastrarVoo(temp);
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave(0098635, 180, 2000.0, 30, 6));
                                CadastrarVoosProgramados(temp2);
                            }
                            diaDeHoje = diaDeHoje.AddDays(1);
                        }
                        diaDeHoje = DateTime.Now;
                        break;
                    case "quinta":
                        for (int j = 1; j <= 30; j++)
                        {
                            if ((int)diaDeHoje.DayOfWeek == 4)
                            {
                                Voo temp = voo.Clonar();
                                temp.setDataHoraVoo(diaDeHoje);
                                CadastrarVoo(temp);
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave(0098635, 180, 2000.0, 30, 6));
                                CadastrarVoosProgramados(temp2);
                            }
                            diaDeHoje = diaDeHoje.AddDays(1);
                        }
                        diaDeHoje = DateTime.Now;
                        break;
                    case "sexta":
                        for (int j = 1; j <= 30; j++)
                        {
                            if ((int)diaDeHoje.DayOfWeek == 5)
                            {
                                Voo temp = voo.Clonar();
                                temp.setDataHoraVoo(diaDeHoje);
                                CadastrarVoo(temp);
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave(0098635, 180, 2000.0, 30, 6));
                                CadastrarVoosProgramados(temp2);
                            }
                            diaDeHoje = diaDeHoje.AddDays(1);
                        }
                        diaDeHoje = DateTime.Now;
                        break;
                    case "sabado":
                        for (int j = 1; j <= 30; j++)
                        {
                            if ((int)diaDeHoje.DayOfWeek == 6)
                            {
                                Voo temp = voo.Clonar();
                                temp.setDataHoraVoo(diaDeHoje);
                                CadastrarVoo(temp); VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave(0098635, 180, 2000.0, 30, 6));
                                CadastrarVoosProgramados(temp2);
                            }
                            diaDeHoje = diaDeHoje.AddDays(1);
                        }
                        break;
                    case "domingo":
                        for (int j = 1; j <= 30; j++)
                        {
                            if ((int)diaDeHoje.DayOfWeek == 0)
                            {
                                Voo temp = voo.Clonar();
                                temp.setDataHoraVoo(diaDeHoje);
                                CadastrarVoo(temp);
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave(0098635, 180, 2000.0, 30, 6));
                                CadastrarVoosProgramados(temp2);
                            }
                            diaDeHoje = diaDeHoje.AddDays(1);
                        }
                        diaDeHoje = DateTime.Now;
                        break;
                }
            }
        }
        public void Cancelar(ICancelavel item)
        {
            item.Cancelar();
        }
        public void RealizarCheckIn(Passagem passagem)
        {
            // Validar se a passagem ou os voos programados são nulos
            if (passagem == null || passagem.GetVoosProgramados() == null || passagem.GetVoosProgramados().Count == 0)
            {
                Console.WriteLine("Erro: Passagem inválida ou sem voos programados.");
                return;
            }

            DateTime dataHoraAtual = DateTime.Now.AddDays(10);
            VooProgramado vooProgramado = passagem.GetVoosProgramados()[0];
            DateTime dataHoraPartida = passagem.GetVoosProgramados()[0].GetDataHoraPartida();

            // Calcular o intervalo de tempo até o voo
            TimeSpan horasAteOVoo = dataHoraPartida - dataHoraAtual;

            Console.WriteLine($"Tempo até o voo: {horasAteOVoo.TotalMinutes} minutos.");

            // Verificar se o check-in está dentro do intervalo permitido (30min a 48h)
            if (horasAteOVoo.TotalMinutes >= 30 && horasAteOVoo.TotalMinutes <= 2880)
            {
                // Atualizar status de check-in da passagem
                passagem.SetStatusPassagem(StatusPassagem.CheckinRealizado);

                // Gerar cartões de embarque para cada voo programado
                passagem.ReservarAssento(vooProgramado, "1A");
                if (passagem.GetAssentosReservados().TryGetValue(vooProgramado, out string? assento))
                {
                    CartaoEmbarque cartao = new CartaoEmbarque(passagem.GetPassageiro(), vooProgramado, assento);
                    passagem.AdicionarCartaoEmbarque(cartao);
                    Console.WriteLine($"Cartão de embarque gerado para o voo {vooProgramado.GetVoo().getCodigoVoo()} com assento {assento}.");
                }
                else
                {
                    Console.WriteLine($"Erro: Assento não reservado para o voo {vooProgramado.GetVoo().getCodigoVoo()}.");
                }

                Console.WriteLine("Check-in realizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro: O check-in deve ser realizado entre 48 horas (2880 minutos) e 30 minutos antes do voo.");
            }
        }
        public List<Passagem> BuscarPassagem(Passageiro passageiro)
        {
            List<Passagem> passagensDoPassageiro = new List<Passagem>();

            foreach (Passagem passagem in passagens)
            {
                if (passagem.GetPassageiro() == passageiro)
                {
                    passagensDoPassageiro.Add(passagem);
                }
            }
            return passagensDoPassageiro;
        }

        public bool EhVIP(Passageiro passageiro) => passageirosVIP.Contains(passageiro);

        public void AscenderPassageiroVIP(Passageiro passageiro, CompanhiaAerea companhia)
        {
            if (!EhVIP(passageiro))
            {
                passageiro.SetFranquiaPassagemGratuita(1);
                passageirosVIP.Add(passageiro);
                Console.WriteLine($"O passageiro {passageiro.getNome()} {passageiro.GetSobrenome()} foi ascendido a Passageiro VIP na companhia aérea {companhia.getNome()}.");
                RegistrarLog($"O passageiro {passageiro.getNome()} foi ascendido á Passageiro VIP");
                RegistrarLog($"Franquia de passagem gratuita do passageiro {passageiro.getNome()} alterada para {passageiro.GetFranquiaPassagemGratuita()}");
            }
            else
            {
                Console.WriteLine($"O passageiro {passageiro.getNome()} {passageiro.GetSobrenome()} já é VIP nesta companhia aérea.");
            }
        }

        public void CancelarVooPassageiroVIP(Passageiro passageiro, ICancelavel voo)
        {
            if (EhVIP(passageiro))
            {
                passageiro.CancelarVooSemCusto(voo);
                RegistrarLog($"Voo do passageiro VIP {passageiro.getNome()} cancelado.");
            }
            else
            {
                Console.WriteLine($"O passageiro {passageiro.getNome()} {passageiro.GetSobrenome()} não é VIP e o cancelamento terá custo.");
            }
        }

        public void AlterarVooPassageiroVIP(Passageiro passageiro, VooProgramado voo)
        {
            DateTime novaData = new DateTime(2024, 10, 01, 17, 00, 00);
            if (EhVIP(passageiro))
            {
                voo.SetDataHoraPartida(novaData);
                Console.WriteLine($"A data do voo do Passageiro {passageiro.getNome()} foi alterada para {novaData}");
                RegistrarLog($"Data do voo do Pasageiro VIP {passageiro.getNome()} alterado para {novaData}");
            }
            else
            {
                Console.WriteLine($"O passageiro {passageiro.getNome()} {passageiro.GetSobrenome()} não é VIP e terá um custo para alteração");
            }
        }

        public double CalcularDescontoPassageiroVIP(Passageiro passageiro, CompanhiaAerea companhia)
        {
            double desconto = 0;
            if (EhVIP(passageiro))
            {
                desconto = companhia.getValorBagagemAdicional() / 2;
                return desconto;
            }
            else
            {
                Console.WriteLine($"O passageiro {passageiro.getNome()} não é VIP, então não tem desconto");
                return desconto;
            }
        }

        public void RegistrarLog(string operacao)
        {
            try
            {
                string mensagem = $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {operacao}";
                File.AppendAllText(EncontrarArquivo.Localizar(), mensagem + Environment.NewLine);
            }
            catch (Exception e)
            {
                throw new Exception($"Ocorreu um erro ao registrar no log: {e}");
                throw;
            }
        }
    }
}