using System;
namespace AgendamentoCarro
{
    public class AgendamentoViewModel
    {
        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public DateTime DataHora => Data.Add(Hora);

        public AgendamentoViewModel(Veiculo veiculo)
        {
            Veiculo = veiculo;

            this.Agendamento = new Agendamento();
            Veiculo = this.Agendamento.Veiculo = veiculo;
            Data = this.Agendamento.Data;
            Hora = this.Agendamento.Hora;
        }
    }
}
