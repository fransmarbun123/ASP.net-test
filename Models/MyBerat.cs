using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Berat.Models
{
    public class MyBerat
    {
        public int Id
        {
            get;set;
        }

        [Required(ErrorMessage = "Please Enter Tanggal")]
        public DateTime Tanggal
        {
            get;set;
        }
        [Required(ErrorMessage = "Please Enter Berat Max")]
        public int Max
        {
            get;set;
        }
        [Required(ErrorMessage = "Please Enter Berat Min")]
        public int Min
        {
            get;set;
        }
        public int Perbedaan
        {
            get;set;
        }
    }
}