using PokAPI.Business.Poke;
using System.Net.Http.Json;
using System.Text.Json;



namespace PokAPI.Business.service
{
    public class PokeServices
    {
        private readonly HttpClient _Cliente;

        public PokeServices(HttpClient client)
        {
            _Cliente = client;
        }

        public async Task<Pokemon> GetFavPokemon(string pokeNombre)
        {
            var response = await _Cliente.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokeNombre}");
            response.EnsureSuccessStatusCode();

            var datos = await response.Content.ReadFromJsonAsync<JsonElement>();

            var pokemon = new Pokemon
            {
                Nombre = pokeNombre,
                tipo = datos.GetProperty("types").EnumerateArray().First().GetProperty("type").GetProperty("name").GetString(),
                SpUrl = datos.GetProperty("sprites").GetProperty("front_default").GetString(),
                movi = datos.GetProperty("moves").EnumerateArray().Select(m => m.GetProperty("move").GetProperty("name").GetString()).ToList()
            };
            return pokemon;
        }




    }
}
