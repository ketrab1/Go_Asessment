using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Asset.Domain.Model.Asset.Infrastructure
{
    public abstract class CSVReader<T> : ICSVReader<T> where T : class
    {
        abstract public List<T> ReadCSV(int quantity, string stringFileName);
        abstract public List<T> ReadCSV(string stringFileName);
    }

}

