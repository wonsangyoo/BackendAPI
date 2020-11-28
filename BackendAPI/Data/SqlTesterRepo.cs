using BackendAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Data
{
    public class SqlTesterRepo : ITesterRepo
    {
        private readonly TesterContext _context;

        public SqlTesterRepo(TesterContext context)
        {
            _context = context;
        }

        public void CreateTest(Test tst)
        {
            if(tst == null)
            {
                throw new ArgumentNullException(nameof(tst));
            }

            _context.Tests.Add(tst);
        }

        public void DeleteTest(Test tst)
        {
            if (tst == null)
            {
                throw new ArgumentNullException(nameof(tst));
            }
            _context.Tests.Remove(tst);

        }

        public IEnumerable<Test> GetAllTests()
        {
            return _context.Tests.ToList();
        }

        public IEnumerable<Test> GetTestsByProvince(string prov)
        {
            var queryableList = _context.Tests.AsQueryable();
            queryableList = queryableList.Where(t => t.Province == prov);
            //IQueryable<Test> provinceList = _context.Tests.ToList().AsQueryable();
            //provinceList = provinceList.Where(o => o.Province.Equals(prov));
            //Console.WriteLine(queryableList);
            return queryableList.AsEnumerable();
        }

        public Test GetTestById(int id)
        {
            return _context.Tests.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTest(Test tst)
        {
            //Nothing
        }

       
    }
}
