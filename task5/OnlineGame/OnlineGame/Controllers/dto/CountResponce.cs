using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGame.Controllers.dto
{
    public class CountResponce
    {
        public int Count { get; set; }

        public CountResponce(int count)
        {
            Count = count;
        }
    }
}
