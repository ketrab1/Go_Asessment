using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.Domain.Model.Common.Domain;

namespace Asset.Domain.Model.Asset.Domain
{
    public class Asset : AggregateRoot<Asset>
    {
        public Guid AssetId { get; set; }
        public string FileName { get; set; }
        public MimeType MimeType { get; set; }
        public string CreatedBy { get; set; }
        public Country Country { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
