using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio8
{
    public partial class Form1 : Form
    {
        List<int> notasTemporales = new List<int>();
        List<NotasAlumno> listaNotas = new List<NotasAlumno>();
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAgregarNota_Click(object sender, EventArgs e)
        {
          

            int nota = Convert.ToInt16(TxtNota.Text);
            notasTemporales.Add(nota);

        }

        private void Grabar()
        {
            string json = JsonConvert.SerializeObject(listaNotas);

            //El nombre del archivo
            string archivo = "Datos.json";

            //Se escribe la variable que contiene el json al archivo en un solo paso
            //con WriteAllText se escribe todo de un solo
            System.IO.File.WriteAllText(archivo, json);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            //Guatda a un alumno con sus notas 
            NotasAlumno notasAlumno = new NotasAlumno();
            notasAlumno.Nombre = TxtNombre.Text;
            notasAlumno.Notas = notasTemporales.GetRange(0, notasTemporales.Count);
             //Guarda a ese alumno en  el listado de notas de alumnos.
            listaNotas.Add(notasAlumno);
            Grabar();
            //Borra las notas temporales para el proxo,p alumno
            notasTemporales.Clear();

        }
    }
}
