﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Business
{
    public interface ILinkService
    {
        Task<string> AnalyzeLinkContent(string link);
    }
}
