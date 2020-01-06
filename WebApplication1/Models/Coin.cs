using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Coin
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string BaseAsset { get; set; }
        [Required]
        public  string QuoteAsset { get; set; }
        public double LastPrice { get; set; }
        public double Volumn24h { get; set; }
        public int MarketId { get; set; }
        public virtual Market Market { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Status { get; set; }

    }
}