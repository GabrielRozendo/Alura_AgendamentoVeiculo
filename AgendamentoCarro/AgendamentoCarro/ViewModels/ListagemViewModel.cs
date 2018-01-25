using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AgendamentoCarro
{
    public class ListagemViewModel : BaseViewModel
    {
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com";

        public ObservableCollection<Veiculo> Veiculos { get; set; }

        private Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get { return veiculoSelecionado; }
            set
            {
                veiculoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        public ListagemViewModel()
        {
            Veiculos = new ObservableCollection<Veiculo>();
        }

        private bool busy;
        public bool Busy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
            }
        }

        public async Task GetVeiculos()
        {
            Busy = true;
            HttpClient cliente = new HttpClient();
            var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);
            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

            foreach (var veiculoJson in veiculosJson)
                this.Veiculos.Add(new Veiculo { Nome = veiculoJson.nome, Preco = veiculoJson.preco });
        
            Busy = false;
        }
    }

    class VeiculoJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
