using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    /// <summary>
    /// categoria que a foto tem
    /// </summary>
    public class Category
    {
        /// <summary>
        /// chave primária
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nome da categoria
        /// </summary>
        [StringLength(20)] // dimensão máxima do texto a introduzir
        [Required(ErrorMessage ="O nome da categoria é obrigatório")] // mensagem de erro quando não é inserido nome da categoria
        [Display(Name="Nome da Categoria")] // o nome que irá aparecer no ecrã
        public string Name { get; set; } = "";

        /* ********************************************
         * Relacionamentos
         * ******************************************** */

        /// <summary>
        /// Lista de fotografias que a categoria tem
        /// </summary>
        public ICollection<Photography> ListOfPhotos { get; set; } = [];
    }
}
