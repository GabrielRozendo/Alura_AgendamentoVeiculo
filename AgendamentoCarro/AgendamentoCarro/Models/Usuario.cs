using System;
namespace AgendamentoCarro
{
    public class Usuario
    {
        public int id;
        public string nome;
        public string dataNascimento;
        public string telefone;
        public string email { get; set; }
    }

    public class ResultadoLogin
    {
        public Usuario usuario { get; set; }
    }
}
