using BackendAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Data
{
    public class MockTesterRepo : ITesterRepo
    {
        public void CreateTest(Test tst)
        {
            tst = new Test
            {
                Id = 0,
                FirstName = "Wonsang",
                LastName = "Yoo",
                Email = "akarws@gmail.com",
                Age = 33,
                Gender = "Male",
                Address = "29 Lavron Crt",
                City = "Markham",
                Province = "ON",
                Result = "Negative",
                TestDate = DateTime.Now,
            };
        }

        public void DeleteTest(Test tst)
        {
            tst = null;
        }

        public IEnumerable<Test> GetAllTests()
        {
            var Tests = new List<Test>
            {
                new Test
                {
                Id = 0,
                FirstName = "Wonsang",
                LastName = "Yoo",
                Email = "akarws@gmail.com",
                Age = 33,
                Gender = "Male",
                Address = "29 Lavron Crt",
                City = "Markham",
                Province = "ON",
                Result = "Negative",
                TestDate = DateTime.Now,
                },
                new Test
                {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@hotmail.com",
                Age = 45,
                Gender = "Male",
                Address = "30 Forbes Cres",
                City = "Markham",
                Province = "ON",
                Result = "Positive",
                TestDate = DateTime.Now,
                },
                new Test
                {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "janedoe@yahoo.com",
                Age = 23,
                Gender = "Female",
                Address = "30 Forbes Cres",
                City = "Markham",
                Province = "ON",
                Result = "Positive",
                TestDate = DateTime.Now,
                }
            };
            return Tests;
        }

        public Test GetTestById(int id)
        {
            return new Test
            {
                Id = 0,
                FirstName = "Wonsang",
                LastName = "Yoo",              
                Age = 33,
                Gender = "Male",
                Address = "29 Lavron Crt",
                City = "Markham",
                Province = "ON",
                Result = "Negative",
                TestDate = DateTime.Now,         
            };
        }

        public Test GetTestsByProvince(string prov)
        {
            return new Test
            {
                Id = 0,
                FirstName = "Wonsang",
                LastName = "Yoo",
                Age = 33,
                Gender = "Male",
                Address = "29 Lavron Crt",
                City = "Markham",
                Province = "ON",
                Result = "Negative",
                TestDate = DateTime.Now,
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateTest(Test tst)
        {
            tst =  new Test
            {
                Id = 0,
                FirstName = "Wonsang",
                LastName = "Yoo",
                Age = 33,
                Gender = "Male",
                Address = "29 Lavron Crt",
                City = "Markham",
                Province = "ON",
                Result = "Negative",
                TestDate = DateTime.Now,
            };
        }

        IEnumerable<Test> ITesterRepo.GetTestsByProvince(string prov)
        {
            var Tests = new List<Test>
            {
                new Test
                {
                Id = 0,
                FirstName = "Wonsang",
                LastName = "Yoo",
                Email = "akarws@gmail.com",
                Age = 33,
                Gender = "Male",
                Address = "29 Lavron Crt",
                City = "Markham",
                Province = "ON",
                Result = "Negative",
                TestDate = DateTime.Now,
                },
                new Test
                {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@hotmail.com",
                Age = 45,
                Gender = "Male",
                Address = "30 Forbes Cres",
                City = "Markham",
                Province = "ON",
                Result = "Positive",
                TestDate = DateTime.Now,
                },
                new Test
                {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "janedoe@yahoo.com",
                Age = 23,
                Gender = "Female",
                Address = "30 Forbes Cres",
                City = "Markham",
                Province = "ON",
                Result = "Positive",
                TestDate = DateTime.Now,
                }
            };
            return Tests;
        }
    }
}
