using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseMax
{
    public class Duty
    {
        public int DutyId { get; set; }
        public DateTime DutyStart { get; set; }
        public DateTime DutyEnd { get; set; }
        public int ProfileId { get; set; }

        public Duty() { }

        public Duty(int dutyId, DateTime dutyStart, DateTime dutyEnd, int profileId)
        {
            DutyId = dutyId;
            DutyStart = dutyStart;
            DutyEnd = dutyEnd;
            ProfileId = profileId;
        }

        public override string ToString()
        {
            return $"Duty id: {DutyId}, DutyStart: {DutyStart}, DutyEnd: {DutyEnd}, Profile id: {ProfileId}";
        }
    }
}
