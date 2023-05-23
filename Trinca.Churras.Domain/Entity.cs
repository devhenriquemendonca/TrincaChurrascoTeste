using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinca.Churras.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; private set; }
 
        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}
