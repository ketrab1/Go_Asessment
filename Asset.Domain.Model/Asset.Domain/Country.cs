using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.Domain.Model.Common.Domain;

namespace Asset.Domain.Model.Asset.Domain
{
    public class Country : Entity
    {
        public Country(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(name);
            Name = name;
        }
        public string Name { get; set; }
    }
}
