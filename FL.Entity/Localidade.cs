using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FL.Entity
{
    public class Localidade : ILocalidade
    {
        private int _IDLocalidade;
        private float _Latitude;
        private float _Longitude;
        private double _DistanciaEuclidiana;

        public int IDLocalidade
        {
            get
            {
                return _IDLocalidade;
            }

            set
            {
                _IDLocalidade = value;
            }
        }

        public float Latitude
        {
            get
            {
                return _Latitude;
            }

            set
            {
                _Latitude = value;
            }
        }

        public float Longitude
        {
            get
            {
                return _Longitude;
            }

            set
            {
                _Longitude = value;
            }
        }

        public double DistanciaEuclidiana
        {
            get
            {
                return _DistanciaEuclidiana;
            }

            set
            {
                _DistanciaEuclidiana = value;
            }
        }

        public void getDistanciaEuclidiana(float pLatitude, float pLongitude)
        {
            DistanciaEuclidiana =  Math.Sqrt(Math.Pow((pLatitude - _Latitude),2) + Math.Pow((pLongitude - _Longitude),2)); 
        }               
    }
}
