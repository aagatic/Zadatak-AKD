using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [MetadataType(typeof(autorMetaData))]
    public partial class autor
    {
        public class autorMetaData
        {
            [DisplayName("Ime")]
            public string ime { get; set; }
            [DisplayName("Prezime")]
            public string prezime { get; set; }
        }
    }
}