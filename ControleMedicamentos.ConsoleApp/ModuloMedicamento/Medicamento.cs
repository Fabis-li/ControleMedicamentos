using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento :EntidadeBase    {
      
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Qtde { get; set; }

        public Medicamento()
        {
        }

        public Medicamento(string nome, string descricao, int qtde)
        {
            Nome = nome;
            Descricao = descricao;
            Qtde = qtde;
        }       

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Nome))
            {
                erros[contadorErros++] = "O nome é obrigatório";                
            }

            if (string.IsNullOrEmpty(Descricao))
            {
                erros[contadorErros++] = "A descrição é obrigatória";                
            }

            if (Qtde <= 0)
            {
                erros[contadorErros++] = "A quantidade inserida não pode ser menor ou igual a zero";               
            }

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}
