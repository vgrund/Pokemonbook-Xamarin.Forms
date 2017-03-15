using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemonbook.Services
{
	public class AzureService<T>
	{
		IMobileServiceClient Client;
		IMobileServiceTable<T> Table;

		public AzureService()
		{
			string MyAppServiceURL = "http://<seuservico>.azurewebsites.net";
			Client = new MobileServiceClient(MyAppServiceURL);
			Table = Client.GetTable<T>();
		}

		public Task<IEnumerable<T>> GetTable()
		{
			return Table.ToEnumerableAsync();
		}
	}
}
