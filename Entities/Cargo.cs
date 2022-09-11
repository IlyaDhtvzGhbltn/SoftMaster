using BaseTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Cargo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public CargoType Type { get; set; }

        public DateTime ShipmentDate { get; set; }

        public DateTime UnloadingDate { get; set; }

        public int Weight { get; set; }

        public Guid PicketId { get; set; }
        public Picket Picket { get; set; }
    }
}