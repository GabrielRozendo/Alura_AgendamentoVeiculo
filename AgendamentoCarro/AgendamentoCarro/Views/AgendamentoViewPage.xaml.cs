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

        void Agendar_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Agendamento",
                         $"Nome: {ViewModel.Nome}{Environment.NewLine}" +
                         $"Telefone: {ViewModel.Telefone}{Environment.NewLine}" +
                         $"E-mail: {ViewModel.Email}{Environment.NewLine}" +
                         $"Data e hora: {ViewModel.DataHora}", //.ToString("dd/MM/yy HH:mm")
                         "Blz então!");
        }
    }
}
