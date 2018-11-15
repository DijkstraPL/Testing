using System;
using Tekla.Structures;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.CustomPropertyPlugin;

namespace SB_CustomProperties
{
    #region Strand properties.
    public class Strands
    {
        public int SumStrands123 { get; private set; }
        public int SumStrands124 { get; private set; }
        public double Size123 { get; private set; }
        public double Size124 { get; private set; }
        public int Pull123 { get; private set; }
        public int Pull124 { get; private set; }

        public void GetNumber(TSM.ModelObject obj)
        {
            var assembly = obj as TSM.Assembly;
            var mainPart = assembly.GetMainPart() as TSM.Part;

            var reportPropertyNumber = "NUMBER";
            var numberOfStrands123 = 0;
            var numberOfStrands124 = 0;

            if (obj is TSM.Assembly)
            {
                var reinforcement = mainPart.GetReinforcements();

                while (reinforcement.MoveNext())
                {
                    var reinf = reinforcement.Current as TSM.Reinforcement;

                    if (reinf.Class.Equals(123))
                    {
                        reinf.GetReportProperty(reportPropertyNumber, ref numberOfStrands123);
                        SumStrands123 += numberOfStrands123;
                    }
                    else if (reinf.Class.Equals(124))
                    {
                        reinf.GetReportProperty(reportPropertyNumber, ref numberOfStrands124);
                        SumStrands124 += numberOfStrands124;
                    }
                }
            }
        }

        public void GetSize(TSM.ModelObject obj)
        {
            var assembly = obj as TSM.Assembly;
            var mainPart = assembly.GetMainPart() as TSM.Part;

            var reportPropertySize = "SIZE";
            var size123 = 0.0;
            var size124 = 0.0;

            if (obj is TSM.Assembly)
            {
                var reinforcement = mainPart.GetReinforcements();
                var reinf = reinforcement.Current as TSM.Reinforcement;

                if (reinf.Class.Equals(123))
                {
                    reinf.GetReportProperty(reportPropertySize, ref size123);
                    Size123 = size123;
                }
                else if (reinf.Class.Equals(124))
                {
                    reinf.GetReportProperty(reportPropertySize, ref size124);
                    Size124 = size124;
                }
            }
        }

        public void GetPull(TSM.ModelObject obj)
        {
            var assembly = obj as TSM.Assembly;
            var mainPart = assembly.GetMainPart() as TSM.Part;

            var reportPropertyPull = "STRAND_PULL_FORCE";
            var pull123 = 0;
            var pull124 = 0;

            if (obj is TSM.Assembly)
            {
                var reinforcement = mainPart.GetReinforcements();
                var reinf = reinforcement.Current as TSM.Reinforcement;

                if (reinf.Class.Equals(123))
                {
                    reinf.GetReportProperty(reportPropertyPull, ref pull123);
                    Pull123 = Pull123;
                }
                else if (reinf.Class.Equals(124))
                {
                    reinf.GetReportProperty(reportPropertyPull, ref pull124);
                    Pull124 = pull124;
                }
            }
        }
    }
    #endregion
}

