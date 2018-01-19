using System;
namespace AgendamentoCarro
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado => string.Format($"R$ {Preco}");

        public decimal PrecoFreioAbs = 800;
        public decimal PrecoArCondicionado = 1000;
        public decimal PrecoMP3Player = 500;

        public string TextoFreioAbs => $"Freio ABS - {PrecoFreioAbs.ToMoeda()}";
        public string TextoArCondicionado => $"Ar Condicionado - {PrecoArCondicionado.ToMoeda()}";
        public string TextoMP3Player => $"MP3 Player - {PrecoMP3Player.ToMoeda()}";

        public bool TemFreioAbs { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemMP3Player { get; set; }

        public decimal ValorTotal { get; set; }
        public string TextoValorTotal => $"Valor total: {ValorTotal.ToMoeda()}";

        public void AtualizarValor(decimal valor, bool somar)
        {
            if (somar)
                ValorTotal += valor;
            else
                ValorTotal -= valor;
        }
    }
}
