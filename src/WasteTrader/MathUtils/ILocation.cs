namespace WasteTrader.MathUtils
{
    public interface ILocation
    {
        double LongitudeDD { get; set; }
        double LatitudeDD { get; set; }
        double LongitudeRadians { get; }
        double LatitudeRadians { get; }
    }
}
