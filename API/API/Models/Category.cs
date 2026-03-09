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
        public string Category { get; set; }

        /* ********************************************
         * Relacionamentos
         * ******************************************** */

        /// <summary>
        /// Lista de fotografias que a categoria tem
        /// </summary>
        public ICollection<Photography> ListOfPhotos { get; set; }
    }
}
