using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string CartaoSus { get; set; }

        public Requisicao Requisicao;

        public Paciente()
        {
        }

        public Paciente(string nome, string cpf, string endereco, string cartaoSus)
        {           
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            CartaoSus = cartaoSus;
        }
    }
}
