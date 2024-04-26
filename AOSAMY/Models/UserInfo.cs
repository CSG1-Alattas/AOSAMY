using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AOSAMY.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? ScendName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Specialty { get; set; }
        public byte[]? Img { get; set; }
        public string? Description { get; set; }
        public int? PhoNum { get; set; }
        public string? Addres { get; set; }
        public string? CopnyName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
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
