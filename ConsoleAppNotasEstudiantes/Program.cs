namespace ConsoleAppNotasEstudiantes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nroMaterias, nroEstudiantes;
            double[,] notas;
            string[] materias, estudiantes;

            Console.Write("Ingrese el nro de Materias ");
            nroMaterias = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nro de Estudinates ");
            nroEstudiantes = int.Parse(Console.ReadLine());

            notas = new double[nroEstudiantes + 1, nroMaterias + 1];
            materias = new string[nroMaterias];
            estudiantes = new string[nroEstudiantes + 1];

            // ingresar las materias
            Console.WriteLine("ingresar los nombres de las materias");
            for (int i = 0; i < nroMaterias; i++)
            {
                Console.Write("Nombre de materia: " + (i + 1));
                materias[i] = Console.ReadLine();
            }

            // ingresar nombres de estudiantes
            Console.WriteLine("ingresar los nombres de los estudiantes");
            for (int i = 0; i < nroEstudiantes; i++)
            {
                Console.Write("Nombre de estudiamnte: " + (i + 1));
                estudiantes[i] = Console.ReadLine();
            }

            // ingresar NOTAS
            Console.WriteLine("Ingresaremos notas por c/materia");
            for (int m = 0; m < nroMaterias; m++)
            {
                Console.WriteLine("----- MATERIA: " + materias[m]);
                for (int e = 0; e < nroEstudiantes; e++)
                {
                    Console.Write("ingrese nota de Estudiante " + estudiantes[e] + ": ");
                    notas[e, m] = double.Parse(Console.ReadLine());
                }
            }

            // ---- CALCULAR PROMEDIOS
            //   A) Promedios por materia
            for (int m = 0; m < nroMaterias; m++)
            {
                double sumaNotas = 0;
                double promedioMateria = 0;
                for (int e = 0; e < nroEstudiantes; e++)
                {
                    sumaNotas += notas[e, m];
                }
                promedioMateria = sumaNotas / nroEstudiantes;
                notas[nroEstudiantes, m] = promedioMateria;
            }

            //   B) Promedios por estudiante
            for (int e = 0; e <= nroEstudiantes; e++)
            {
                double sumaNotas = 0;
                double promedioEstudiante = 0;
                for (int m = 0; m < nroMaterias; m++)
                {
                    sumaNotas += notas[e, m];
                }
                promedioEstudiante = sumaNotas / nroMaterias;
                notas[e, nroMaterias] = promedioEstudiante;
            }

            //   C) Promedio General
            double sumaPromedios = 0;
            double promedioGeneral = 0;
            for (int e = 0; e < nroEstudiantes; e++)
            {
                sumaPromedios += notas[e, nroMaterias];
            }
            promedioGeneral = sumaPromedios / nroEstudiantes;
            notas[nroEstudiantes, nroMaterias] = promedioGeneral;

            //   D) Mejor nota del Curso
            double maxPromedioEstudiante = 0;
            for (int e = 0; e < nroEstudiantes; e++)
            {
                if (notas[e, nroMaterias] > maxPromedioEstudiante)
                    maxPromedioEstudiante = notas[e, nroMaterias];
            }

            //   E) Mejor nota por Materia
            double maxPromedioMateria = 0;
            for (int m = 0; m < nroMaterias; m++)
            {
                if (notas[nroEstudiantes, m] > maxPromedioMateria)
                    maxPromedioMateria = notas[nroEstudiantes, m];
            }

            // Imprimir valores
            Console.WriteLine("----- RESULTADOS ------------");
            
            Console.Write("ESTUDIANTE \t");
            for (int m = 0; m < nroMaterias; m++)
            {
                Console.Write(materias[m] + "\t");
            }
            Console.WriteLine("PROMEDIO");


            for (int e = 0; e <= nroEstudiantes; e++)
            {
                Console.Write(estudiantes[e] + "\t");
                for (int m = 0; m <= nroMaterias; m++)
                {
                    Console.Write(notas[e, m] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Nota Mejor estudiante: " + maxPromedioEstudiante);
            Console.WriteLine("Nota Materia con máximo rendimiento: " + maxPromedioMateria); 

            Console.ReadLine();
        }
    }
}
