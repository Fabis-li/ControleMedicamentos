using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamento
    {
        private static Medicamento[] medicamentos = new Medicamento[100];
        
        public void CadastrarMedicamento(Medicamento novoMedicamento)
        {
            novoMedicamento.Id = GeradorId.GerarIdMedicamentos();

            RegistrarMedicamento(novoMedicamento);
        }

        public bool EditarMedicamento(int id, Medicamento novoMedicamento)
        {
            novoMedicamento.Id = id;

            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i].Id == id)
                {
                    medicamentos[i] = novoMedicamento;
                    return true;
                }
            }
            return false;
        }

        public bool ExcluirMedicamento(int id)
        {
            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] == null)
                    continue;
                else if (medicamentos[i].Id == id)
                {
                    medicamentos[i] = null;
                    return true;
                }
            }
            return false;
        }

        public Medicamento[] SeleconarMedicamentos()
        {
            return medicamentos;
        }

        public void RegistrarMedicamento(Medicamento medicamento)
        {
            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] != null)
                    continue;
                else
                {
                    medicamentos[i] = medicamento;
                    break;
                }
            }
        }

        public bool ExisteMedicamento(int id)
        {
            for(int i = 0;i < medicamentos.Length;i++)
            {
                Medicamento medicamento = medicamentos[i];

                if (medicamento == null)
                    continue;

                else if(medicamento.Id == id)
                     return true; 
            }
            return false;
        }
    }
}
