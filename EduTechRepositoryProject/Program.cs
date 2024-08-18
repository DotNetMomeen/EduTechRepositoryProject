using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EduTechRepositoryProject
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            OnlyDisplay();

            // This Is For FactoryPattern

           CarFactory carFactory = new CarFactory();
            ICar FourWheeler=carFactory.GetCar(" Four Wheeler");
            ICar TwoWheeler= carFactory.GetCar(" Two Wheeler");
            Console.ReadKey();
        }

        public static void OnlyDisplay()
        {
            Console.WriteLine(" 1 = Show All(Teachers Information)");
            Console.WriteLine(" 2 = Insert Data");
            Console.WriteLine(" 3 = Update Data");
            Console.WriteLine(" 4 = Delete Info");
            var display = Convert.ToInt32(Console.ReadLine());
            ShowInfo(display);
        }
        public static void ShowInfo(int display)
        {
            TeachersRepo _teachersRepo = new TeachersRepo();

            if (display == 1)
            {
                var teacherlist = _teachersRepo.GetAll();
                if (teacherlist.Count() == 0)
                {
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                    Console.WriteLine(" There isn't any information available....");
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                    OnlyDisplay();
                }
                else
                {
                    Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                    foreach (var v in _teachersRepo.GetAll())
                    {
                        Console.WriteLine($"Teacher Id :{v.teacherId}, Teacher Name :{v.teacherName}, Designation :{v.Dsignation}, Contact No :{v.ContactNumber}, Subject :{v.Subject}");
                    }
                    Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                    OnlyDisplay();
                }
            }
            //diplay 2 for insert data
            else if (display == 2)
            {
                Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                Console.Write(" Name :");
                string name = Console.ReadLine();

                Console.Write(" Designation :");
                string desig = Console.ReadLine();

                Console.Write(" Contact No :");
                double contact = Convert.ToDouble(Console.ReadLine());

                Console.Write(" Subject :");
                string sub = Console.ReadLine();

                int maxId = _teachersRepo.GetAll().Any() ? _teachersRepo.GetAll().Max(z => z.teacherId) : 0;

                Teachers teachers = new Teachers
                {
                    teacherId = maxId + 1,
                    teacherName = name,
                    Dsignation = desig,
                    ContactNumber = contact,
                    Subject = sub

                };
                _teachersRepo.Insert(teachers);
                Console.WriteLine(" Data Inserted successfully!!!");
                Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                OnlyDisplay();
            }
            //display 3 for update data
            else if (display == 3)
            {
                Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                Console.Write(" Please enter the Teacher ID for Updating : ");
                int id = Convert.ToInt32(Console.ReadLine());
                var _teachersId = _teachersRepo.GetId(id);
                if (_teachersId == null)
                {
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                    Console.WriteLine(" The Teacher ID is invalid !!!");
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                    OnlyDisplay();
                    return;
                }
                else
                {
                    Console.WriteLine($"Please update the information for the Teacher ID :{id}");
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                    Console.Write("Name :");
                    string name = Console.ReadLine();

                    Console.Write(" Designation :");
                    string desig = Console.ReadLine();

                    Console.Write(" Contact No :");
                    double contact = Convert.ToDouble(Console.ReadLine());

                    Console.Write(" Subject :");
                    string sub = Console.ReadLine();

                    Teachers teachers = new Teachers
                    {
                        teacherId = id,
                        teacherName = name,
                        Dsignation = desig,
                        ContactNumber = contact,
                        Subject = sub

                    };
                    _teachersRepo.Insert(teachers);
                    Console.WriteLine(" Data Update successfully!!!");
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                    OnlyDisplay();
                }
            }
            //Index 4 for delete data
            else if (display == 4)
            {
                Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                Console.Write(" Enter the Teacher ID to delete : ");
                int id = Convert.ToInt32(Console.ReadLine());
                var _teachers = _teachersRepo.GetId(id);
                if (_teachers == null)
                {
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                    Console.WriteLine(" The Teacher ID is invalid !!!!!");
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                    OnlyDisplay();
                    return;
                }
                else
                {
                    _teachersRepo.delete(id);
                    Console.WriteLine(" Data has been successfully deleted !!!");
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════");
                    OnlyDisplay();
                }
            }
        } 
    }
}
