using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTechRepositoryProject
{
    public class CarFactory
    {
        public ICar GetCar(string carName)
        {
            switch (carName)
            {
                case "Four Wheeler":
                    return new FourWheeler();

                case "Two Wheeler":
                    return new TwoWheeler();
                   
            }
            return null;
        }
    }
}
