using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : Entidade
    {        
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
            // Requisicao
        }

        public string[] Validar()
        {
            string[] erros = new string[4];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Nome))
            {
                erros[0] = "O nome é obrigatório";
                contadorErros++;
            }

            if (string.IsNullOrEmpty(Cpf))
            {
                erros[1] = "O CPF é obrigatório";
                contadorErros++;
            }

            if (string.IsNullOrEmpty(Endereco))
            {
                erros[2] = "O Endereço é obrigatório!";
                contadorErros++;
            }

            if (string.IsNullOrEmpty(CartaoSus))
            {
                erros[3] = "O número do cartão é obrigatório";
            }

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;

        }
    }
}
