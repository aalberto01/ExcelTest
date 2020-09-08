using ExcelDataReader;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ExcelTest.Shared
{
    public class ExcelTableBase : ComponentBase
    {

        public MemoryStream _fileMemoryStream;

        [Parameter]
        public MemoryStream FileMemoryStream
        {
            get { return _fileMemoryStream; }
            set { _fileMemoryStream = value; }
        }


        protected override void OnInitialized()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var reader = ExcelReaderFactory.CreateCsvReader(FileMemoryStream))
            {
                // Choose one of either 1 or 2:

                // 1. Use the reader methods
                do
                {
                    
                    while (reader.Read())
                    {
                        // reader.GetDouble(0);
                    }
                } while (reader.NextResult());

                // 2. Use the AsDataSet extension method
                var result = reader;

                // The result of each spreadsheet is in result.Tables
            }
        }
    }
}
