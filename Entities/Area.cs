using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Area
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AreaId { get; set; }

        [MaxLength(10)]
        public string Title { get; set; }

        public List<Picket> Pickets { get; set; }

        public DateTime AreaFormationDate { get; set; }

        public Guid StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}