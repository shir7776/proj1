using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace DateTime { }

namespace dotNet5780_02_8228_9333
{
    class GuestRequest
    {
        private DateTime entryDate;
        private DateTime releaseDate;
        private bool isApproved;
        public bool IsApproved
        {
            get { return isApproved; }
            set{ isApproved = value; } 
        }
        public override string ToString()
        {
            return string.Format("entry date: {0}, release date: {1}, is approved? {2}", entryDate, releaseDate, isApproved);
        }
        public DateTime GetEntryDate()
        {
            return entryDate;
        }
        public DateTime GetReleaseDate()
        {
            return releaseDate;
        }
        //public bool GetIsApproved()
        //{
        //    return isApproved;
        //}
        public void SetReleaseDate(int day, int month, int year)
        {
            releaseDate = new DateTime(year, month, day);
        }
        //public void IsApproved(bool ans)
        //{
        //    isApproved = ans;
        //}

        public void SetRealeseDate(int day, int month,int year)
        {
            entryDate = new DateTime(year, month, day);
        }
    }
}
