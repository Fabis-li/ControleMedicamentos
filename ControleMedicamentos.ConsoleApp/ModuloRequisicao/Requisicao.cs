using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao : Entidade
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

        public string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;


            if (Paciente == null)
            {
                erros[0] = "O Paciente é obrigatório.";
                contadorErros++;
            }

            if (Medicamento == null)
            {
                erros[1] = "O medicamento é obrigatório.";
                contadorErros++;
            }

            if (Qtde <= 0)
            {
                erros[2] = "A quantiadde dever ser maior do que zero.";
                contadorErros++;
            }            

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;

        }
    }
}
