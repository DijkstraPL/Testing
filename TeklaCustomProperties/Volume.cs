using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures;
using Tekla.Structures.CustomPropertyPlugin;
using Tekla.Structures.Model;

namespace TeklaCustomProperties
{
    [Export(typeof(ICustomPropertyPlugin))]
    [ExportMetadata("CustomProperty", "CUSTOM.CNS_VOLUME")]
    public class Volume : ICustomPropertyPlugin
    {
        public double GetDoubleProperty(int objectId)
        {
            var model = new Model();
            Identifier id = new Identifier(objectId);
            var obj = model.SelectModelObject(id);
            double volume = 0;

            if(obj is Part)
            {
                var part = obj as Part;

                part.GetReportProperty("VOLUME", ref volume);
            }

            return volume;
        }

        public int GetIntegerProperty(int objectId)
        {
            return 0;
        }

        public string GetStringProperty(int objectId)
        {
            return "";
        }
    }
}
