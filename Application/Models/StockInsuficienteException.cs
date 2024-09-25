using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class StockInsuficienteException:Exception
    {
        public StockInsuficienteException(string message):base(message){ }
    }
}
