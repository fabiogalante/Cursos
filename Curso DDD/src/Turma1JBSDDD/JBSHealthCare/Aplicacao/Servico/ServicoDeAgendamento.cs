using JBSHealthCare.Dominio.Entidade;
using JBSHealthCare.Dominio.EventoDominio;
using JBSHealthCare.Dominio.Fabrica;
using JBSHealthCare.Dominio.Interface.Repositorio;
using JBSHealthCare.Infraestrutura.Repositorio;
using JBSHealthCare.View.ViewModels;

namespace JBSHealthCare.Aplicacao.Servico
{
    public class ServicoDeAgendamento
    {
        private readonly IAgendamentos _agendamentos;

        public ServicoDeAgendamento(IAgendamentos agendamentos)
        {
            _agendamentos = agendamentos;
        }

        public bool CriarAgendamento(AgendamentoViewModel agendamentoViewModel)
        {            
            FabricaDeAgendamento fabricaDeAgendamento = new FabricaDeAgendamento();
            Agendamento agendamento =  fabricaDeAgendamento.InformarCID(agendamentoViewModel.numeroCID)
                .InformarMedico(agendamentoViewModel.crm)
                .InformarPaciente(agendamentoViewModel.cpf)
                .Criar();

            _agendamentos.Gravar(agendamento);

            EventosDoDominio.Disparar(new AgendamentoCriado(agendamentoViewModel));

            return true;
        }
    }
}