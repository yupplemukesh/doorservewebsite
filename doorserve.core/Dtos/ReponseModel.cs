using System;
using System.Collections.Generic;
using System.Text;

namespace Doorserve.Core.Dtos
{
   public class ReponseModel
    {
        public int ReponseCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Reponse { get; set;}
    }
}
