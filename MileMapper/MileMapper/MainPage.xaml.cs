using System;
using System.Net.Http;
using Xamarin.Forms;

namespace MileMapper
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            miFrame.IsVisible = false;
        }

        private async void ConvertirButton_Clicked(object sender, EventArgs e)
        {
            // Obtener el valor de kilómetros del Entry
            if (!string.IsNullOrEmpty(KilometrosEntry.Text) && double.TryParse(KilometrosEntry.Text, out double kilometros))
            {
                try
                {
                    // Realizar la petición GET a la API
                    HttpClient client = new HttpClient();
                    string url = $"https://isdlc.bsite.net/KilometroAMilla/ConvertirKilometrosAMillas?kilometros={kilometros}";
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Verificar si la petición fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer la respuesta como cadena
                        string resultado = await response.Content.ReadAsStringAsync();

                        // Eliminar las comas de la respuesta
                        resultado = resultado.Replace(",", "");

                        // Eliminar comillas al principio y al final
                        resultado = resultado.Trim('"');

                        miFrame.IsVisible=true;

                        // Mostrar el resultado en la etiqueta
                        ResultadoLabel.Text = resultado;
                    }
                    else
                    {
                        // Mostrar un mensaje de error si la petición falló
                        ResultadoLabel.Text = "Error al obtener la respuesta de la API.";
                    }
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error si ocurre una excepción
                    ResultadoLabel.Text = $"Error: {ex.Message}";
                }
            }
            else
            {
                // Mostrar un mensaje si el valor ingresado no es válido
                ResultadoLabel.Text = "Por favor, ingresa un valor válido para kilómetros.";
            }
        }
    }
}