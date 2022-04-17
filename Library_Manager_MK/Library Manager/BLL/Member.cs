using System;
using System.Collections.Generic;

namespace LibraryManager.BLL
{
    public class Member
    {
        public String id { get; set; }
        public String name { get; set; }
        public String nationality { get; set; }
        public DateTime birthDate { get; set; }

        List<PaymentRequest> paymentRequests;

        public Member(string id, string name, string nationality, DateTime birthDate)
        {
            this.id = id;
            this.name = name;
            this.nationality = nationality;
            this.birthDate = birthDate;

            paymentRequests = new List<PaymentRequest>();
        }

        public void FulfilPaymentRequest(PaymentRequest request)
        {
            if (paymentRequests.Contains(request))
            {
                _ = paymentRequests.Remove(request);
            }
        }

        public bool HasOngoingPaymentRequest()
        {
            return (paymentRequests.Count > 0);
        }

        public void AssignPaymentRequest(PaymentRequest request)
        {
            paymentRequests.Add(request);
        }
    }
}
