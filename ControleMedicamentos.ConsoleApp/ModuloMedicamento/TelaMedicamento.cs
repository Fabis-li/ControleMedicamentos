﻿using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento
    {
        RepositorioMedicamento repositorio = new RepositorioMedicamento();

        public void telaMedicamento()
        {
            Medicamento medicamentoTeste = new Medicamento("Dipirona", "Analgésico", 100);

            repositorio.Cadastrar(medicamentoTeste);
        }

        public char ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("Gestão Medicamentos");
            Console.WriteLine("----------------------\n");
            Console.WriteLine("1 - Cadastrar Medicamento");
            Console.WriteLine("2 - Listar Medicamentos");
            Console.WriteLine("3 - Editar Medicamento");
            Console.WriteLine("4 - Excluir Medicamento");
            Console.WriteLine("s - Voltar ao Menu\n");

            Console.Write("Digite a opção desejada: ");

            char opcao = Convert.ToChar(Console.ReadLine());

            return opcao;
        }

        public void CadastrarMedicamento()
        {
            Medicamento medicamento = obterMedicamento();

            string[] erros = medicamento.Valdiar();

            if(erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            repositorio.Cadastrar(medicamento);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nChamado cadastrado com sucesso!");
            Console.ResetColor();

            Console.ReadLine();
        }
       

        public void ListarMedicamento(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("Lista de Medicamentos");
                Console.WriteLine("Listando os medicamento....");
                Console.WriteLine();
            }

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                "Id", "Nome", "Descrição", "Qtde");

            EntidadeBase[] medicamentosCadastrados = repositorio.SelecionarTodos();

            foreach(Medicamento medicamento in medicamentosCadastrados)
            {
                if (medicamento == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                    medicamento.Id, medicamento.Nome, medicamento.Descricao, medicamento.Qtde
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        public void EditarMedicamento()
        {
            Console.Clear();
            Console.WriteLine("Editar de Medicamentos");
            Console.WriteLine("Editando um medicamento....\n");

            ListarMedicamento(false);

            Console.WriteLine();
            Console.WriteLine("Digite um ID do medicamento que deseja editar: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            if(!repositorio.Existe(idMedicamento))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("O medicamento escolhido não existe");
                Console.ResetColor();
                return;
            }
            Console.WriteLine();

            Medicamento medicamento = obterMedicamento();

            string[] erros = medicamento.Valdiar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuEditar = repositorio.Editar(idMedicamento, medicamento);

            if(!conseguiuEditar)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Houve um erro durante a edição do medicamento!");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Medicamento editado com sucesso");
            Console.ResetColor();

            Console.ReadLine();
        }

        public void ExcluirMedicamento()
        {
            Console.Clear();
            Console.WriteLine("Excluir de Medicamentos");
            Console.WriteLine("Excluindo um medicamento....");
            Console.WriteLine();
            ListarMedicamento(false);
            Console.WriteLine("\nDigite um ID do medicamento que deseja excluir: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.Existe(idMedicamento))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("O medicamento escolhido não existe!");
                Console.ResetColor();
                return;
            }

            bool conseguiuExcluir = repositorio.Excluir(idMedicamento);

            if (!conseguiuExcluir)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Houve um erro durante a exclusão do medicamento!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Medicamento excluido com sucesso");
            Console.ResetColor();

            Console.ReadLine();
        }

        private Medicamento obterMedicamento()
        {
            Console.Clear();
            Console.WriteLine("Cadastro de Medicamentos");
            Console.WriteLine("Cadastrando um medicamento....");
            Console.WriteLine("\nDigite o nome do medicamento: ");
            string nome = Console.ReadLine();
            Console.WriteLine("\nDigite a descrição do medicamento: ");
            string descricao = Console.ReadLine();
            Console.WriteLine("\nDigite a quantidade de entrada do medicamento: ");
            int qtde = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamento = new Medicamento(nome, descricao, qtde);

            return medicamento;
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
