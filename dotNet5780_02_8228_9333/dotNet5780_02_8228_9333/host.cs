using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_02_8228_9333
{
    class Host//: IEnumerable
    {
        public List<HostingUnit> HostingUnitCollection { set; get; }
        private int hostkey;
        public int Hostkey
        {
            get { return hostkey; }
            set { hostkey = value; }
        }
        public Host(int id, int x)
        {
            hostkey = id;
            HostingUnit h = new HostingUnit();
            for (int i = 0; i < x; i++)
            {
                HostingUnitCollection.Add(h);
            }
        }
        public override string ToString()
        {
            foreach (HostingUnit n in HostingUnitCollection)
            {
                n.ToString();
            }
            return "";
        }

        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach (HostingUnit n in HostingUnitCollection)
            {
                if (n.ApproveRequest(guestReq))
                    return n.hostingUnitKey;
            }
            return -1;
        }

        public int GetHostAnnualBusyDays()
        {
            int sum = 0;
            foreach (HostingUnit n in HostingUnitCollection)
            {
                sum += n.GetAnnualBusyDays();
            }
            return sum;
        }

        public void SortUnits()
        {
            HostingUnitCollection.Sort(
                delegate (HostingUnit i, HostingUnit j)
                {
                    return i.GetAnnualBusyDays().CompareTo(j.GetAnnualBusyDays());
                });

        }
        public bool AssignRequests(params GuestRequest[] arr)
        {
            foreach (GuestRequest g in arr)
            {
                if (SubmitRequest(g) == -1)
                    return false;
            }
            return true;
        }
        public HostingUnit this[int num]
        {
            get
            {
                foreach (HostingUnit n in HostingUnitCollection)
                {
                    if (n.hostingUnitKey == num)
                        return n;
                }
                return null;
            }
        }
        //public IEnumerable GetEnumaerabl()
        //{
        //    foreach (HostingUnit n in HostingUnitCollection)
        //    {
        //        return ;
        //    }
            
        //}

    }

}
