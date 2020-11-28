using AutoMapper;
using BackendAPI.Dtos;
using BackendAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Profiles
{
    public class TestsProfile: Profile
    {
        public TestsProfile()
        {
            //Source -> Target
            CreateMap<Test, TestReadDto>();
            CreateMap<TestCreateDto, Test>();
            CreateMap<TestUpdateDto, Test>();
            CreateMap<Test, TestUpdateDto>();

        }
    }
}
