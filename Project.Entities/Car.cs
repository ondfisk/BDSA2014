using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public byte[] Photo { get; set; }

        /// <summary>
        /// Engine Displacement in CC
        /// </summary>
        public int EngineDisplacement { get; set; }

        /// <summary>
        /// Engine Power in BHP
        /// </summary>
        public int EngineMaxPower { get; set; }

        /// <summary>
        /// Seconds from 0-100 km/h
        /// </summary>
        public double NoughtTo100 { get; set; }

        /// <summary>
        /// Top speed in km/h
        /// </summary>
        public int TopSpeed { get; set; }

        public virtual ICollection<Employee> Sold { get; set; }

        public FuelType FuelType { get; set; }
    }
}
