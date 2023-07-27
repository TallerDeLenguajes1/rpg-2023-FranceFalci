using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using EspacioPersonaje;
namespace EspacioPersonajeJSON;

public class PersonajeJson
{
    public void GuardarPersonajes(List<Personaje> listaPersonajes, string path)
    {
        string json = JsonSerializer.Serialize(listaPersonajes);
        File.WriteAllText(path, json);
    }

    public List<Personaje> LeerPersonajes(string path)
    {

        string jsonString = File.ReadAllText(path);
        List<Personaje>? listaPersonajes = JsonSerializer.Deserialize<List<Personaje>>(jsonString);

        if (listaPersonajes == null) listaPersonajes = new List<Personaje>();

        return listaPersonajes;
    }

    public bool ExisteArchivo(string path)
    {
        if (File.Exists(path))
        {
            string contenido = File.ReadAllText(path);
            return !string.IsNullOrEmpty(contenido);
        }
        // if (File.Exists(path))
        // {
        //     FileInfo fileInfo = new FileInfo(path);
        //     return fileInfo.Length > 0;
        // }

        return false;
    }




}
