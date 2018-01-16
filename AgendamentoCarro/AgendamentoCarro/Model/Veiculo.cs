using System;
namespace AgendamentoCarro
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado => string.Format($"R$ {Preco}");
    }
}
