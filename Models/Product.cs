using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBridge.Models
{

    [Table("Products")]
    public class Product
    {
        //ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        [Display(Name = "Id")]
        public int ProductId { get; set; }

        //Product Code
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        //Date of Item Addition in Inventory
        [Required(ErrorMessage = "Date Required")]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ProductDate { get; set; }

        //Product Name
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        //Product Description
        [Display(Name = "Product Description")]
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }

        //Quantity
        [Display(Name = "Quantity")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Qty { get; set; }

        //Price
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }

        //Amount = Qty * Price
        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Amount { get; set; }

        //Remarks of Narration if any
        [Display(Name = "Narration / Remarks")]
        [DataType(DataType.MultilineText)]
        public string NarrationRemarks { get; set; }

        //Username
        public string Username { get; set; }

    }
}
