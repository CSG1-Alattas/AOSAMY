using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AOSAMY.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public byte[]? Img { get; set; }
        public int? TypeProductid { get; set; }
        public int? UserLogid { get; set; }

        public virtual TypeProduct? TypeProduct { get; set; }
        public virtual UserInfo? UserLog { get; set; }
        [NotMapped]
        public IFormFile clientFile { get; set; }

        

        [NotMapped]
        public string? imgSrs
        {
            get
            {
                if (Img != null)
                {
                    string base64string = Convert.ToBase64String(Img, 0, Img.Length);
                    return "data:image/jpg;base64" + base64string;

                }
                else { return string.Empty; }
            }
        }
    }
}
