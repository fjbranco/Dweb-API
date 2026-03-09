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
    }
}
