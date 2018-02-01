using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AgendamentoCarro
{
    public class MasterViewModel : BaseViewModel
    {
        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; OnPropertyChanged(); }
        }

        public string DataNascimento
        {
            get { return this.usuario.dataNascimento; }
            set { this.usuario.dataNascimento = value; OnPropertyChanged(); }
        }

        public string Telefone
        {
            get { return this.usuario.telefone; }
            set { this.usuario.telefone = value; OnPropertyChanged(); }
        }

        private bool editando = false;
        public bool Editando
        {
            get { return editando; }
            set { editando = value; OnPropertyChanged(); }
        }

        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand SalvarCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }

        private readonly Usuario usuario;

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            DefinirComandos();
        }

        private void DefinirComandos()
        {
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });

            SalvarCommand = new Command(() =>
            {
                Editando = false;
                MessagingCenter.Send<Usuario>(usuario, "SalvarSucessoPerfil");
            });

            EditarCommand = new Command(() => { Editando = true; });
        }
    }
}
