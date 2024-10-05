using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management.Main;
using Hospital_Management.Repository.Interface;
using Hospital_Management.Repository;
using Hospital_Managment.Util;

namespace Hospital_Management
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //IHospital hospitalRepo = new HospitalRepo();
            HospitalMgmtApp.Run();
        }
    }
}