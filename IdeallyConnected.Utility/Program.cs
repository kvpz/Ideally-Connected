using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScrapySharp.Core;
using ScrapySharp.Html.Parsing;
using ScrapySharp.Network;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Html.Forms;

namespace IdeallyConnected.Utility
{
    class SoftwareDataScrapper
    {
        static void Main(string[] args)
        {
            ScrapingBrowser Browser = new ScrapingBrowser();
            Browser.AllowAutoRedirect = true;
            Browser.AllowMetaRedirect = true;

        }
    }
}
