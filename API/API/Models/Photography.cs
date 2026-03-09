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
        public string Title { get; set; }
        /// <summary>
        /// descrição da foto
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// nome do ficheiro da fotografia
        /// </summary>
        public string File { get; set; }
        /// <summary>
        /// data em que foi colocada a fotografia
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// preço da fotografia
        /// </summary>
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
        public Category Category { get; set; }

        /* ********************************************
         * Relacionamentos N-M
         * ******************************************** */

        /// <summary>
        /// Lista de compras que o uma foto foi comprada
        /// </summary>
        public ICollection<Purchase> ListOfPurchase { get; set; }
    }
}
