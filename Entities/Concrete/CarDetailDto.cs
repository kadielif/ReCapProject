using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarDetailDto:IDTOs
    {
        //CarName, BrandName, ColorName, DailyPrice
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
    }
}
