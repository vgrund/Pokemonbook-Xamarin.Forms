using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokemonbook.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			ListViewPokemons.ItemSelected += ListViewPokemons_ItemSelected;
		}

		private async void ListViewPokemons_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var SelectedPokemon = e.SelectedItem as Models.Pokemon;
			if (SelectedPokemon != null)
			{
				await Navigation.PushAsync(new Views.DetailsPage(SelectedPokemon));
				ListViewPokemons.SelectedItem = null;
			}
		}
	}
}
