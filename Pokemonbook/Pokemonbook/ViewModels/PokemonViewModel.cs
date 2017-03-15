using Pokemonbook.Models;
using Pokemonbook.Repositories;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokemonbook.ViewModels
{
	public class PokemonViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Pokemon> Pokemons { get; set; }

		public PokemonViewModel()
		{
			Pokemons = new ObservableCollection<Pokemon>();

			GetPokemonsCommand = new Command(async () => await GetPokemons(), () => !isBusy);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
		   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		private bool isBusy;
		
		public bool IsBusy
		{
			get
			{
				return isBusy;
			}

			set
			{
				isBusy = value;
				OnPropertyChanged();
				GetPokemonsCommand.ChangeCanExecute();
			}
		}

		async Task GetPokemons()
		{
			if (!IsBusy)
			{
				Exception Error = null;
				try
				{
					IsBusy = true;

					var repository = new Repository();
					var items = await repository.GetPokemons();

					Pokemons.Clear();
					foreach (var pokemon in items)
					{
						Pokemons.Add(pokemon);
					}
				}
				catch (Exception ex)
				{
					Error = ex;
				}
				finally
				{
					IsBusy = false;
				}

				if (Error != null)
				{
					await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", Error.Message, "OK");
				}
			}
			return;
		}

		public Command GetPokemonsCommand { get; set; }
	}
}
