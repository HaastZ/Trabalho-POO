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
            this.passageirosVIP =  new List<Passageiro>();
            RegistrarLog("Criação de SistemaAgenciaViagens");
        }
        public void CadastrarFuncionario(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
            RegistrarLog($"Funcionario {funcionario.getNome()} Cadastrado.");
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
            voos.Add(voo);
            RegistrarLog($"Voo {voo.getAeroportoOrigem().getNome()} para {voo.getAeroportoDestino().getNome()} cadastrado.");
        }

        public List<Voo> GetVoos()
        {
            return voos;
        }

        public void CadastrarVoosProgramados(VooProgramado voos) 
        {
            voosProgramados.Add(voos);
            RegistrarLog($"Voo Programado {voos.GetVoo().getCodigoVoo()} cadastrado.");
        }

        public List<VooProgramado> GetVoosProgramados() 
        {
            return voosProgramados;
        }

        //Eu gosto assim, amostradinho, vou logo fazer sua passagem
        public void CadastrarPassagem(Passagem passagem)
        {
            passagens.Add(passagem);
            RegistrarLog($"Passagem de {passagem.GetPassageiro().getNome()} cadastrada");
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
        public List<Voo> BuscarVoos(Aeroporto origem, Aeroporto destino, DateTime dataSaida, DateTime dataVolta)
        {
            List<Voo> resp = new List<Voo>();
            foreach (Voo v in voos)
            {
                if (v.getAeroportoOrigem() == origem && v.getAeroportoDestino() == destino && v.getDataHoraVoo() == dataSaida) resp.Add(v);
                else if (v.getAeroportoOrigem() == destino && v.getAeroportoDestino() == origem && v.getDataHoraVoo() == dataVolta) resp.Add(v);
            }
            return resp;
        }
        public List<Voo> BuscarVoosComConexao(Aeroporto origem, Aeroporto destino, DateTime data)
        {
            List<Voo> voosComConexao = new List<Voo>();

            foreach (Voo vooOrigem in voos)
            {
                if (vooOrigem.getAeroportoOrigem() == origem && vooOrigem.getDataHoraVoo() == data)
                {
                    foreach (Voo vooConexao in voos)
                    {
                        if (vooConexao.getAeroportoOrigem() == vooOrigem.getAeroportoDestino() &&
                            vooConexao.getAeroportoDestino() == destino)
                        {
                            voosComConexao.Add(vooConexao);
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
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave(0098635,180, 2000.0, 30, 6));
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
                                CadastrarVoo(temp);VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave(0098635, 180, 2000.0, 30, 6));
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
            DateTime dataHoraAtual = DateTime.Now;
            TimeSpan horasAteOVoo = passagem.GetVoosProgramados()[0].GetDataHoraPartida() - dataHoraAtual;

            Console.WriteLine(horasAteOVoo.TotalMinutes);
            if(horasAteOVoo.TotalMinutes >= 30 && horasAteOVoo.TotalMinutes <= 1440)

            if (horasAteOVoo.TotalMinutes >= 30 && horasAteOVoo.TotalMinutes <= 2880) // Entre 48h e 30min
            {
                passagem.Check_In = true;

                foreach (var vooProgramado in passagem.GetVoosProgramados())
                {
                    string assento;
                    if (passagem.GetAssentosReservados().TryGetValue(vooProgramado, out assento))
                    {
                        CartaoEmbarque cartao = new CartaoEmbarque(passagem.GetPassageiro(), vooProgramado, assento);
                        passagem.AdicionarCartaoEmbarque(cartao);
                    }
                    else
                    {
                        Console.WriteLine($"Assento não reservado para o voo {vooProgramado.GetVoo().getCodigoVoo()}");
                    }
                }

                Console.WriteLine("Check-in realizado com sucesso. Cartões de embarque gerados.");
            }
            else
            {
                Console.WriteLine("Erro: O check-in deve ser realizado entre 48h e 30min até a hora do voo");
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
                RegistrarLog($"Franquia de passagem gratuita do passageiro {passageiro.getNome()} alterada para {passageiro.GetFranquiaPassagemGratuita()}");
                passageirosVIP.Add(passageiro);
                Console.WriteLine($"O passageiro {passageiro.getNome()} {passageiro.GetSobrenome()} foi ascendido a Passageiro VIP na companhia aérea {companhia.getNome()}.");
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
            if(EhVIP(passageiro)) 
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
            if(EhVIP(passageiro)) 
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