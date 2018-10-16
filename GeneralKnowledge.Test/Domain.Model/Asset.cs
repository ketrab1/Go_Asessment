using System;

namespace GeneralKnowledge.Test.App.Domain.Model
{
    public class Asset
    {
        public Asset()
        {
            
        }

        public Asset(Guid assetId, string fileName, string mimetype, string createdBy, string country, string email,
            string description)
        {
            Country = new Country(country);
            MimeType = new MimeType(mimetype);
            AssetId = assetId;
            FileName = fileName;
            CreatedBy = createdBy;
            Email = email;
            Description = description;
        }

        public Guid AssetId { get; set; }
        public string FileName { get; set; }
        public MimeType MimeType { get; set; } 
        public string CreatedBy { get; set; }
        public Country Country { get; set; } 
        public string Email { get; set; }
        public string Description { get; set; }

    }
}