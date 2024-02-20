using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;  

namespace Business;
public interface IExcelService
{
    Task<string> AnalyzeExcelFile(byte[] excelData);
}

