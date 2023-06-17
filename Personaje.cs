namespace EspacioPersonaje;

public class Personaje{

    Tipos tipo;
    string? nombre;
    string? apodo;
    DateTime fechaNac;
    int edad;
    int velocidad;
    int destreza;
    int fuerza;
    int nivel;
    int armadura;
    int salud;


}

public enum Tipos{
    vivo,
    muerto
}