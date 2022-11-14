using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace MyLibrary
{
    internal class Csv
    {
        public CsvReader GetCSV()
        {
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var reader = new StreamReader(dir + @"\books.csv");
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv;
        }
    }
}
