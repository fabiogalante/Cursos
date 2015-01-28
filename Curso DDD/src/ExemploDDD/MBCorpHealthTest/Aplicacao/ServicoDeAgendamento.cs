﻿using MBCorpHealthTest.Dominio.Contratos;
using MBCorpHealthTest.Dominio.Entidades;

namespace MBCorpHealthTest.Aplicacao
{
    public class ServicoDeAgendamento
    {
        private readonly IServicoDeEnvioEmail _servicoDeEnvioEmail;
        private readonly IServicoDeGeracaoCredencial _servicoDeGeracaoCredencial;

        public ServicoDeAgendamento(IServicoDeEnvioEmail servicoDeEnvioEmail,IServicoDeGeracaoCredencial servicoDeGeracaoCredencial)
        {
            _servicoDeEnvioEmail = servicoDeEnvioEmail;
            _servicoDeGeracaoCredencial = servicoDeGeracaoCredencial;
        }

        public Agendamento CadastrarAgendamento(Agendamento agendamento)
        {
            //Persistir na Base
            agendamento.Credencial = _servicoDeGeracaoCredencial.Gerar(agendamento.Paciente);
            


            //Enviar Email
            _servicoDeEnvioEmail.Enviar("mbcorp@mbcorp.com.br", agendamento.Paciente.Email, "Agendamento Confirmado", "Mensagem para o paciente + dados da Credenical");

            

            return agendamento;
        }
    }
}