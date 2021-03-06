﻿using System;
using System.Collections.Generic;
using System.Linq;
using MBCorpHealthTest.Dominio.ContextoCadastrosCorporativos.Entidades;

namespace MBCorpHealthTest.Dominio.ContextoAdministracaoDeAgendamentosDeExame.Entidades
{
    public class Agendamento
    {
        public IEnumerable<Exame> Exames { get; protected set; }
        public int ID { get; set; }
        public Atendente Atendente { get; protected set; }
        public Paciente Paciente { get; protected set; }
        public Medico MedicoSolicitante { get; protected set; }
        public Credencial Credencial{ get;  set; }

        public Agendamento(Paciente paciente, Medico medico, Atendente atendente)
        {
            Paciente = paciente;
            MedicoSolicitante = medico;
            Atendente = atendente;

            }

        protected Agendamento()
        {
        }

        public void AdicionarExame(Exame tipoExame)
        {
            Exames = new List<Exame>();
            ((IList<Exame>)Exames).Add(tipoExame);

        }
    
        public Double CalcularValorTotal()
        {
            Double valorTotal = Exames.Sum(exame => exame.TipoExame.Valor);
            return valorTotal;
        }
    }
}