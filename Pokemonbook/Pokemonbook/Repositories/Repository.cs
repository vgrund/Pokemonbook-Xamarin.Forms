using Pokemonbook.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemonbook.Repositories
{
	public class Repository
	{
		public async Task<List<Pokemon>> GetPokemons()
		{
			var service = new Services.AzureService<Pokemon>();
			var items = await service.GetTable();
			return items.ToList();
		}
	}
}
