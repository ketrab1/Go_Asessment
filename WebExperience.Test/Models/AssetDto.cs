using System;
using System.ComponentModel.DataAnnotations;
using GeneralKnowledge.Test.App.Domain.Model;

namespace WebExperience.Test.Models
{
    public class AssetDto
    {
        [Required]
        public Guid AssetId { get; set; }
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


        public static implicit operator Asset(AssetDto assetDto)
        {
            if (assetDto == null) throw new ArgumentNullException(nameof(assetDto));

            return new Asset(assetDto.AssetId, assetDto.FileName,
                assetDto.MimeType, assetDto.CreatedBy, assetDto.Country, assetDto.Email, assetDto.Description)
            {
            };
        }
    }
}