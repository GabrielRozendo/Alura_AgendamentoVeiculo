using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class AgendamentoViewPage : ContentPage
    {
        public Veiculo veiculo { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime Data { get; set; } = DateTime.Now.AddDays(1);
        public TimeSpan Hora { get; set; } = new TimeSpan(8, 0, 0);

        public AgendamentoViewPage(Veiculo veiculo)
        {
            this.veiculo = veiculo;
            this.BindingContext = this;
            InitializeComponent();
            DatePicker.MinimumDate = DateTime.Now.AddDays(1);
            DatePicker.MaximumDate = DateTime.Now.AddMonths(3);
        }

        void Agendar_Clicked(object sender, System.EventArgs e)
        {
            var dataHora = Data.Add(Hora);
            DisplayAlert("Agendamento",
                         $"Nome: {Nome}{Environment.NewLine}" +
                         $"Telefone: {Telefone}{Environment.NewLine}" +
                         $"E-mail: {Email}{Environment.NewLine}" +
                         $"Data e hora: {dataHora.ToString("dd/MM/yy HH:mm")}",
                         "Blz então!");
        }
    }
}
