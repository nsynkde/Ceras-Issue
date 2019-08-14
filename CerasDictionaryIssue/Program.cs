using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceras;

namespace CerasDictionaryIssue
{
    class Program
    {
        static void TryWithCount(int count)
        {
            var serializer = new CerasSerializer();
            var deserializer = new CerasSerializer();

            var dict = new Dictionary<string, object>();
            bool[] boolArray = new bool[count];
            float[] floatArray = new float[count];
            for (int i = 0; i < count; i++)
            {
                boolArray[i] = i % 2 == 0 ? false : true;
                floatArray[i] = (float)i * 10000f;
            }

            dict.Add("Booleans", boolArray);
            dict.Add("Floats", floatArray);

            var bytes = serializer.Serialize<Dictionary<string, object>>(dict);
            Dictionary<string, object> clone = new Dictionary<string, object>();
            deserializer.Deserialize<Dictionary<string, object>>(ref clone, bytes);

            foreach (var element in clone)
                Console.WriteLine($"{element.Key}: {element.Value}");
        }

        static void Main(string[] args)
        {
            TryWithCount(30);
            TryWithCount(60);
        }
    }
}
