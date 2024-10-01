using System;

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
        // Métodos getters e setters para as listas
        public void CadastrarFuncionario(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
        }
        public List<Funcionario> GetFuncionarios()
        {
            return funcionarios;
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
                if (user.login == login && user.senha == senha) { return user; }
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
        public List<Voo> BuscarVoos(Aeroporto origem, Aeroporto destino, DateTime dataSaida, DateTime dataVolta )
        {
            List<Voo> resp = new List<Voo>();
            foreach (Voo v in voos)
            {
                if (v.getAeroportoOrigem() == origem && v.getAeroportoDestino() == destino && v.getDataHoraVoo() == dataSaida) resp.Add(v);
                else if (v.getAeroportoOrigem() == destino && v.getAeroportoDestino() == origem && v.getDataHoraVoo() == dataVolta) resp.Add(v);
            }
            return resp;
        }
    }
}
