using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL.Common
{
    public sealed class Singleton<T> where T : class, new()
    {
        private static T instance;

        private Singleton() { }

        public static T Intance
        {
            get
            {
                if(instance == null)
                      lock (typeof(T))
                        if (instance == null)
                            instance = new T();

                return instance;
            }
        }
    }
}
