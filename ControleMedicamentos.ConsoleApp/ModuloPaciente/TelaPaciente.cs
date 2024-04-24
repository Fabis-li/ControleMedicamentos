using ControleMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente
    {
        RepositorioPaciente repositorio = new RepositorioPaciente();

        public char ApresentarMenu()
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("Gestão Pacientes");
            Console.WriteLine("----------------------\n");
            Console.WriteLine("1 - Cadastrar Paciente");
            Console.WriteLine("2 - Listar Pacientes");
            Console.WriteLine("3 - Editar Paciente");
            Console.WriteLine("4 - Excluir Paciente");
            Console.WriteLine("s - Voltar ao Menu\n");

            Console.Write("Digite a opção desejada: ");

            char opcao = Convert.ToChar(Console.ReadLine());

            return opcao;
        }

        public void CadastrarPaciente()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Pacientes");
            Console.WriteLine("Cadastrando um paciente....");
            Console.WriteLine("\nDigite o nome do paciente: ");
            string nome = Console.ReadLine();
            Console.WriteLine("\nDigite o CPF do paciente: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("\nDigite o endereço do paciente: ");
            string endereco = Console.ReadLine();
            Console.WriteLine("Digite o numero do cartão so sus: ");
            string cartaoSus = Console.ReadLine();

            //ToDo Requisição

            Paciente paciente = new Paciente(nome, cpf, endereco, cartaoSus);

            repositorio.CadastrarPaciente(paciente);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nChamado cadastrado com sucesso!");
            Console.ResetColor();

            Console.ReadLine();
        }

        public void ListarPaciente(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("Lista de Pacientes");
                Console.WriteLine("Listando os pacientes....");
                Console.WriteLine();
            }

            Console.WriteLine("{0, -10} | {1, -20} | {2, -15} | {3, -30} | {4, -20}",
                "Id", "Nome", "CPF", "Endereço", "Número CartãoSUS");

            Paciente[] pacienteCadastrados = repositorio.SelecionarPaciente();

            for (int i = 0; i < pacienteCadastrados.Length; i++)
            {
                Paciente p = pacienteCadastrados[i];

                if (p == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -20} | {2, -15} | {3, -30} | {4, -20}",
                    p.Id, p.Nome, p.Cpf, p.Endereco, p.CartaoSus
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        public void EditarPaciente()
        {
            Console.Clear();
            Console.WriteLine("Editar de Paciente");
            Console.WriteLine("Editando um paciente....\n");

            ListarPaciente(false);

            Console.WriteLine();
            Console.WriteLine("Digite um ID do paciente que deseja editar: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.ExistePaciente(idPaciente))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("O paciente escolhido não existe");
                Console.ResetColor();
                return;
            }
            Console.WriteLine();

            Console.WriteLine("\nDigite o nome do paciente: ");
            string nome = Console.ReadLine();
            Console.WriteLine("\nDigite o CPF do paciente: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("\nDigite o endereço do paciente: ");
            string endereco = Console.ReadLine();
            Console.WriteLine("Digite o numero do cartão so sus: ");
            string cartaoSus = Console.ReadLine();

            Paciente novoPaciente = new Paciente(nome, cpf, endereco, cartaoSus);

            bool conseguiuEditar = repositorio.EditarPaciente(idPaciente, novoPaciente);

            if (!conseguiuEditar)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Houve um erro durante a edição do paciente!");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Paciente editado com sucesso");
            Console.ResetColor();

            Console.ReadLine();
        }

        public void ExcluirPaciente()
        {
            Console.Clear();
            Console.WriteLine("Excluir Paciente");
            Console.WriteLine("Excluindo um paciente....");
            Console.WriteLine();
            ListarPaciente(false);
            Console.WriteLine("\nDigite um ID do paciente que deseja excluir: ");
            int idPaciente = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.ExistePaciente(idPaciente))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("O medicamento escolhido não existe!");
                Console.ResetColor();
                return;
            }

            bool conseguiuExcluir = repositorio.ExcluirPaciente(idPaciente);

            if (!conseguiuExcluir)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Houve um erro durante a exclusão do paciente!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Paciente excluido com sucesso");
            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
