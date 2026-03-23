namespace API.Models.ViewModels
{
    /// <summary>
    /// Lista de Photos
    /// </summary>
    public class PhotoDTO
    {
        /// <summary>
        /// O Id da foto na base de dados
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// O 'titulo' da Photography
        /// </summary>
        public string Title { get; set; } = "";
        /// <summary>
        /// O 'titulo' da Photography
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// O nome do ficheiro da Photography
        /// </summary>
        public string File { get; set; } = "";


    }
}
