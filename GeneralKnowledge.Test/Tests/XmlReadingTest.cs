using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// This test evaluates the 
    /// </summary>
    public class XmlReadingTest : ITest
    {
        public string Name
        {
            get { return "XML Reading Test"; }
        }

        public void Run()
        {
            // TODO: 
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z

            var data = GetDataFromXml(
                $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\Resources\SamplePoints.xml");
            
            var result = PrintOverview(data);
        }

        private string PrintOverview(Samples samples)
        {
            var groups = samples.Measurements.Select(x => x.Params).SelectMany(x => x).GroupBy(x => x.Name).Select(x => (x.Key, x.Select(y => double.Parse(y.Value.Replace('.', ',')))));
            var max = groups.Select(x => (x.Item1, x.Item2.Max(y => y)));
            var min = groups.Select(x => (x.Item1, x.Item2.Min(y => y)));
            var avg = groups.Select(x => (x.Item1, x.Item2.Average(y => y)));

            var output = max
                .Join(min, x => x.Item1, x => x.Item1, (x, y) => new { Name = x.Item1, Min = x.Item2, Max = y.Item2 })
                .Join(avg, x => x.Name, x => x.Item1, (a, b) => new { a.Name, a.Min, a.Max, Avg = b.Item2 });

            var sb = new StringBuilder();
            foreach (var element in output)
            {
                sb.AppendLine($"{element.Name}: MIN({element.Min}), MAX({element.Max}), AVG({element.Avg})");
            }
            
            return sb.ToString();
        }


        private Samples GetDataFromXml(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentException("Invalid path.", nameof(path));

            var serializer = new XmlSerializer(typeof(Samples));
            Samples samples;
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read,
                FileShare.Read))
            {
                samples = (Samples) serializer.Deserialize(fileStream);
            }

            return samples;
        }
    }


    [XmlType("samples")]
    public sealed class Samples
    {
        [XmlElement("measurement")] public List<Measurement> Measurements { get; set; }
    }

    public sealed class Measurement
    {
        [XmlElement("param")] public List<Param> Params { get; set; }
        
        [XmlAttribute("date")] public DateTime Date { get; set; }
    }

    public sealed class Param
    {
        [XmlAttribute("name")] public string Name { get; set; }

        [XmlText] public string Value { get; set; }
    }
}