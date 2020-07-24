using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Webgentle.BookStore.Enums;
using Webgentle.BookStore.Helper;
using Microsoft.AspNetCore.Http;

namespace Webgentle.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        //[StringLength(100, MinimumLength = 5)]
        //[Required(ErrorMessage ="Please enter the title of your book")]

        //[MyCustomValidationAttribute("mvc")]
        [Required(ErrorMessage = "Please enter the title of your book")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the author of your book")]
        public string Author { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string Category { get; set; }

        //[Required(ErrorMessage ="Please enter your language")]
        public int LanguageId { get; set; }

        public string Language { get; set; }

        [Required(ErrorMessage = "Please enter your language")]
        public LanguageEnum LanguageEnum { get; set; }

        [Required(ErrorMessage = "Please enter the total number of pages of your book")]
        [Display(Name = "Total Pages of book")]
        public int? TotalPage { get; set; }

        [Display(Name = "Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose the Gallery photo of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

        [Display(Name = "Upload your book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }

        public string BookPdfUrl { get; set; }
    }
}
