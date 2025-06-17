using EspacioTareas;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

using HttpClient client = new HttpClient();

HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");
response.EnsureSuccessStatusCode();
string responseBody = await response.Content.ReadAsStringAsync();
List<Tarea> listTareas = JsonSerializer.Deserialize<List<Tarea>>(responseBody);
foreach (var Tarea1 in listTareas)
{
    if (Tarea1.completed == false)
    {
        System.Console.WriteLine($"Titulo: {Tarea1.title} \n Completado: {Tarea1.completed} \n --------- \n");
    }
}
foreach (var Tarea1 in listTareas)
{
    if (Tarea1.completed)
    {
        System.Console.WriteLine($"Titulo: {Tarea1.title} \n Completado: {Tarea1.completed} \n --------- \n");
    }
}

var json = JsonSerializer.Serialize(listTareas);
File.WriteAllText("tareas.json", json);

