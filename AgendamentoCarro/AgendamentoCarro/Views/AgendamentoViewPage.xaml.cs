using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class AgendamentoViewPage : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }

        public AgendamentoViewPage(Veiculo veiculo)
        {
            InitializeComponent();
            DatePicker.MinimumDate = DateTime.Now.AddDays(1);
            DatePicker.MaximumDate = DateTime.Now.AddMonths(3);

            ViewModel = new AgendamentoViewModel(veiculo);
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendar", async (msg) =>
            {
                var confirma = await DisplayAlert("Continuar?", "Deseja mesmo enviar o agendamento?", "Sim", "Não");

                if (confirma)
                {
                    ViewModel.SalvarAgendamento();
                    /* await DisplayAlert("Agendamento",
                        $"Nome: {ViewModel.Nome}{Environment.NewLine}" +
                        $"Telefone: {ViewModel.Telefone}{Environment.NewLine}" +
                        $"E-mail: {ViewModel.Email}{Environment.NewLine}" +
                        $"Data e hora: {ViewModel.DataHora.ToString()}", //.ToString("dd/MM/yy HH:mm")
                        "Blz então!");*/
                }
            });

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Agendamento salvo com sucesso!", "Blz");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "ErroAgendamento", (msg) =>
            {
                DisplayAlert("Agendamento", "Falha ao agendar o test drive! Verifique sua conexão e tente novamente!" + Environment.NewLine + msg.Message, ":(");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendar");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "ErroAgendamento");
        }
    }
}
