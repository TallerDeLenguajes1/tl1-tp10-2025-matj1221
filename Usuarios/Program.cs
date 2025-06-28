using espacioUsuarios;
using System;
using System.Text.Json;

HttpClient cliente = new HttpClient();
HttpResponseMessage response = await cliente.GetAsync("https://jsonplaceholder.typicode.com/users");
response.EnsureSuccessStatusCode();
string responseBody = await response.Content.ReadAsStringAsync();
List<Usuario> listUsuario = JsonSerializer.Deserialize<List<Usuario>>(responseBody);

for (int i = 0; i < Math.Min(5, listUsuario.Count); i++)
{
    var usuario = listUsuario[i];
    System.Console.WriteLine($"Nombre: {usuario.Name}");
    System.Console.WriteLine($"Username: {usuario.Username}");
    System.Console.WriteLine($"Email: {usuario.Email}");
    System.Console.WriteLine($"Domicilio: {usuario.Address.Street} | {usuario.Address.Suite} | {usuario.Address.City}");
    usuario.mostrarLinea();
}


string jsonString = JsonSerializer.Serialize<List<Usuario>>(listUsuario);

File.WriteAllText("usuarios.json", jsonString);