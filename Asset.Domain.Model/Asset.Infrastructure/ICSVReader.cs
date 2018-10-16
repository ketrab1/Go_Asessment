using System;
using System.Collections.Generic;
using System.Text;

namespace Asset.Domain.Model.Asset.Infrastructure
{
    public interface ICSVReader<T> where T : class
    {
         List<T> ReadCSV(int quantity,string stringFileName);
         List<T> ReadCSV(string stringFileName);

    }
}
