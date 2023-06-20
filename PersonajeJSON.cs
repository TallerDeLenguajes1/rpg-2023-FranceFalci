// 1) Armar una clase llamada PersonajesJson para guardar y leer desde un archivo Json
// 2) Crear un método llamado GuardarPersonajes que reciba una lista de personajes, el
// nombre del archivo y lo guarde en formato Json.
// 3) Crear un método llamado LeerPersonajes que reciba un nombre de archivo y retorne
// la lista de personajes incluidos en el Json.
// 4) Crear un método llamado Existe que reciba un nombre de archivo y que retorne un
// True si existe y tiene datos o False en caso contrario.
using System.Text.Json; 
using System.Text.Json.Serialization;
using EspacioPersonaje;
namespace EspacioPersonajeJSON;

public  class  PersonajeJson{
    public void GuardarPersonajes(List<Personaje> listaPersonajes, string path)
    {
        string json =JsonSerializer.Serialize(listaPersonajes);
        File.WriteAllText(path,json);
    }

    public List<Personaje> LeerPersonajes(string path)
    {
        
        string jsonString = File.ReadAllText(path);
        List<Personaje>? listaPersonajes = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
        
        if (listaPersonajes == null) listaPersonajes = new List<Personaje>();
        
        return listaPersonajes;
    }

    public bool ExisteArchivo (string path){
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