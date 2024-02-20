using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business;

public static class LinkValidator
{
    public static bool IsLinkValid(string link)
    {
        // Link formatını kontrol etmek için bir Regex kullanma
        string linkPattern = @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
        Regex regex = new Regex(linkPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

        return regex.IsMatch(link);
    }
}
