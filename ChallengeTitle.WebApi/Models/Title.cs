namespace ChallengeTitle.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Title")]
    public partial class Title
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Title()
        {            
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TitleId { get; set; }

        [StringLength(100)]
        public string TitleName { get; set; }

        [StringLength(100)]
        public string TitleNameSortable { get; set; }

        public int? TitleTypeId { get; set; }

        public int? ReleaseYear { get; set; }

        public DateTime? ProcessedDateTimeUTC { get; set; }
    }
}
