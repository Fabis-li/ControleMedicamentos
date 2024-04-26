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
            Console.WriteLine("Cadastro de Requisição");
            Console.WriteLine("Cadastrando uma requisição....");

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

        public void ListarRequisicao(bool exibirTitulo)
        {
            if(exibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("Lista de Requisições");
                Console.WriteLine("Listando as requisições....");
                Console.WriteLine();
            }

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                "Id", "Paciente", "Medicamento", "Qtde");

            Entidade[] requisicoesCadastradas = repositorio.SelecionarTodos();

            foreach (Requisicao requisicao in requisicoesCadastradas)
            {
                if (requisicao == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                    requisicao.Id, requisicao.Paciente.Nome, requisicao.Medicamento.Nome, requisicao.Qtde);
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        public void EditarRequisicao()
        {
            Console.Clear();
            Console.WriteLine("Editar Requisição");
            Console.WriteLine("Editando uma requisição....");

            VisualizarRequisicao(false);

            Console.WriteLine("Digite o Id da requisição que deseja editar: ");
            int idReqiusicao = Convert.ToInt32(Console.ReadLine());

            if(!RepositorioRequisicao.Existe(idReqiusicao))
            {
                Console.WriteLine("Requisição não encontrada");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();

            Requisicao requisicao = ObterRequisicao();

            string[] erros = requisicao.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuEditar = repositorio.Editar(idReqiusicao, requisicao);

            if(!conseguiuEditar)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nRequisição não encontrada");
                Console.ResetColor();
            }
           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRequisição editada com sucesso!");
            Console.ResetColor();
        }

        public void ExcluirRequisicao()
        {
            Console.Clear();
            Console.WriteLine("Excluir Requisição");
            Console.WriteLine("Excluindo uma requisição....");

            VisualizarRequisicao(false);

            Console.WriteLine("Digite o Id da requisição que deseja excluir: ");
            int idReqiusicao = Convert.ToInt32(Console.ReadLine());

            if (!RepositorioRequisicao.Existe(idReqiusicao))
            {
                Console.WriteLine("Requisição não encontrada");
                Console.ReadLine();
                return;
            }

            bool conseguiuExcluir = repositorio.Excluir(idReqiusicao);

            if (!conseguiuExcluir)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nRequisição não encontrada");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRequisição excluída com sucesso!");
            Console.ResetColor();
        }

        private Requisicao ObterRequisicao()
        {
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

            Paciente pacienteSelecionadao = (Paciente)telaPaciente.SelecionarPorId(idPaciente);
            
            telaMedicamento.ListarMedicamento(false);

            bool conseguiuConverterMedicamento = false;

            int idMedicamento = 0;

            while(!conseguiuConverterMedicamento)
            {
                Console.WriteLine("\nDigite o Id do medicamento: ");
                conseguiuConverterMedicamento = int.TryParse(Console.ReadLine(), out idMedicamento);

                if (!conseguiuConverterMedicamento)
                    Console.WriteLine("Por favor, informe um Id válido\n");
            }

            Medicamento medicamentoSelecionado = (Medicamento)telaMedicamento.SelecionarPorId(idMedicamento);

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
