using System;

namespace ControlInventarioTecnoPunto
{
    // 1. Clase Producto con sus propiedades, validaciones, constructor y método
    public class Producto
    {
        // Campos privados de respaldo
        private string _codigo;
       private string _nombre;
        private decimal _precio;
        private int _cantidad;

        // Propiedades de la clase Producto
        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        // 2. Validación en el bloque set: Nombre no puede estar vacío
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del producto no puede estar vacío.");
                }
                _nombre = value;
            }
        }

        // 2.1. Validación en el bloque set: Precio debe ser mayor que 0
        public decimal Precio
        {
            get { return _precio; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("El precio debe ser mayor que 0.");
                }
                _precio = value;
            }
        }

        // 2.2. Validación en el bloque set: Cantidad no puede ser negativa
        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La cantidad no puede ser negativa.");
                }
                _cantidad = value;
            }
        }

        // 3. Propiedad de solo lectura ValorTotal (Precio * Cantidad)
        public decimal ValorTotal
        {
            get { return Precio * Cantidad; }
        }

        // 4. Constructor que recibe los datos e inicializa el objeto
        public Producto(string codigo, string nombre, decimal precio, int cantidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        // 5. Método que imprime los datos del producto en consola
        public void MostrarInfo()
        {
            Console.WriteLine("");
            Console.WriteLine($"Código:      {Codigo}");
            Console.WriteLine($"Nombre:      {Nombre}");
            Console.WriteLine($"Precio:      {Precio:C}");
            Console.WriteLine($"Cantidad:    {Cantidad}");
            Console.WriteLine($"Valor Total: {ValorTotal:C}");
            Console.WriteLine("");
        }
    }

    // Clase principal que ejecuta el programa
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" SISTEMA DE REGISTRO DE PRODUCTOS \n");

            // 6. Leer por teclado los datos de al menos 3 productos, crear los objetos y mostrarlos
            Producto producto1 = RegistrarProducto(1);
            Producto producto2 = RegistrarProducto(2);
            Producto producto3 = RegistrarProducto(3);

            Console.WriteLine("\n PRODUCTOS REGISTRADOS ");
            producto1.MostrarInfo();
            producto2.MostrarInfo();
            producto3.MostrarInfo();

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // 7. Método auxiliar para solicitar datos y manejar errores sin que el programa se cierre
        static Producto RegistrarProducto(int numeroProducto)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"\nIngrese los datos del Producto #{numeroProducto}:");

                    Console.Write("Código: ");
                    string codigo = Console.ReadLine();

                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Precio: ");
                    decimal precio = decimal.Parse(Console.ReadLine());

                    Console.Write("Cantidad: ");
                    int cantidad = int.Parse(Console.ReadLine());

                    // Creación del objeto (activa las validaciones de las propiedades)
                    Producto nuevoProducto = new Producto(codigo, nombre, precio, cantidad);
                    Console.WriteLine("Producto registrado correctamente.");
                    return nuevoProducto;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error de formato: Asegúrese de ingresar valores numéricos válidos para el precio y la cantidad. Intente nuevamente.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Dato inválido: {ex.Message} Intente nuevamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error inesperado: {ex.Message} Intente nuevamente.");
                }
            }
        }
    }
}