using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Storage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StorageId { get; set; }

        public List<Area> Areas { get; set; }
        
        public DateTime StorageFormationDate { get; set; }


    }
}
