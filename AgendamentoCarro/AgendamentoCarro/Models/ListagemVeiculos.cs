using System.Collections.Generic;

namespace AgendamentoCarro
{
    public class ListagemVeiculos
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemVeiculos()
        {
            Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azera V6", Preco = 60000, PrecoArCondicionado=1500, PrecoFreioAbs= 1200 },
                new Veiculo { Nome = "Fiesta 2.0", Preco = 50000, PrecoArCondicionado=1200 },
                new Veiculo { Nome = "HB20 S", Preco = 40000 },
                new Veiculo { Nome = "Hilux 4x4", Preco = 90000, PrecoArCondicionado=1500 },
            };
        }
    }
}
