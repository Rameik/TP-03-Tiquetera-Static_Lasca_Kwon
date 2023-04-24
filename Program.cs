bool salir = false;
int[] importes = {15000, 30000, 10000, 40000};
int dni = 0, tipo = 0, total = 0;
string ape = "", nom = "";
DateTime fins = new DateTime();
do{
    Console.Clear();
    menu(ref salir, ref dni, ref ape, ref nom, ref fins, ref tipo, ref total);
    Console.WriteLine("Ingrese una tecla para continuar");
    Console.ReadKey();
}
while(salir == false);

void menu(ref bool salir, ref int dni, ref string ape, ref string nom, ref DateTime fins, ref int tipo, ref int total)
{
    int opcion;
    Cliente unCliente = new Cliente(dni, ape, nom, fins, tipo, total);
    Console.WriteLine("Ingresar opcion entre:");
    Console.WriteLine("1. Nueva Inscripción");
    Console.WriteLine("2. Obtener Estadísticas del Evento");
    Console.WriteLine("3. Buscar Cliente");
    Console.WriteLine("4. Cambiar entrada de un Cliente");
    Console.WriteLine("5. Salir");
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1: 
        Console.Clear();
        unCliente = nuevaInscripcion(importes, ref dni, ref ape, ref nom, ref fins, ref tipo, ref total);
        Ticketera.agregarCliente(unCliente);
        break;
        case 2:
        Console.Clear();
        obtenerEstadisticas();
        break; 
        case 3: 
        Console.Clear();
        buscarUnCliente();
        break;
        case 4: 
        Console.Clear();
        cambiarEntradaCliente();
        break;
        case 5: 
        Console.Clear();
        salir = true;
        break;
    }
}
Cliente nuevaInscripcion(int[] importes, ref int dni, ref string ape, ref string nom, ref DateTime fins, ref int tipo, ref int total){

dni = Funciones.IngresarEntero("Ingrese su DNI: ");
ape = Funciones.IngresarTexto("Ingrese su apellido: ");
nom = Funciones.IngresarTexto("Ingrese su nombre: ");
fins = DateTime.Today;
tipo = -1;
do{
    Console.WriteLine("Ingrese su tipo de entrada entre: (Ingresar solamente el numero de la opcion elegida)");
    Console.WriteLine("Opción 1 - Día 1, valor a abonar: $15000");
    Console.WriteLine("Opción 2 - Día 2, valor a abonar: $30000");
    Console.WriteLine("Opción 3 - Día 3, valor a abonar: $10000");
    Console.WriteLine("Opción 4 - Full Pass, valor a abonar $40000");
    int.TryParse(Console.ReadLine(), out tipo);
} while(tipo > 4 || tipo <= 0 && tipo == -1);

total = importes[tipo - 1];

Cliente nuevoCliente = new Cliente(dni, ape, nom, fins, tipo, total);
return nuevoCliente;
}

void obtenerEstadisticas(){

List<string> listaEstadisticas = Ticketera.estadisticasTicketera();
if(listaEstadisticas.Count==0) Console.WriteLine("Aún no se anotó nadie");
foreach (string item in listaEstadisticas)
{
    Console.WriteLine(item);
}
}

void buscarUnCliente(){

int idEntrada = Funciones.IngresarEntero("Ingrese el ID del cliente que quiere buscar y visualizar su informacion: ");;
Cliente clienteBuscado = Ticketera.buscarCliente(idEntrada);
if(clienteBuscado == null) Console.WriteLine("No se encontro el ID de la entrada buscado");
else{
    Console.WriteLine("DNI: " + clienteBuscado.DNI);
    Console.WriteLine("Nombre: " + clienteBuscado.Nombre);
    Console.WriteLine("Apellido: " + clienteBuscado.Apellido);
    Console.WriteLine("Fecha de inscripcion: " + clienteBuscado.fechaInscripcion);
    Console.WriteLine("Tipo de entrada: " + clienteBuscado.tipoEntrada);
    Console.WriteLine("Total abonado: " + clienteBuscado.totalAbonado);
}
    
}

void cambiarEntradaCliente(){

int idEntrada = Funciones.IngresarEntero("Ingrese el ID del cliente que quiere buscar y cambiar su tipo de entrada: ");
int total = 0;
int tipo = 0;

bool pudo = Ticketera.cambiarEntrada(idEntrada, tipo, total);

}
