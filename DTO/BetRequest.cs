using System.ComponentModel.DataAnnotations;

namespace ApiRuletaOnline.Controllers.DTO
{
    public class BetRequest
    {
        /// <summary>
        /// posi 0-36 - 37 > red and 38 => black
        /// </summary>
        [Range(0, 38)]
        public int position { get; set; }

        /// <summary>
        /// Bet Money
        /// </summary>
        [Range(0.5d, maximum: 10000)]
        public double money { get; set; }
    }
}