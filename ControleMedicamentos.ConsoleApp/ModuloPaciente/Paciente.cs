using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : EntidadeBase
    {        
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string CartaoSus { get; set; }

        public Requisicao Requisicao;

        public Paciente()
        {
        }

        public Paciente(string nome, string cpf, string endereco, string cartaoSus, Requisicao requisicao)
        {           
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            CartaoSus = cartaoSus;
            Requisicao = requisicao;
        }       

        public override string[] Validar()
        {
            string[] erros = new string[4];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Nome))
            {
                erros[contadorErros++] = "O nome é obrigatório";                
            }

            if (string.IsNullOrEmpty(Cpf))
            {
                erros[contadorErros++] = "O CPF é obrigatório";               
            }

            if (string.IsNullOrEmpty(Endereco))
            {
                erros[contadorErros++] = "O Endereço é obrigatório!";               
            }

            if (string.IsNullOrEmpty(CartaoSus))
            {
                erros[contadorErros++] = "O número do cartão é obrigatório";
            }

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}
