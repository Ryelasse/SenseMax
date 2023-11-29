namespace SenseMax
{
    public class Artwork
    {
        public Artwork(int artid, string name, double actualtemp, double actualhumidity, double mintemp, double maxtemp, double minhumidity, double maxhumidity)
        {
            ArtId = artid;
            Name = name;
            ActualTemp = actualtemp;
            ActualHumidity = actualhumidity;
            MinTemp = mintemp;
            MaxTemp = maxtemp;
            MinHumidity = minhumidity;
            MaxHumidity = maxhumidity;

        }

        const double ValidTemp = 10;
        const double UnderTemp = -15;
        const double OverTemp = 30;

        const double Mitemp = 5;
        const double Matemp = 25;

        public int ArtId { get; set; }
        public string Name { get; set; }
        public double ActualTemp { get; set; }
        public double ActualHumidity { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public double MinHumidity { get; set; }
        public double MaxHumidity { get; set; }

        public void ValidateTemp()
        {
            if (MinTemp > ActualTemp)
            {
                throw new ArgumentOutOfRangeException(nameof(MinTemp), $"The Temperature is too low, it must be higher than {MinTemp}!");
            }
            if (MaxTemp < ActualTemp)
            {
                throw new ArgumentOutOfRangeException(nameof(MaxTemp), $"The Temperature is too high, it must be lower than {MaxTemp}!");
            }

        }

        public void ValidateHumidity()
        {
            if (MinHumidity > ActualHumidity)
            {
                throw new ArgumentOutOfRangeException(nameof(MinHumidity), $"The Humidity is too low, it must be higher than {MinHumidity}!");
            }
            if (MaxHumidity < ActualHumidity)
            {
                throw new ArgumentOutOfRangeException(nameof(MaxHumidity), $"The Humidity is too high, it must be lower than {MaxHumidity}!");
            }
        }

        public void Validate()
        {
            ValidateHumidity();
            ValidateTemp();
        }

    }
}
