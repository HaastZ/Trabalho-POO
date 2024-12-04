using System;
using System.Collections.Generic;
using System.IO;

namespace TrabalhoPOO
{
    internal class SistemaAgenciaViagens
    {
        // Listas de objetos gerenciados pelo sistema
        private List<Funcionario> funcionarios;
        private List<Usuario> usuarios;
        private List<CompanhiaAerea> companhiasAereas;
        private List<Aeroporto> aeroportos;
        private List<Voo> voos;
        private List<Passagem> passagens;
        private List<VooProgramado> voosProgramados;
        private List<Passageiro> passageirosVIP;

        public SistemaAgenciaViagens()
        {
            funcionarios = new List<Funcionario>();
            usuarios = new List<Usuario>();
            companhiasAereas = new List<CompanhiaAerea>();
            aeroportos = new List<Aeroporto>();
            voos = new List<Voo>();
            passagens = new List<Passagem>();
            voosProgramados = new List<VooProgramado>();
            passageirosVIP = new List<Passageiro>();
            RegistrarLog("INFO", "Sistema de Agência de Viagens iniciado.");
        }

        #region Cadastro de Entidades

        public void CadastrarFuncionario(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
            RegistrarLog("INFO", $"Funcionário {funcionario.getNome()} cadastrado.");
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
            RegistrarLog("INFO", $"Usuário do funcionário {usuario.getFuncionario().getNome()} cadastrado.");
        }

        public void CadastrarCompanhia(CompanhiaAerea companhia)
        {
            companhiasAereas.Add(companhia);
            RegistrarLog("INFO", $"Companhia aérea {companhia.getNome()} cadastrada.");
        }

        public void CadastrarAeroporto(Aeroporto aeroporto)
        {
            aeroportos.Add(aeroporto);
            RegistrarLog("INFO", $"Aeroporto {aeroporto.getNome()} cadastrado.");
        }

        public void CadastrarVoo(Voo voo)
        {
            voos.Add(voo);
            RegistrarLog("INFO", $"Voo de {voo.getAeroportoOrigem().getNome()} para {voo.getAeroportoDestino().getNome()} cadastrado.");
        }

        public void CadastrarPassagem(Passagem passagem)
        {
            passagens.Add(passagem);
            RegistrarLog("INFO", $"Passagem para {passagem.GetPassageiro().getNome()} cadastrada.");
        }

        #endregion

        #region Métodos de Negócio

        public void CancelarVooPassageiroVIP(Passageiro passageiro, ICancelavel voo)
        {
            if (EhVIP(passageiro))
            {
                passageiro.CancelarVooSemCusto(voo);
                RegistrarLog("INFO", $"Voo do passageiro VIP {passageiro.getNome()} cancelado.");
            }
            else
            {
                RegistrarLog("WARNING", $"Tentativa de cancelamento de voo por passageiro não VIP: {passageiro.getNome()}.");
            }
        }

        public void AlterarVooPassageiroVIP(Passageiro passageiro, VooProgramado voo)
        {
            if (EhVIP(passageiro))
            {
                DateTime novaData = DateTime.Now.AddDays(10);
                voo.SetDataHoraPartida(novaData);
                RegistrarLog("INFO", $"Data do voo alterada para o passageiro VIP {passageiro.getNome()} para {novaData}.");
            }
            else
            {
                RegistrarLog("WARNING", $"Tentativa de alteração de voo por passageiro não VIP: {passageiro.getNome()}.");
            }
        }

        #endregion

        #region Registro de Log

        /// <summary>
        /// Registra uma mensagem de log com data, hora e nível.
        /// </summary>
        /// <param name="nivel">Nível do log (INFO, WARNING, ERROR).</param>
        /// <param name="mensagem">Mensagem de log.</param>
        public void RegistrarLog(string nivel, string mensagem)
        {
            string dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string mensagemLog = $"{dataHora} [{nivel}] - {mensagem}";

            try
            {
                string caminhoArquivoLog = "log.txt";
                File.AppendAllText(caminhoArquivoLog, mensagemLog + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar log: {ex.Message}");
            }
        }

        #endregion

        #region Métodos Auxiliares

        public bool EhVIP(Passageiro passageiro) => passageirosVIP.Contains(passageiro);

        #endregion
    }
}
