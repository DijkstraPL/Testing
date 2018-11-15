using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.Model;

namespace Slab
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new Model();
            if (model.GetConnectionStatus())
            {
                Console.WriteLine("Give diameter");
                int diameter = Int32.Parse(Console.ReadLine());
                int numberOfPoints = 90;
                var slab = new ContourPlate();
                for (int i = 0; i < numberOfPoints; i++)
                {
                    slab.AddContourPoint(new ContourPoint(
                        new Tekla.Structures.Geometry3d.Point(
                            Math.Sin(360/ numberOfPoints * i*Math.PI/180)*diameter/2, 
                            Math.Cos(360/ numberOfPoints * i * Math.PI / 180)*diameter/2, 
                            0), 
                            null));
                }

                slab.Class = "5";
                slab.Profile.ProfileString = "500";

                slab.Insert();
                
                //Beam beam = new Beam();
                //beam.StartPoint = new Tekla.Structures.Geometry3d.Point(0, 0, 0);
                //beam.EndPoint = new Tekla.Structures.Geometry3d.Point(0, 1500, 0);
                //beam.Profile.ProfileString = "600*500";
                //beam.Class = "4";
                //beam.Insert();

                model.CommitChanges();
            }
        }
    }
}
