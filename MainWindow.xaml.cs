using Microsoft.Win32;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

using System;

using System.IO;

mateo down


namespace archivos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // ---- CARGAR IMAGEN ----
        private void BtnCargarImagen_Click(object sender, RoutedEventArgs e)
        {
            // Crea una nueva instancia del cuadro de diálogo para abrir archivos.
            OpenFileDialog openFile = new OpenFileDialog();

            // Establece un filtro para que solo se muestren archivos de imagen (JPG, PNG y BMP).
            openFile.Filter = "Archivos de imagen|*.jpg;*.png;*.bmp";

            // Abre el cuadro de diálogo y verifica si el usuario seleccionó un archivo (retorna true si se presiona “Abrir”).
            if (openFile.ShowDialog() == true)
            {
                // Crea un nuevo control de tipo Image para mostrar la imagen seleccionada.
                Image imagen = new Image();

                // Asigna la ruta del archivo seleccionado a la propiedad Source del control Image.
                // BitmapImage convierte la ruta (URI) en una imagen visible.
                imagen.Source = new BitmapImage(new Uri(openFile.FileName));

                // Define la altura de la imagen en píxeles.
                imagen.Height = 250;

                // Agrega un margen de 5 píxeles alrededor de la imagen.
                imagen.Margin = new Thickness(5);

                // Limpia cualquier contenido previo dentro del contenedor (por ejemplo, otra imagen anterior).
                VistaArchivos.Children.Clear();

                // Agrega la imagen al contenedor StackPanel llamado VistaArchivos.
                VistaArchivos.Children.Add(imagen);
            }
        }

        // ---- CARGAR PDF ----
        private void BtnCargarPDF_Click(object sender, RoutedEventArgs e)
        {
            // Crea un cuadro de diálogo para seleccionar archivos PDF.
            OpenFileDialog openFile = new OpenFileDialog();

            // Filtra para mostrar solo archivos con extensión .pdf.
            openFile.Filter = "Archivos PDF|*.pdf";

            // Abre el diálogo y verifica si el usuario seleccionó un archivo.
            if (openFile.ShowDialog() == true)
            {
                // Limpia el contenido actual del panel de vista.
                VistaArchivos.Children.Clear();

                // Crea un control de texto (TextBlock) para mostrar el nombre del archivo cargado.
                TextBlock texto = new TextBlock
                {
                    // Muestra el mensaje con el nombre del archivo seleccionado.
                    Text = "Archivo PDF cargado: " + System.IO.Path.GetFileName(openFile.FileName),

                    // Define el tamaño de fuente para que se vea claro.
                    FontSize = 16
                };

                // Agrega el texto al contenedor principal.
                VistaArchivos.Children.Add(texto);

                // Abre el archivo PDF con el programa predeterminado del sistema (por ejemplo, Adobe Reader).
                Process.Start(new ProcessStartInfo(openFile.FileName) { UseShellExecute = true });
            }
        }


        // ---- CARGAR WORD ----
        private void BtnCargarWord_Click(object sender, RoutedEventArgs e)
        {
            // Crea el cuadro de diálogo para seleccionar archivos Word.
            OpenFileDialog openFile = new OpenFileDialog();

            // Solo se mostrarán archivos con extensión .doc y .docx.
            openFile.Filter = "Documentos Word|*.doc;*.docx";

            // Abre el diálogo y verifica si el usuario seleccionó un archivo.
            if (openFile.ShowDialog() == true)
            {
                // Limpia cualquier contenido mostrado anteriormente.
                VistaArchivos.Children.Clear();

                // Crea un texto informativo con el nombre del archivo Word.
                TextBlock texto = new TextBlock
                {
                    Text = "Archivo Word cargado: " + System.IO.Path.GetFileName(openFile.FileName),
                    FontSize = 16
                };

                // Muestra el texto en el área de visualización.
                VistaArchivos.Children.Add(texto);

                // Abre el archivo Word con el programa predeterminado (por ejemplo, Microsoft Word o WPS).
                Process.Start(new ProcessStartInfo(openFile.FileName) { UseShellExecute = true });
            }
        }


        // ---- CARGAR GIF ----
        private void BtnCargarGIF_Click(object sender, RoutedEventArgs e)
        {
            // Crea el cuadro de diálogo para seleccionar archivos GIF.
            OpenFileDialog openFile = new OpenFileDialog();

            // Filtra para mostrar únicamente archivos con extensión .gif.
            openFile.Filter = "Archivos GIF|*.gif";

            // Abre el cuadro de diálogo y verifica si el usuario seleccionó un archivo.
            if (openFile.ShowDialog() == true)
            {
                // Limpia el contenido previo del contenedor.
                VistaArchivos.Children.Clear();

                // Crea un control Image para mostrar el GIF animado.
                Image gif = new Image();

                // Asigna la fuente del GIF desde la ruta seleccionada.
                gif.Source = new BitmapImage(new Uri(openFile.FileName));

                // Define la altura con la que se mostrará el GIF.
                gif.Height = 250;

                // Agrega un margen de 5 píxeles alrededor del control.
                gif.Margin = new Thickness(5);

                // Muestra el GIF dentro del StackPanel.
                VistaArchivos.Children.Add(gif);
            }
        }


    }
}