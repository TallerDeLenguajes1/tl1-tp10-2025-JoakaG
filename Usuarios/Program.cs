using System.Text.Json;

using HttpClient client = new HttpClient();

HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
response.EnsureSuccessStatusCode();
string responseBody = await response.Content.ReadAsStringAsync();
List<Usuarios> listUsuarios = JsonSerializer.Deserialize<List<Usuarios>>(responseBody);

foreach (var Usuario in listUsuarios)
{
System.Console.WriteLine($"ID: {Usuario.id} \n Name: {Usuario.name} \n Email: {Usuario.email} \n Address: \n  Calle {Usuario.address.street} \n  Suite: {Usuario.address.suite} \n  City: {Usuario.address.city} \n  ZipCode: {Usuario.address.zipcode} \n  Geo: \n  Lat: {Usuario.address.geo.lat} \n  Lng: {Usuario.address.geo.lng}");
    
}