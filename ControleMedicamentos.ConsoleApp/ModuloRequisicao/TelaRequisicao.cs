using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaRequisicao
    {
        RepositorioRequisicao repositorio = new RepositorioRequisicao();

        TelaPaciente telaPaciente = null;

        public char ApresentarMenu()
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("Gestão de Requisições");
            Console.WriteLine("----------------------\n");
            Console.WriteLine("1 - Cadastrar Requisição");
            Console.WriteLine("2 - Listar Requisições");
            Console.WriteLine("3 - Editar Requisição");
            Console.WriteLine("4 - Excluir Requisição");
            Console.WriteLine("s - Voltar ao Menu\n");

            Console.Write("Digite a opção desejada: ");

            char opcao = Convert.ToChar(Console.ReadLine());

            return opcao;
        }

        public void CadastrarRequisicao()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Pacientes");
            Console.WriteLine("Cadastrando um paciente....");

            Requisicao requisicao = ObterRequisicao();

            string[] erros =requisicao.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            repositorio.Cadastrar(requisicao);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nChamado cadastrado com sucesso!");
            Console.ResetColor();

            Console.ReadLine();
        }

        private Requisicao ObterRequisicao()
        {
           
            //Todo Vizualizar Pacientes

            telaPaciente.ListarPaciente(false);

            bool conseguiuConverter = false;

            int idPaciente = 0;

            while (!conseguiuConverter)
            {
                Console.WriteLine("\nDigite o Id do paciente: ");
                conseguiuConverter = int.TryParse(Console.ReadLine(), out idPaciente);

                if (!conseguiuConverter)
                    Console.WriteLine("Por favor, informe umm Id válido\n");
            }
            
            Console.WriteLine("\nDigite o Id do medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nDigite digite a quantidade do medicamento: ");
            int qtde = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a validade da Requisição: ");
            DateTime dataValidade = Convert.ToDateTime(Console.ReadLine());
            


            Requisicao requisicao = new Requisicao();

            return requisicao;
        }

        private void ApresentarErros(string[] erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Length; i++)
                Console.WriteLine(erros[i]);

            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
