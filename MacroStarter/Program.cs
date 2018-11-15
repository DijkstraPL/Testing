using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Tekla.Structures.Model.Operations.Operation.RunMacro("TeklaToolsStarter.cs");
        }
    }
}
