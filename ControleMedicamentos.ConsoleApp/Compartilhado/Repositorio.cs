namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    public class Repositorio
    {
        protected Entidade[] registros = new Entidade[100];
        protected int contadorId = 1;

        public void Cadastrar(Entidade novoRegistro)
        {
            novoRegistro.Id = contadorId;

            Registrar(novoRegistro);
        }        

        public bool Editar(int id, Entidade novoRegistro)
        {
            novoRegistro.Id = id;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i].Id == id)
                {
                    registros[i] = novoRegistro;
                    return true;
                }
            }
            return false;
        }

        public bool Excluir(int id)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                    continue;
                else if (registros[i].Id == id)
                {
                    registros[i] = null;
                    return true;
                }
            }
            return false;
        }       

        public Entidade[] SelecionarTodos()
        {
            return registros;
        }

        public Entidade SelecionarPorId(int id)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                Entidade e = registros[i];

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return e;
            }

            return null;
        }
        public bool Existe(int id)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                Entidade e = registros[i];

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return true;
            }
            return false;
        }

        public void Registrar(Entidade novoRegistro)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                    continue;
                else
                {
                    registros[i] = novoRegistro;
                    break;
                }
            }
        }

    }
}
