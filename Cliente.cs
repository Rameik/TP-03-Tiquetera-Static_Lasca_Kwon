public class Cliente{

public int DNI {get;private set;}
public string Apellido {get;private set;}
public string Nombre {get;private set;}
public DateTime fechaInscripcion {get;set;}
public int tipoEntrada {get;set;}

public int totalAbonado {get;set;}

public Cliente(){


}

public Cliente(int dni, string ape, string nom, DateTime fins, int tipo, int total){
DNI = dni;
Apellido = ape;
Nombre = nom;
fechaInscripcion = fins;
tipoEntrada = tipo;
totalAbonado = total;
}
}