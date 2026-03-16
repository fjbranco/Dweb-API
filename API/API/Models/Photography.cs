using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    /// <summary>
    /// Dados das fotografias
    /// </summary>
    public class Photography
    {
        /// <summary>
        /// chave primaria
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// nome da foto
        /// </summary>
        [StringLength(50)]
        [Required(ErrorMessage ="O {0} é obrigatório")]
        [Display(Name ="Título")]
        public string Title { get; set; }=string.Empty; // <=> "";
        /// <summary>
        /// descrição da foto
        /// </summary>
        [StringLength(200)]
        [Display(Name = "Descrição")]
        public string? Description { get; set; }
        /// <summary>
        /// nome do ficheiro da fotografia
        /// </summary>
        [StringLength(40)]
        public string File { get; set; } = "";
        /// <summary>
        /// data em que foi colocada a fotografia
        /// </summary>
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        /// <summary>
        /// preço da fotografia
        /// </summary>
        [Display(Name = "Preço")]
        [Precision(10,2)]
        public decimal Price { get; set; }


        /* ********************************************
         * Relacionamentos
         * ******************************************** */

        /// <summary>
        /// FK para Category da foto
        /// </summary>
        [ForeignKey(nameof(Category))]
        public int CategoryFK { get; set; }
        /// <summary>
        /// FK para Category da foto
        /// </summary>
        public Category Category { get; set; } = null!;

        /* ********************************************
         * Relacionamentos N-M
         * ******************************************** */

        /// <summary>
        /// Lista de compras que o uma foto foi comprada
        /// </summary>
        public ICollection<Purchase> ListOfPurchase { get; set; } = [];
    }
}
