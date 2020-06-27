using System;

namespace DesafioBackEndDevIII.Api.DTO
{
    public class ClienteDto
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
