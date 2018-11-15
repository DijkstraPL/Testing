using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Beam> beams = new List<Beam>();

            while (true)
            {
                Console.WriteLine("1. Show list of available beams.");
                Console.WriteLine("2. Add new beam");
                Console.WriteLine("3. Remove beam");
                Console.WriteLine("4. Closed");

                int selection = Int32.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        ShowBeams(beams);
                        break;
                    case 2:
                        beams.Add(AddNewBeam());
                        break;
                    case 3:
                        ShowBeams(beams);
                        RemoveBeam(beams);
                        break;
                    case 4:
                        return;
                    default:
                        break;
                }
            }

        }

        private static void RemoveBeam(List<Beam> beams)
        {
            Console.WriteLine("Which beam you want to delete? (Give index)");
            int index = Int32.Parse(Console.ReadLine());

            beams.RemoveAt(index);
        }

        private static Beam AddNewBeam()
        {
            Console.WriteLine("Give width:");
            int width = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Give height:");
            int height = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Give length:");
            int length = Int32.Parse(Console.ReadLine());

            return new Beam(length, width, height);
        }

        private static void ShowBeams(List<Beam> beams)
        {
            int index = 0;
            foreach (var beam in beams)
            {
                Console.WriteLine(index++ + ". " + beam);
            }
        }
    }

    public class Beam
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Beam(int length, int width, int height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public int CalculateVolume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            return $"B={Width}mm, H={Height}mm, L={Length}mm";
        }
    }
}
