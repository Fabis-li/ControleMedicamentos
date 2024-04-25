using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento :Entidade    {
      
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

        public string[] Valdiar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Nome))
            {
                erros[0] = "O nome é obrigatório";
                contadorErros++;
            }

            if (string.IsNullOrEmpty(Descricao))
            {
                erros[1] = "A descrição é obrigatória";
                contadorErros++;
            }

            if (Qtde <= 0)
            {
                erros[2] = "A quantidade inserida não pode ser menor ou igual a zero";
                contadorErros++;
            }            

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;

        }
    }
}
