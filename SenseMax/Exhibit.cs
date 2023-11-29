using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenseMax
{
    public class Exhibit
    {
        private int _exhibitId;

        public int ExhibitId
        {
            get
            {
                return _exhibitId;
            }
            set
            {
                if (_exhibitId == value)
                {
                    _exhibitId = value;
                }
                else throw new ArgumentException("Der skal være et id");
            }
        }
        private string _name;
        public string Name
        {
            get
            { return _name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Navn kan ikke være null");
                }
                if (value.Length >= 2)
                {
                    _name = value;
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

        public Exhibit()
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(ExhibitId)}={ExhibitId.ToString()}, {nameof(Name)}={Name}, {nameof(ActualVcount)}={ActualVcount.ToString()}, {nameof(MaxVcount)}={MaxVcount.ToString()}}}";
        }
    }
}

