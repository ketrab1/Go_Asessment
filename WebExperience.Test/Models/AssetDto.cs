using System;
using GeneralKnowledge.Test.App.Asset.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExperience.Test.Models
{
    public class AssetDto
    {
        public Guid AssetId { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string CreatedBy { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }


        public static implicit operator GeneralKnowledge.Test.App.Asset.Domain.Model.Asset(AssetDto assetDto)
        {
            if (assetDto == null) throw new ArgumentNullException(nameof(assetDto));

            return new GeneralKnowledge.Test.App.Asset.Domain.Model.Asset(assetDto.AssetId, assetDto.FileName,
                assetDto.MimeType, assetDto.CreatedBy, assetDto.Country, assetDto.Email, assetDto.Description)
            {
            };
        }
    }
}