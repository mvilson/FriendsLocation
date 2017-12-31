namespace FL.Entity
{
    public interface ILocalidade
    {
        int IDLocalidade { get; set; }
        float Latitude { get; set; }
        float Longitude { get; set; }
        double DistanciaEuclidiana { get; set; }
        void getDistanciaEuclidiana(float pLatitude, float pLongitude);
    }
}