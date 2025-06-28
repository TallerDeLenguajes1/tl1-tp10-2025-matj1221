using espacioPokeAPI;
using System;
using System.Text.Json;

string[] nombres = { "pikachu", "charizard", "bulbasaur", "lucario", "gyarados" };
List<Pokemon> listaPokemon = new List<Pokemon>();

// Creo cliente HTTP
HttpClient cliente = new HttpClient();

foreach (string nombre in nombres)
{

    // Realizo la peticion GET
    HttpResponseMessage response = await cliente.GetAsync($"https://pokeapi.co/api/v2/pokemon/{nombre}");
    response.EnsureSuccessStatusCode();

    // Leo respuesta como string
    string responseBody = await response.Content.ReadAsStringAsync();

    // Deserializo JSON a objeto
    Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(responseBody);

    Console.WriteLine($"Nombre: {pokemon.name}");
    Console.WriteLine($"Altura: {pokemon.height}");
    Console.WriteLine($"Peso: {pokemon.weight}");

    Console.WriteLine("Tipos:");

    foreach (var tipo in pokemon.types)
    {
        Console.WriteLine($"{tipo.type.name} ");
    }

    pokemon.MostrarLinea();

    listaPokemon.Add(pokemon);

}


string jsonString = JsonSerializer.Serialize(listaPokemon);

File.WriteAllText("pokemon.json", jsonString);