using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIXClient
{
    public class SpotOrderMulti : INewOrderMultiLeg
    {
        public string OrderType { get; set; }
        public string ClientRequestId { get; private set; }
        public INewOrderSingle[] Legs { get; set; }
        public int AlertType { get; set; }
        public string TIF { get; set; }
        public string ActiveTimeStamp { get; set; }
        public string ActiveTimeZone { get; set; }
        public string ExpireTimeStamp { get; set; }
        public string ExpireTimeZone { get; set; }

        private static long _requestId;


        private static long RequestId {
            get {
                if (_requestId == long.MaxValue) _requestId = 0;
                return ++_requestId;
            }
        }

        public SpotOrderMulti(string type)
        {
            OrderType = type;
            ClientRequestId = string.Format("{0}.{1:yyyyMMddHHmmss}.{2, 12:D12}", "STSP-Multi", DateTime.Now, RequestId);
        }
    }
}
