namespace OOP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FVID { get; set; }

        public float Cost { get; set; }
    }
}
