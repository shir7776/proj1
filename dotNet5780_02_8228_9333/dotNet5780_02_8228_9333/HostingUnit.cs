using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using dotNet5780_02_8228_9333;

namespace dotNet5780_02_8228_9333
{
    class HostingUnit: IComparable
    {
        private static int stSerialKey=0;
        public readonly int hostingUnitKey;
        private bool[,] diary ;
        public HostingUnit()
        {
            stSerialKey++;
            hostingUnitKey = stSerialKey ;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    diary[i, j] = false;
        }
        
        
        
        public bool[,] Diary
        {
            get{ return diary; }
        }
        public override string ToString()
        {
            Console.WriteLine(string.Format("unit number: {0}", hostingUnitKey));
            bool start = false;
            for(int i=0;i<12;i++)
            {
                for(int j=0;j<31;j++)
                {
                    if(start==false && diary[i,j]==true)
                    {
                        Console.WriteLine(string.Format("start period: {0}/{1}", j,i));
                        start = true;
                    }
                    if(start == true && diary[i, j] == false)
                    {
                        Console.WriteLine(string.Format("end period: {0}/{1}", j, i));
                        start = false;
                    }

                }
            }
            return "";
        }
        public bool ApproveRequest(GuestRequest guestReq)
        {
            int startDay = guestReq.GetEntryDate().Day;
            int startMonth = guestReq.GetEntryDate().Month;
            int endDay = guestReq.GetReleaseDate().Day;
            int endMonth = guestReq.GetReleaseDate().Month;
            int i = startDay;
            int j = startMonth;
            while(true)
            {
                if (i == endDay && j == endMonth)
                    break;
                if (diary[i - 1, j - 1] == false)
                {
                    i++;
                    j++;
                    if (i == 31)
                    {
                        i = 0;
                        j = (j + 1) % 12;
                    }
                }
                else return false;
            }
             i = startDay;
             j = startMonth;
            while (true)
            {
                if (i == endDay && j == endMonth)
                    break;
                diary[i - 1, j - 1] = true;
                i++;
                j++;
                if (i == 31)
                {
                    i = 0;
                    j = (j + 1) % 12;
                }
            }
            return true; 
        }
        public int GetAnnualBusyDays()
        {
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if ( diary[i, j] == true)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }

        public float GetAnnualBusyPercentage()
        {
            int days = GetAnnualBusyDays();
            return days / (12 * 31);
        }
        public int CompareTo(object obj) 
        {
            int count = 0;
            int x = 0;
            int y = 0;
            HostingUnit hu = (HostingUnit)obj;
            for (int i = 0; i < 12; i++)
            { 
                for (int j = 0; j < 31; j++)
                {
                    if (diary[i, j] == hu.diary[i, j])
                        count++;
                    else
                        if (diary[i, j] == true)
                        x++;
                    else
                        y++;
                }
            }
            if (count == 12 * 31)
                return 0;
            else
                if (x > y)
                    return 1;
                else
                    return -1;

        }
    }
}