using GeneralKnowledge.Test.App.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebExperience.Test.Models
{
    public class AssetDtoForCreation
    {
        [Required]
        public string FileName { get; set; }
        [Required]
        public string MimeType { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }

        public static implicit operator Asset(AssetDtoForCreation assetDto)
        {
            if (assetDto == null) throw new ArgumentNullException(nameof(assetDto));

            return new Asset(Guid.NewGuid(), assetDto.FileName,
                assetDto.MimeType, assetDto.CreatedBy, assetDto.Country, assetDto.Email, assetDto.Description)
            {
            };
        }
    }
}