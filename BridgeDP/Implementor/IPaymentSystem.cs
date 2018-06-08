using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDP
{
    public interface IPaymentSystem
    {
        void ProcessPayment(string paymentSystem);
    }
}
