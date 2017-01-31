using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdeallyConnected.Models
{
    public enum SoftwareTypes 
    {
        OperatingSystem,
        TextEditor,
        Presentation,
        PhotoEditor,
        Gaming,
        Design,
        Browser,
        ProgrammingTool
    }

    public class Software
    {
        [Key]
        public String Id { get; set; }
        public SoftwareTypes Type { get; set; }
    }
}