using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTechRepositoryProject
{
    internal class TeachersRepo : IT_Rpo
    {
        public void delete(int id)
        {
            Teachers teachers = TeachersDB.teacherslist.FirstOrDefault(z=>z.teacherId == id);
            TeachersDB.teacherslist.Remove(teachers);
        }

        public IEnumerable<Teachers> GetAll()
        {
            return
                TeachersDB.teacherslist;
        }

        public Teachers GetId(int id)
        {
            Teachers teacher=TeachersDB.teacherslist.FirstOrDefault(z=>z.teacherId==id);
            return teacher;
        }

        public void Insert(Teachers teachers)
        {
            TeachersDB.teacherslist.Add(teachers);
        }

        public void Update(Teachers teachers)
        {
            Teachers _teachers=TeachersDB.teacherslist.FirstOrDefault(z=>z.teacherId == teachers.teacherId);
            if (teachers!=null)
            {
                _teachers.teacherName= teachers.teacherName;
            }
            if (teachers!=null) 
            {
               _teachers.Dsignation= teachers.Dsignation;
            }
            if (teachers != null)
            {
                _teachers.ContactNumber = teachers.ContactNumber;
            }
            if (teachers != null)
            {
                _teachers.Subject = teachers.Subject;
            }
        }
    }
}
