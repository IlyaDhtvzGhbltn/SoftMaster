using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Picket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PicketId { get; set; }

        [MaxLength(10)]
        public string Title { get; set; }

        public virtual List<Cargo> Cargos { get; set; }

        public Guid AreaId { get; set; }
        public Area Area { get; set; }
    }
}
