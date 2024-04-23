using ControleMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleMedicamentos.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            TelaMedicamento telaMedicamento = new TelaMedicamento();

            bool opcaoSairEscolhida = false;

            while (!opcaoSairEscolhida)
            {
                char operacaoEscolhida = Opcoes();

                switch (operacaoEscolhida)
                {
                    case '1':
                        char opMedicamento = telaMedicamento.ApresentarMenu();

                        if (opMedicamento == 'S' ||  opMedicamento == 's')
                        break;

                        if (opMedicamento == '1')
                            telaMedicamento.CadastrarMedicamento();

                        else if (opMedicamento == '2')
                            telaMedicamento.ListarMedicamento(true);

                        else if (opMedicamento == '3')
                            telaMedicamento.EditarMedicamento();

                        else if (opMedicamento == '4')
                            telaMedicamento.ExcluirMedicamento();
                        break;

                    default: opcaoSairEscolhida = true; break;
                }


            }

            static char Opcoes()
            {
                Console.Clear();
                Console.WriteLine("Gestão de Medicamentos");
                Console.WriteLine("-----------------------\n");
                Console.WriteLine("1 - Controle de Medicamentos");
                Console.WriteLine("2 - Gestao de Paciente");
                Console.WriteLine("3 - Requisições");
                Console.WriteLine("s - Sair");

                Console.WriteLine();

                Console.Write("Digite a opção desejada: ");
                char opcaoEscolhida = Convert.ToChar(Console.ReadLine());

                return opcaoEscolhida;
            }
        }
    }
}
