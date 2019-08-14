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
        static void TryWithCount(int boolCount, int floatCount)
        {
            var serializer = new CerasSerializer();
            var deserializer = new CerasSerializer();

            var dict = new Dictionary<string, object>();
            bool[] boolArray = new bool[boolCount];
            float[] floatArray = new float[floatCount];
            for (int i = 0; i < boolCount; i++)
                boolArray[i] = i % 2 == 0 ? false : true;
            for (int i = 0; i < floatCount; i++)
                floatArray[i] = (float)i * 10000.0f;

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
            TryWithCount(30, 30);
            TryWithCount(30, 200);
            TryWithCount(40, 120);
            TryWithCount(60, 120);
        }
    }
}
