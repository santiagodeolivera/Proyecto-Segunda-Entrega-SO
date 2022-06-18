using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSO
{
    public static class Utils
    {
        /// <summary>
        /// Realiza un chequeo. Si es true, envía un mensaje y devuelve true.
        /// </summary>
        /// <param name="chequeo">El chequeo a realizar. Se representa mediante una funcion que devuelve true si se detecto un error.</param>
        /// <param name="mensaje">El mensaje a mostrar.</param>
        /// <returns>true si el chequeo </returns>
        public static bool ChequearInput(bool chequeo, string mensaje)
        {
            if (chequeo)
            {
                MessageBox.Show(
                        mensaje, "",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Carga en una ListBox el contenido de un enumerable de elementos, en formato de tabla.
        /// </summary>
        /// <typeparam name="T">El tipo de elementos mostrados.</typeparam>
        /// <param name="listBox">El ListBox que va a mostrar la tabla.</param>
        /// <param name="lista">El enumerable de elementos.</param>
        /// <param name="titulo">Un titulo opcional de la tabla</param>
        /// <param name="formato">El formato que coloca a las propiedades de los elementos en su respectivo lugar</param>
        /// <param name="propiedades">Las propiedades a colocar en un encabezado, opcional</param>
        /// <param name="conversor">La funcion para procesar los datos en propiedades de la tabla</param>
        public static void CargarLista<T>(ListBox listBox, IEnumerable<T> lista, string titulo, string formato, string[] propiedades, Func<T, object[]> conversor)
        {
            // Limpiar el contenido actual
            listBox.Items.Clear();

            // Añadir el titulo
            if (titulo != null)
            {
                listBox.Items.Add(titulo);
            }

            if (!lista.Any())
            {
                listBox.Items.Add("(Ninguno)");
                return;
            }

            if (propiedades != null)
            {
                listBox.Items.Add(string.Format(formato, propiedades));
            }

            foreach (T el in lista)
            {
                listBox.Items.Add(string.Format(formato, conversor.Invoke(el)));
            }
        }
    }
}
