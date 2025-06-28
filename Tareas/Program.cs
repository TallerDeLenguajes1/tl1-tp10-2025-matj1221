using System.Runtime.InteropServices;
using System.Text.Json;

//apartado a

using espacioTarea;

//apartado b

var cliente = new HttpClient();
// GetAsync(): Metodo para peticiones GET
HttpResponseMessage response = await cliente.GetAsync("https://jsonplaceholder.typicode.com/todos/");

// EnsureSuccessStatusCode(): Verifica si la petición fue exitosa
response.EnsureSuccessStatusCode();

// ReadAsStringAsync(): Para leer el cuerpo de la respuesta
string responseBody = await response.Content.ReadAsStringAsync();

// JsonSerializer.Deserialize<T>(): Para convertir JSON a objetos
List<Tarea> listTarea = JsonSerializer.Deserialize<List<Tarea>>(responseBody);


//apartado c
System.Console.WriteLine("Tareas completadas: \n");
foreach (var Prov in listTarea)
{
    if (Prov.Estado == true)
    {
        System.Console.WriteLine($"User ID: {Prov.UserId} | ID: {Prov.Id} | Titulo: {Prov.Title} | Estado: {Prov.Estado}");
    }
}
System.Console.WriteLine("Tareas pendientes: \n");

foreach (var Prov in listTarea)
{
    if (Prov.Estado == false)
    {
        Console.WriteLine($"User ID: {Prov.UserId} | ID: {Prov.Id} | Titulo: {Prov.Title} | Estado: {Prov.Estado}");
    }
}

//apartado d
string jsonString = JsonSerializer.Serialize<List<Tarea>>(listTarea);

File.WriteAllText("tareas.json", jsonString); //Con esto, podemos hacer:

// 1) Leer el archivo y deserializarlo

/*
string jsonFromFile = File.ReadAllText("tareas.json");
List<Tarea> tareasLocales = JsonSerializer.Deserialize<List<Tarea>>(jsonFromFile);
*/

/*
foreach (var tarea in tareasLocales)
{
    if (tarea.Estado == true)
    {
        System.Console.WriteLine($"User ID: {tarea.UserId} | ID: {tarea.Id} | Titulo: {tarea.Title} | Estado: {tarea.Estado}");
    }
    else
    {
        System.Console.WriteLine($"User ID: {tarea.UserId} | ID: {tarea.Id} | Titulo: {tarea.Title} | Estado: {tarea.Estado}");
    }
}
*/

// 2) Filtrar datos (ejemplo: tareas completadas)

/*
var completadas = tareasLocales.Where(t => t.Estado == true).ToList();
System.Console.WriteLine($"Tareas completadas:\n {completadas.Count}");
*/

// 3) Buscar una tarea especifica

/*
var tareaEspecifica = tareasLocales.FirstOrDefault(t => t.Id == 5);

if (tareaEspecifica != null)
{
    System.Console.WriteLine($"Tarea 5: {tareaEspecifica.Title}"); //sólo muestra una
}*/