using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao : EntidadeBase
    {        
        Paciente Paciente { get; set; }
        Medicamento Medicamento { get; set; }
        private int Qtde { get; set; }
        DateTime DataValidade { get; set; }

        public Requisicao()
        {
        }

        public Requisicao(Paciente paciente, Medicamento medicamento,  int qtde, DateTime dataValidade)
        {
            Paciente = paciente;
            Medicamento = medicamento;
            Qtde = qtde;
            DataValidade = dataValidade;
        }
        
        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;


            if (Paciente == null)
            {
                erros[contadorErros++] = "O Paciente é obrigatório.";               
            }

            if (Medicamento == null)
            {
                erros[contadorErros++] = "O medicamento é obrigatório.";               
            }

            if (Qtde <= 0)
            {
                erros[contadorErros++] = "A quantiadde dever ser maior do que zero.";                
            }

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}
