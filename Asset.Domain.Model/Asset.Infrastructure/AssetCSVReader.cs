using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Asset.Domain.Model.Asset.Domain;
using System.Linq;


namespace Asset.Domain.Model.Asset.Infrastructure
{
   public class AssetCSVReader : CSVReader<Asset.Domain.Asset>
    {
        /// <summary>
        /// Return specified quantity of assets.
        /// </summary>
        public override List<Asset.Domain.Asset> ReadCSV (int quantity, string stringFileName)
        {
            if (String.IsNullOrEmpty(stringFileName))
                throw new ArgumentNullException(stringFileName);
            if (quantity <= 0)
                throw new ArgumentNullException(stringFileName);

            return File.ReadLines(stringFileName)
                .Skip(1)
                .Take(quantity)
                .Where(s => s != "")
                .Select(s => s.Split(new[] { ',' }))
                .Select(a => new Domain.Asset()
                {
                    AssetId = new Guid(a[0]),
                    FileName = a[1],
                    MimeType = new MimeType(a[2]),
                    CreatedBy = a[3],
                    Email = a[4],
                    Country = new Country(a[5]),
                    Description = a[6]
                })
                .ToList();
        }

        /// <summary>
        /// Return all assets.
        /// </summary>
        public override List<Domain.Asset> ReadCSV(string stringFileName)
        {
            if (String.IsNullOrEmpty(stringFileName))
                throw new ArgumentNullException(stringFileName);
            return File.ReadLines(stringFileName)
                .Skip(1)
                .Where(s => s != "")
                .Select(s => s.Split(new[] { ',' }))
                .Select(a => new Domain.Asset()
                {
                    AssetId = new Guid(a[0]),
                    FileName = a[1],
                    MimeType = new MimeType(a[2]),
                    CreatedBy = a[3],
                    Email = a[4],
                    Country = new Country(a[5]),
                    Description = a[6]
                })
                .ToList();
        }
    }
}
