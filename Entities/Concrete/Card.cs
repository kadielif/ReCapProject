using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Card:IEntity
    {
        public int? Id { get; set; }
        public string CardNo { get; set; }
        public string UserName  { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public string Cvc { get; set; }
    }
}
