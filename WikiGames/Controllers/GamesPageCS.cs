using System;
using System.Collections.Generic;
using WikiGames.Client;
using WikiGames.Layouts;
using WikiGames.Layouts.SingleGamePage;
using WikiGames.Models;
using Xamarin.Forms;

namespace WikiGames.Controllers
{
    public class GamesPageCS : ContentPage
    {
        public static HttpClient RestClient { get; private set; }
        private HttpResponse<List<Juego>> listJuegos;

        public GamesPageCS()
        {
            GamesPageCS.RestClient = new HttpClient(new Dictionary<string, string>
            {
                //{ "X-API-Key", "abf21727-c0ab-4992-bce7-8a8053d2e3cd"}
            });
            fechtJuegos();
        }


        private void fillGames()
        {
            if (listJuegos.Result != null)
            {
                //para listas
                foreach (var juego in listJuegos.Result)
                {
                    //System.Diagnostics.Debug.WriteLine(juego.Titulo);
                    ImageButton image = new ImageButton();
                    image.Source = "https://informatica.ieszaidinvergeles.org:9062/proyecto/public/uploads/" + juego.Caratula;
                    image.Clicked += (sender, e) =>
                    {
                        System.Diagnostics.Debug.WriteLine(juego.Titulo);
                    };
                    /*CoolLabelStack.Children.Add(image);
                    //System.Diagnostics.Debug.WriteLine("https://informatica.ieszaidinvergeles.org:9062/proyecto/public/uploads/" + juego.Caratula);
                    Label label = new Label();
                    label.Text = juego.Titulo;
                    label.TextColor = Color.Blue;
                    CoolLabelStack.Children.Add(label);
                    */
                }
                //para objeto single
                //System.Diagnostics.Debug.WriteLine(response.Result.Titulo);
            }
            else
            {
                var messageError = listJuegos.Status.message;
                System.Diagnostics.Debug.WriteLine(messageError);

            }
        }

        private async void fechtJuegos()
        {
            ///
            /// Llamando listas de objetos
            ///
            listJuegos = await GamesPageCS.RestClient.GetAsync<List<Juego>>("https://informatica.ieszaidinvergeles.org:9062/proyecto/public/api/juego");

            /// Llamando objetos concretos
            ///
            ///var response = await MainPage.RestClient.GetAsync<Juego>("https://informatica.ieszaidinvergeles.org:9062/proyecto/public/api/juego/2");
            ///
            fillGames();
        }

        private async void oncliked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SingleGamePage());
        }

        private async void btnPag3_cliked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SplashPage());
        }
    }
}
