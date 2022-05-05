using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Prova
{
    public class Prova : BaseEntity
    {
        public string Name { get; set; }
        public Prova(string name)
            : base()
        {
            Name = name;
            CreatedOn = DateTime.UtcNow;
        }
    }
}
