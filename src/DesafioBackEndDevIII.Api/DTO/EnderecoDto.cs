using System;

namespace DesafioBackEndDevIII.Api.DTO
{
    public class EnderecoDto
    {
        public Guid EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
