using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente
    {
        private string Nome { get; set; }
        private string Cpf { get; set; }
        private string Endereco { get; set; }
        private string CartaoSus { get; set; }

        public Requisicao Requisicao;

        public Paciente()
        {
        }
    }
}
