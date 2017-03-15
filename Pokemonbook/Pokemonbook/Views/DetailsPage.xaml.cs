using Pokemonbook.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokemonbook.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailsPage : ContentPage
	{
		Pokemon _SelectedPokemon;

		public DetailsPage(Pokemon seletedPokemon)
		{
			InitializeComponent();
			_SelectedPokemon = seletedPokemon;
			BindingContext = _SelectedPokemon;
		}
	}
}
