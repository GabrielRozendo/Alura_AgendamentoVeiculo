using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AgendamentoCarro
{
    public partial class MasterDetailView : MasterDetailPage
    {
        private readonly Usuario usuario;

        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.Master = new MasterView(usuario);
        }
    }
}
