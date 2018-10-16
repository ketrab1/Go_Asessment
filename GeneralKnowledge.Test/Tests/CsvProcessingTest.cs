using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using GeneralKnowledge.Test.App.Domain.Model;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    {
        public void Run()
        {
            // TODO: 
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted
            var csvFile = Resources.AssetImport;
            var assetCsvReader = new AssetCsvReader();
            var data = assetCsvReader.ReadCsv(
                $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\Resources\AssetImport.csv");
            
        }
    }

    public class AssetCsvReader
    {
        /// <summary>
        /// Return all assets.
        /// </summary>
        public IEnumerable<Asset> ReadCsv(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentException("Invalid path.", nameof(path));

            return File.ReadLines(path)
                .Skip(1)
                .Where(s => s != "")
                .Select(s => s.Split(','))
                .Select(a => new Asset(new Guid(a[0]), a[1], a[2], a[3], a[4], a[5], a[6]))
                .ToList();
        }
    }
}