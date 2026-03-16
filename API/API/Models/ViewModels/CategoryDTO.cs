namespace API.Models.ViewModels
{
    /// <summary>
    /// Lista de Categories
    /// </summary>
    public class CategoryDTO
    {
        /// <summary>
        /// O Id da Category na base de dados
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// O 'nome' da Category
        /// </summary>
        public String Name { get; set; } = ""; // <=> string.Empty;
    }
}
