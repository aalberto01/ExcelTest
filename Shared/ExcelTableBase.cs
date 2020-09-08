using Microsoft.AspNetCore.Components;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ExcelTest.Shared
{
    public class ExcelTableBase : ComponentBase
    {
        private int limit = 100;
        public MemoryStream _fileMemoryStream;

        [Parameter]
        public MemoryStream FileMemoryStream
        {
            get { return _fileMemoryStream; }
            set { _fileMemoryStream = value; }
        }
        protected List<object> headers = new List<object>();
        protected List<List<object>> data = new List<List<object>>();

        protected override void OnInitialized()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (ExcelPackage package = new ExcelPackage(FileMemoryStream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rows = worksheet.Dimension.Rows;
                int columns = worksheet.Dimension.Columns;
                for (int row = 1; row < limit && row < rows; row++)
                {
                    List<object> rowData = new List<object>();
                    for (int col = 1; col < columns; col++)
                    {
                        var cell = worksheet.Cells[row, col];
                        if (row == 1)
                        {
                            headers.Add(cell.Value);
                        }
                        else
                        {
                            rowData.Add(cell.Value);
                        }
                    }
                    data.Add(rowData);
                }
            }
        }
    }
}
