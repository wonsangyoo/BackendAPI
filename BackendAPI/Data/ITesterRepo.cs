using BackendAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Data
{
    public interface ITesterRepo
    {
        bool SaveChanges();
        IEnumerable<Test> GetAllTests();
        Test GetTestById(int id);
        void CreateTest(Test tst);
        void UpdateTest(Test tst);

        void DeleteTest(Test tst);
        IEnumerable<Test> GetTestsByProvince(string prov);
    }
}
