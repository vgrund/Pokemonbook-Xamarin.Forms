using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace Pokemonbook.Models
{
	[DataTable("Pokemons")]
	public class Pokemon
	{
		public string Id { get; set; }
		public int Number { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }
		public int Weight { get; set; }
		public int Height { get; set; }
		public int BaseExperience { get; set; }
		public ImageSource Sprite { get; set; }

		[Version]
		public string AzureVersion { get; set; }
	}
}
