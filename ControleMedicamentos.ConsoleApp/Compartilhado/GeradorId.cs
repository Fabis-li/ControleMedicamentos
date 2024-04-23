namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    public class GeradorId
    {
        private static int IdMedicamento = 0;

        public static int GerarIdMedicamentos()
        {
            return ++IdMedicamento;
        }
    }
}
