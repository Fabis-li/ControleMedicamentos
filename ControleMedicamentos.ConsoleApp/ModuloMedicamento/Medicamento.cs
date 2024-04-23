namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento
    {
        public int Id { get; set; }
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
    }
}
