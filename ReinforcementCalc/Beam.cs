using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReinforcementCalc
{
    public class Beam
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double BendingMoment { get; set; }
        public double CharacteristicStrengthConcrete { get; set; }
        public double CharacteristicStrengthSteel { get; set; }
        public double Cover { get; set; }
        public double StirrupsDiameter { get; set; }
        public double ReinforcementDiameter { get; set; }
        public double RequiredReinforcement { get; set; }

        public Beam()
        {

        }

        public Beam(double width, double height, double bendingMoment, double characteristicStrengthConcrete, 
            double characteristicStrengthSteel, double cover, double stirrupsDiameter, double reinforcementDiameter)
        {
            Width = width;
            Height = height;
            BendingMoment = bendingMoment;
            CharacteristicStrengthConcrete = characteristicStrengthConcrete;
            CharacteristicStrengthSteel = characteristicStrengthSteel;
            Cover = cover;
            StirrupsDiameter = stirrupsDiameter;
            ReinforcementDiameter = reinforcementDiameter;
        }

        public void CalculateReinforcement()
        {
            double effectiveDepth = Height - Cover - StirrupsDiameter - ReinforcementDiameter / 2;
            double desightStrengthSteel = CharacteristicStrengthSteel / 1.15;
            double designStrengthConcrete = CharacteristicStrengthConcrete / 1.4;

            double delta = 1 - (2 * BendingMoment) / (designStrengthConcrete * 1000 * Width / 1000 * Math.Pow(effectiveDepth / 1000, 2));

            double variable = 1 - Math.Sqrt(delta);

            double reinforcementRatio = designStrengthConcrete / desightStrengthSteel * variable;

            RequiredReinforcement = reinforcementRatio * Width /1000 * effectiveDepth /1000 *10000;

            var beam = new Beam();            
        }

    }
}
