using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class RepositorioPaciente
    {
        private static Paciente[] pacientes = new Paciente[100];

        public void CadastrarPaciente(Paciente novoPaciente)
        {
            novoPaciente.Id = GeradorId.GerarIdPaciente();

        }

        public bool EditarPaciente(int id, Paciente novoPaciente)
        {
            novoPaciente.Id = id;

            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i].Id == id)
                {
                    pacientes[i] = novoPaciente;
                    return true;
                }
            }
            return false;
        }

        public bool ExcluirPaciente(int id)
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] == null)
                    continue;
                else if (pacientes[i].Id == id)
                {
                    pacientes[i] = null;
                    return true;
                }
            }
            return false;
        }

        public bool ExistePaciente(int id)
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                Paciente paciente = pacientes[i];

                if (paciente == null)
                    continue;

                else if (paciente.Id == id)
                    return true;
            }
            return false;
        }

        public void RegistrarPaciente(Paciente paciente)
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] != null)
                    continue;
                else
                {
                    pacientes[i] = paciente;
                    break;
                }
            }
        }

        public Paciente[] SelecionarPaciente()
        {
            return pacientes;
        }
    }
}
