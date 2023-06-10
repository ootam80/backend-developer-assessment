using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Logics
{
    public class BusinessLogicFactory
    {
        public static IBusinessLogic Create()
        {
            return new BusinessLogic();
        }
    }

}
