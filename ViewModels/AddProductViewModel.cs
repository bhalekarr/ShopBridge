using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBridge.ViewModels
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Date Required")]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Display(Name ="Product Code")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Product Name Required")]
        [Display(Name = "Product Name")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }


        [Display(Name = "Product Description")]
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }


        [Display(Name = "Quantity")]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? Qty { get; set; }

        [Display(Name = "Price")]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? Price { get; set; }

        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public decimal? Amount
        {
            get;set;
            //{
            //    return Qty * Price;
            //}
        }

        [Display(Name = "Narration / Remarks")]
        [DataType(DataType.MultilineText)]
        public string Narration { get; set; }

        public string Username { get; set; }

    }
}
