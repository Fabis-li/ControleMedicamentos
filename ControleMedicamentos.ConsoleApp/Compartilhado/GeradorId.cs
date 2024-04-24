namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    public class GeradorId
    {
        private static int IdMedicamento = 0;
        private static int IdPaciente = 0;

        public static int GerarIdMedicamentos()
        {
            return ++IdMedicamento;
        }

        public static int GerarIdPaciente()
        {
            return ++IdPaciente;
        }
    }
}
