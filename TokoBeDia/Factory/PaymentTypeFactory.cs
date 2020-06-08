using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokoBeDia.Factory
{
    public class PaymentTypeFactory
    {
        public static PaymentType createPaymentType(string type)
        {
            return new PaymentType()
            {
                Type = type
            };
        }
    }
}