namespace API.Models
{
    /// <summary>
    /// dados do utilizador no site
    /// </summary>
    public class MyUser
    {
        /// <summary>
        /// chave primária
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nome do utilizador
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// morada do utilizador
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// código postal
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// país
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Numero de identificação fiscal
        /// </summary>
        public string TaxNumber { get; set; }
        /// <summary>
        /// Telemóvel
        /// </summary>
        public string CellPhone { get; set; }
    }
}
