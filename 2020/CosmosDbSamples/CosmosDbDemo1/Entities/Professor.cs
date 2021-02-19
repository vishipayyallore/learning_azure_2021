using System;
using System.ComponentModel.DataAnnotations;

namespace CosmosDbDemo1.Entities
{

    public class Professor
    {
        [Key]
        public Guid ProfessorId { get; set; }

        public string Name { get; set; }

        public DateTime Doj { get; set; }

        public string Teaches { get; set; }

        public decimal Salary { get; set; }

        public bool IsPhd { get; set; }
    }

}
