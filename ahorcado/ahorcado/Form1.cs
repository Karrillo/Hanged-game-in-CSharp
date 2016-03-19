using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Juego : Form
    {
        public Juego()
        {
            InitializeComponent();
            this.Visible = true;
        }

        //Variables         
        int Vidas = 7;
        int x = 0;
        char lletra;
        Boolean LetraB;
        string palabraSeleccionada;//contiene la palabra
        char[] palabra; //contiene la variable charpalabra
        char[] completa;//contiene la variable palabracompletandose
        
        
        
      
     
        private void Juego_Load(object sender, EventArgs e)
        {
            //Arreglo
            string[] Palabras = new string[] { "perfecto","ventilador","television","ropero","estufa","linterna",
                "ventana","espejo","cortina","puerta","almohada","sabana","elefante","gaviota","delfin","vibora",
                "ballena","gusano","hamster","caballo","rinoceronte","pescado","camaron","tortuga","cabeza","oreja",
                "labio","pestaña","tobillo","rodilla","brazo","antebrazo","manzana","zanahoria","platano","calabaza",
                "papaya","aguacate","brocoli","cebolla","chayote","rabano","vehiculo","avioneta","pantalon","camiseta",
                "tomate","ballena","teclado","monitor","sombrero","camaleon","lagartija","Cuadrado","internet", 
                "examen","lapicero","celular","camara","plancha","zopilote","control","muñeco"};

            //variable random
            //rad es random
            Random Varios = new Random();
            int Rand = Varios.Next(Palabras.Length);

            //Cantidad de letras que tiene la palabra             
            int letra = Palabras[Rand].Length;      

            //convertir la palabra en una cadena de letras "char"
            // letra 2 contiene la palabra en string
            string letra2= Palabras[Rand];
            palabraSeleccionada = letra2;
            char[] charpalabra = letra2.ToCharArray();
            palabra = charpalabra;
                 
            // pasar la palabra en cadena de letras y que sea igual a " _ "
            char[] palabraCompletandose = letra2.ToCharArray();
            for (int i = 0; i < letra; i++)
            {
                palabraCompletandose[i] = '_';
            }
            completa = palabraCompletandose;
            string PalabraComple2 = Convert.ToString(palabraCompletandose[x]);               
            label1.Text = ("La palabra tiene " + letra + " letras");
            }                                 
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {        
            // ciclo del juego    
            lletra = e.KeyChar;  //guarda la letras ingresada
            textBox1.Text = "";
            LetraB = false;
            for (x = 0; x < palabra.Length; x++)
            {   //buenas
                if (lletra == palabra[x])//comprueba si esta la letra
                {
                    completa[x] = lletra;//comoda la letra
                    LetraB = true;
                }
                //imprime las " _ " y espacios
                String text = "";
                for (int i = 0; i < palabra.Length; i++)
                {  //escribe en su lugar la letra q corresponde
                    text = text + completa[i];
                    text += " ";//espacios 
                    label3.Text = text;                   
                }     
            }           
            //pierde
            if (LetraB != true)
            {
                //imagen
                String direccion = "C:\\Users\\Karrillo\\Dropbox\\Univerdad Catolica\\Tareas\\introduccion a la programacion\\Segundo Proyecto\\Proyecto2\\ahorcado\\imagenes\\ahorcado" + (7 - Vidas) + ".jpg";
                Vidas--;
                listBox1.Items.Add(lletra);  //imprime letras en la lista
                MessageBox.Show("INCORRECTA");                                
                pictureBox2.ImageLocation = direccion;
            }                                 
            if (Vidas == 0)
            {
                MessageBox.Show("Has PERDIDO!!!La palabra era: " + palabraSeleccionada);
                groupBox1.Visible = true;//Muestra el grupo de texto
            }
            //!=negacion    // si no contiene  " _ "  
            //Gana
            if (!completa.Contains('_'))
            {
                MessageBox.Show("FELICIDADES!! Has GANADO !!! La palabra es correcta");
                groupBox1.Visible = true;//Muestra el grupo de texto
            }
            label2.Text = ("Vidas: " + Vidas);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
   }
}
    

       