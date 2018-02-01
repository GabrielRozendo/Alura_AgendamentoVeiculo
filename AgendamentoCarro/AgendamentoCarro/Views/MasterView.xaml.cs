using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class MasterView : TabbedPage
    {
        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            BindingContext = new MasterViewModel(usuario);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarMensagens();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil", (usuario) =>
            {
                this.CurrentPage = this.Children[1];
            });

            MessagingCenter.Subscribe<Usuario>(this, "SalvarSucessoPerfil", (usuario) =>
            {
                this.CurrentPage = this.Children[0];
            });
        }

        private void CancelarMensagens()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
            MessagingCenter.Unsubscribe<Usuario>(this, "SalvarSucessoPerfil");
        }
    }
}
