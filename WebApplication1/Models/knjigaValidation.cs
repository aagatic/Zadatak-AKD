using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [MetadataType(typeof(knjigaMetaData))]

    public partial class knjiga
    {
        public class knjigaMetaData
        {
            [DisplayName("Naslov")]
            public string naziv { get; set; }

            [DisplayName("Godina izdanja")]
            public short godina_izdanja { get; set; }
            [DisplayName("Autor")]
            public int autorID { get; set; }
        }
    }
}