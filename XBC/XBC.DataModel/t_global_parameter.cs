namespace XBC.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_global_parameter
    {
        public long id { get; set; }

        [Required]
        [StringLength(10)]
        public string code { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(255)]
        public string notes { get; set; }

        public long created_by { get; set; }

        public DateTime created_on { get; set; }

        public long? modified_by { get; set; }

        public DateTime? modified_on { get; set; }

        public long? deleted_by { get; set; }

        public DateTime? deleted_on { get; set; }

        public bool is_delete { get; set; }
    }
}
