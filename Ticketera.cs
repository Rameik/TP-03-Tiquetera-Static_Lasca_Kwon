using System.Collections.Generic;
public static class Ticketera{
private static Dictionary<int,Cliente> dicClientes = new Dictionary<int, Cliente>();

private static int UltimoIDEntrada = 1;


public static int devolverUltimoID(){

for(int i = 0; i < dicClientes.Count; i++){

UltimoIDEntrada += 1;
}
return UltimoIDEntrada;
}

public static int agregarCliente(Cliente unCliente){

int idEntrada = 1;
for (int i = 0; i < dicClientes.Count; i++)
{
    idEntrada += 1;
}
dicClientes.Add(idEntrada, unCliente);
return idEntrada;
}

public static Cliente buscarCliente(int idEntrada){
int idPedido = idEntrada;
Cliente clienteBuscado = null;
foreach (var clave in dicClientes)
{
    if(clave.Key == idPedido){
        clienteBuscado = clave.Value;
    }
}
return clienteBuscado;
}

public static bool cambiarEntrada(int idEntrada, int tipo, int total){
int[] importes = {15000, 30000, 10000, 40000};
bool pudo = false, encontro = false;
int viejoTipo;
int viejoTotal = 0;
foreach (var clave in dicClientes)
{
    viejoTipo = clave.Value.tipoEntrada;
    viejoTotal = clave.Value.totalAbonado;
}
foreach (var clave in dicClientes)
{
    if(clave.Key == idEntrada){
        encontro = true;
    }
}
if(encontro == false) Console.WriteLine("No se pudo hacer el cambio debido a que no se encontro el ID");
else{
    do{
    Console.WriteLine("Ingrese su nuevo tipo de entrada entre: (El importe del nuevo tipo de entrada tiene que ser superior al que había comprado anteriormente y debe ingresar solamente el numero de la opcion elegida)");
    Console.WriteLine("Opción 1 - Día 1, valor a abonar: $15000");
    Console.WriteLine("Opción 2 - Día 2, valor a abonar: $30000");
    Console.WriteLine("Opción 3 - Día 3, valor a abonar: $10000");
    Console.WriteLine("Opción 4 - Full Pass, valor a abonar $40000");
    int.TryParse(Console.ReadLine(), out tipo);
    } while(tipo > 4 || tipo <= 0 && tipo == -1);
    total = importes[tipo - 1];
if(total > viejoTotal){
    Console.WriteLine("Su nuevo total es de: " + total);
    foreach (var clave in dicClientes)
    {
        if(clave.Key == idEntrada){
        pudo = true;
        clave.Value.tipoEntrada = tipo;
        clave.Value.totalAbonado = total;
        clave.Value.fechaInscripcion = DateTime.Now;
        }
    }
}
}
if(pudo == false && encontro == true) Console.WriteLine("No se pudo hacer el cambio debido a que el importe del nuevo tipo de entrada no era superior al que había comprado anteriormente");

return pudo;
}

public static List<string> estadisticasTicketera(){

List<string> listaEstadisticas = new List<string>();
int[] recaudacion = new int[4];
int[] cantidadEntradasTipos = new int[4];
double porcentajeEntradas;
int cantidadClientes, recaudacionTotal = 0, recaudacionIndividual = 0, cantTotal = 0;


cantidadClientes = dicClientes.Count;
foreach (var value in dicClientes.Values)
{
    recaudacion[value.tipoEntrada - 1] += value.totalAbonado;
    cantidadEntradasTipos[value.tipoEntrada - 1] += 1;
}
for(int i = 0; i < recaudacion.Length; i++){
    recaudacionTotal += recaudacion[i];
    cantTotal += cantidadEntradasTipos[i];
}
if(cantTotal > 0){
    listaEstadisticas.Add("Cantidad de clientes inscriptos: " + cantidadClientes);
    for(int i = 0; i < cantidadEntradasTipos.Length; i++){
        porcentajeEntradas = (cantidadEntradasTipos[i]*100) / cantTotal;
        listaEstadisticas.Add("Porcentaje de cantidad de entradas vendidas diferenciadas por tipo respecto al total: " + (i+1) + ": " + porcentajeEntradas);
    }
    for(int i = 0; i < recaudacion.Length; i++){
        listaEstadisticas.Add("Recaudación de tipo: " + (i + 1)+ ": " + recaudacion[i]);
    }
    listaEstadisticas.Add("Recaudación total: " + recaudacionTotal);
}

return listaEstadisticas;
}
}