using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente
    {
        RepositorioPaciente repositorio = new RepositorioPaciente();

        public TelaPaciente()
        {
            Paciente pacienteTeste = new Paciente("João", "123.456.789-00", "Rua 1", "123456789");

            repositorio.Cadastrar(pacienteTeste);
        }

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

            Paciente paciente = ObterPaciente();

            string[] erros = paciente.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            repositorio.Cadastrar(paciente);

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

            Entidade[] pacienteCadastrados = repositorio.SelecionarTodos();

            foreach(Paciente paciente in pacienteCadastrados) 
            {
                if (paciente == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -20} | {2, -15} | {3, -30} | {4, -20}",
                    paciente.Id, paciente.Nome, paciente.Cpf, paciente.Endereco, paciente.CartaoSus
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

            if (!repositorio.Existe(idPaciente))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("O paciente escolhido não existe");
                Console.ResetColor();
                return;
            }
            Console.WriteLine();

            Paciente novoPaciente = ObterPaciente();

            string[] erros = novoPaciente.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuEditar = repositorio.Editar(idPaciente, novoPaciente);

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

            if (!repositorio.Existe(idPaciente))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("O medicamento escolhido não existe!");
                Console.ResetColor();
                return;
            }

            bool conseguiuExcluir = repositorio.Excluir(idPaciente);

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

        private Paciente ObterPaciente()
        {
            
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

            return paciente;
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
