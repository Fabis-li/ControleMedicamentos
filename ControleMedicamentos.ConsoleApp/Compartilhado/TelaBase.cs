namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    public abstract class TelaBase
    {
        public string tipoEntidade = "";
        public RepositorioBase repositorio = null;

        public char ApresntarMenu()
        {            
            Console.Clear();
            Console.WriteLine($"Gestão de {tipoEntidade}");
            Console.WriteLine("----------------------\n");
            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Listar {tipoEntidade}");
            Console.WriteLine($"3 - Editar {tipoEntidade}");
            Console.WriteLine($"4 - Excluir {tipoEntidade}");

            Console.WriteLine("s - Voltar ao Menu\n");

            Console.WriteLine();

            Console.Write("Digite a opção desejada: ");
            char opcao = Convert.ToChar(Console.ReadLine());

            return opcao;
        }

        public void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            EntidadeBase entidade = ObterRegistro();

            string[] erros = entidade.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            repositorio.Cadastrar(entidade);

            Console.WriteLine($"O {tipoEntidade} foi cadastrado com sucesso!");
        }



        protected void ApresentarErros(string[] erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for(int i = 0; i < erros.Length; i++)
                Console.WriteLine(erros[i]);

            Console.ResetColor();
            Console.ReadLine();
            
        }       

        protected void ApresentarCabecalho()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Controle de Medicamentos      |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
        }
        protected abstract EntidadeBase ObterRegistro();
    }
}
