using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDateTime{ get; set; }=DateTime.UtcNow;
    }
}