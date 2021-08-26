using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommanderAPI.Dtos
{
    public class CommandCreateDto
    {
        // public int Id { get; set; }  -> Id не существует до его создания в базе
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string Platform { get; set; }
    }
}
