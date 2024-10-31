namespace TrabalhoPOO
{
    internal class SistemaAgenciaViagens
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
        }
        public void CadastrarFuncionario(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
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
        }

        public List<Usuario> GetUsuarios()
        {
            return usuarios;
        }

        public void CadastrarCompanhia(CompanhiaAerea companhia)
        {
            companhiasAereas.Add(companhia);
        }

        public List<CompanhiaAerea> GetCompanhias()
        {
            return companhiasAereas;
        }

        public void CadastrarAeroporto(Aeroporto aeroporto)
        {
            aeroportos.Add(aeroporto);
        }

        public List<Aeroporto> GetAeroportos()
        {
            return aeroportos;
        }
        public void CadastrarVoo(Voo voo)
        {
            voos.Add(voo);
        }

        public List<Voo> GetVoos()
        {
            return voos;
        }

        public void CadastrarVoosProgramados(VooProgramado voos) 
        {
            voosProgramados.Add(voos);
        }

        public List<VooProgramado> GetVoosProgramados() 
        {
            return voosProgramados;
        }

        //Eu gosto assim, amostradinho, vou logo fazer sua passagem
        public void CadastrarPassagem(Passagem passagem)
        {
            passagens.Add(passagem);
        }

        public List<Passagem> GetPassagens()
        {
            return passagens;
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
        public Passagem EmitirPassagem(List<Voo> voosSelecionados, TipoTarifa tipoTarifa, Passageiro passageiro, int numeroBagagens)
        {
            Passagem novaPassagem = new Passagem(voosSelecionados, tipoTarifa, passageiro, numeroBagagens);
            passagens.Add(novaPassagem);
            return novaPassagem;
        }
        public List<Passagem> BuscarPassagem(Passageiro passageiro)
        {
            List<Passagem> passagensDoPassageiro = new List<Passagem>();

            foreach (Passagem passagem in passagens)
            {

                if (passagem.GetPassageiro() == passageiro)

                    if (passagem.GetPassageiro() == passageiro)
                    {
                        passagensDoPassageiro.Add(passagem);
                    }
            }
            return passagensDoPassageiro;
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
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave());
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
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave());
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
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave());
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
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave());
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
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave());
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
                                CadastrarVoo(temp);
                                VooProgramado temp2 = new VooProgramado(temp,temp.getDataHoraVoo(),new Aeronave());
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
                                VooProgramado temp2 = new VooProgramado(temp, temp.getDataHoraVoo(), new Aeronave());
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
    }
}