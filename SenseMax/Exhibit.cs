using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseMax
{
    public class Exhibit
    {
        private int _ExhibitId;

        public int ExhibitId
        {
            get
            {
                return _ExhibitId;
            }
            set
            {
                if (_ExhibitId != value)
                {
                    _ExhibitId = value;
                }
                else throw new ArgumentException("Der skal være et id");
            }
        }
        public string _Name;
        public string Name
        {
            get
            { return _Name; }
            set
            {
                if (value.Length <= 2)
                {
                    _Name = value;
                }
                else
                {
                    throw new ArgumentException("Et navn skal have minimum 2 bogstaver");
                }
            }
        }


        public int ActualVcount { get; set; }
        public int MaxVcount { get; set; }

        public Exhibit(int exhibitId, string name, int actualVcount, int maxVcount)
        {
            ExhibitId = exhibitId;
            Name = name;
            ActualVcount = actualVcount;
            MaxVcount = maxVcount;
        }

        public override string ToString()
        {
            return $"{{{nameof(ExhibitId)}={ExhibitId.ToString()}, {nameof(Name)}={Name}, {nameof(ActualVcount)}={ActualVcount.ToString()}, {nameof(MaxVcount)}={MaxVcount.ToString()}}}";
        }
    }
}
}
