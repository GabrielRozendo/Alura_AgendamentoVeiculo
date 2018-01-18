using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class AgendamentoViewPage : ContentPage
    {
        public Veiculo veiculo { get; set; }

        public AgendamentoViewPage(Veiculo veiculo)
        {
            this.veiculo = veiculo;
            this.BindingContext = veiculo;
            InitializeComponent();
        }
    }
}
