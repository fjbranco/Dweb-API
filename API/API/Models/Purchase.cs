using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    /// <summary>
    /// dados relacionados com a compra de fotos pelo utilizador
    /// </summary>
    public class Purchase
    {
        /// <summary>
        /// chave primária
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// data de compra
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// estado da compra
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// estados disponíveis relacionados com a compra
        /// </summary>
        public enum State
        {
            Pending,
            Paid,
            Sent,
            Delivery,
            Closed
        }

        /* ********************************************
         * Relacionamentos
         * ******************************************** */

        /// <summary>
        /// FK do comprador para a compra
        /// </summary>
        [ForeignKey]
        public int BuyerFK { get; set; }
        /// <summary>
        /// FK do comprador para a compra
        /// </summary>
        public MyUser Buyer { get; set; }


    }
    

    
}
