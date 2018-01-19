using System;

namespace AgendamentoCarro
{
    public class Agendamento
    {
        public Veiculo Veiculo { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime Data { get; set; } = DateTime.Now.AddDays(1);
        public TimeSpan Hora { get; set; } = new TimeSpan(8, 0, 0);

        public DateTime DataHora => Data.Add(Hora);

        public Agendamento() { }
    }
}
