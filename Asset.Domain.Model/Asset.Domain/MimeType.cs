using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.Domain.Model.Common.Domain;

namespace Asset.Domain.Model.Asset.Domain
{
    public class MimeType : Entity
    {
        public MimeType(string type)
        {
            if(string.IsNullOrEmpty(type))
                throw new ArgumentNullException(type);
            Type = type;
        }

        public string Type { get;}
    }
}
