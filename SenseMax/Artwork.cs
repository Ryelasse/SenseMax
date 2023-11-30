namespace SenseMax
{
    public class Artwork
    {
        public int ArtworkId { get; private set; }
        public string ArtworkName { get; set; }
        public double ActualTemp { get; set; }
        public double ActualHumidity { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public double MinHumidity { get; set; }
        public double MaxHumidity { get; set; }

        public Artwork() { }
        public Artwork(string name, double actualtemp, double actualhumidity, double mintemp, double maxtemp, double minhumidity, double maxhumidity)
        {
            ArtworkName = name;
            ActualTemp = actualtemp;
            ActualHumidity = actualhumidity;
            MinTemp = mintemp;
            MaxTemp = maxtemp;
            MinHumidity = minhumidity;
            MaxHumidity = maxhumidity;

        }

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
        public override string ToString()
        {
            return $"{{{nameof(ArtworkId)}={ArtworkId.ToString()}, {nameof(ArtworkName)}={ArtworkName}, {nameof(ActualTemp)}={ActualTemp.ToString()}, {nameof(ActualHumidity)}={ActualHumidity.ToString()}, {nameof(MinTemp)}={MinTemp.ToString()}, {nameof(MaxTemp)}={MaxTemp.ToString()}, {nameof(MinHumidity)}={MinHumidity.ToString()}, {nameof(MaxHumidity)}={MaxHumidity.ToString()}}}";
        }
    }
}
