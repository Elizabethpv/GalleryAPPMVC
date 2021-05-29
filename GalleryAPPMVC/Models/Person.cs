using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GalleryAPPMVC.Models
{
    public class Person
    {
        
       
        public String  Name { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }

        public Image images { get; set; }

        public String Message { get; set; }




    }
}