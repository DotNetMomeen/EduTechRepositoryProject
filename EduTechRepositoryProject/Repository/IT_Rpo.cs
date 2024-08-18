using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTechRepositoryProject
{
    public interface IT_Rpo
    {
        IEnumerable<Teachers> GetAll();
        Teachers GetId(int id);
        void Insert(Teachers teachers);
        void Update(Teachers teachers);
        void delete(int id);

    }
}
