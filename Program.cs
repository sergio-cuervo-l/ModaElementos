namespace ModaArreglos
{
    public class Program
    {
        List<int[]> list = new List<int[]>();

        public void menu()
        {            
            Console.WriteLine("Escoja un opción de las siguientes: \n" +
                                "\t 1. Agregar arreglo \n" +
                                "\t 2. Lista de arreglos agregados \n" +
                                "\t 3. Generar moda de elementos \n" +
                                "\t 4. Salir del programa \n");
            string? select = Console.ReadLine();
            switch(select)
            {
                case "1":
                    addList();
                    menu();
                    break;
                case "2":
                    showList();
                    menu();
                    break;
                case "3":
                    modaNum();
                    menu();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("No se escogio una opción valida, vuelva a escoger una opción \n\n\n");
                    menu();
                    break;
            }
        }

        public void addList()
        {
            Console.WriteLine("_________________________________________________________________________");
            Console.WriteLine("Cuantos datos va a tener su arreglo");
            int length = int.Parse(Console.ReadLine());
            int[] num = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Escriba el numero del arreglo en la posición {i+1}");
                num[i] = int.Parse(Console.ReadLine());
            }
            list.Add(num);
            Console.WriteLine("_________________________________________________________________________");
        }

        public void showList()
        {
            Console.WriteLine("_________________________________________________________________________");
            string output = "[";
            int i = 0;
            string[] datos = new string[list.Count];
            foreach (var item in list)
            {
                datos[i] = "{"+string.Join(",", item)+"}";
                i++;
            }
            output += string.Join(", ", datos);
            Console.WriteLine(output+"]");
            Console.WriteLine("_________________________________________________________________________");
        }

        public void modaNum()
        {
            Console.WriteLine("_________________________________________________________________________");
            
            var countElements = list.SelectMany(x => x)
                                       .GroupBy(element => element)
                                       .Where(group => group.Count() == list.Count());
            var commonElements = countElements.Select(x => x.Key).ToList();

            Console.WriteLine("Elementos que se encuentran en todos los array son: "+"[" + string.Join(",", commonElements) + "]");
            Console.WriteLine("_________________________________________________________________________");
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Bienvenido a generar moda de elementos numericos");
            p.menu();
        }
    }
}
