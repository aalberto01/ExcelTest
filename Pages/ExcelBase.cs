using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelTest.Pages
{
    public class ExcelBase : ComponentBase
    {
        protected string status;
        protected MemoryStream ms;

        protected async Task HandleSelection(IFileListEntry[] files)
        {

            var file = files.FirstOrDefault();
            if (file != null)
            {
                // Just load into .NET memory to show it can be done
                // Alternatively it could be saved to disk, or parsed in memory, or similar
                ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);


                status = $"Finished loading {file.Size} bytes from {file.Name}";
            }
        }


    }
}

