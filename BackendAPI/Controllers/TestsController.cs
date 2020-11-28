using AutoMapper;
using BackendAPI.Data;
using BackendAPI.Dtos;
using BackendAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Controllers
{
    //api/tests
    [Route("api/tests")]
    [ApiController]
    public class TestsController: ControllerBase
    {
        //private readonly MockTesterRepo _repository = new MockTesterRepo();
        private readonly ITesterRepo _repository;
        public IMapper _mapper { get; }

        //Dependency Injection
        public TestsController(ITesterRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        
        //GET api/tests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestReadDto>>> GetAllTestsAsync()
        {
            var testItems = _repository.GetAllTests();
            return await Task.FromResult(Ok(_mapper.Map<IEnumerable<TestReadDto>>(testItems)));
        }   

        //GET api/tests/{id}
        [HttpGet("{id}", Name = "GetTestById")]
        public async Task<ActionResult<TestReadDto>> GetTestByIdAsync(int id)
        {
            var testItem = _repository.GetTestById(id);
            if (testItem != null)
            {
                return await Task.FromResult(Ok(_mapper.Map<TestReadDto>(testItem)));
            }
            return NotFound();
        }       

        //GET api/tests/province/{prov}
        [HttpGet("province/{prov}", Name = "FindByProvince")]
        public async Task<ActionResult<IEnumerable<TestReadDto>>> FindByProvinceAsync(string prov)
        {
            //var testItems = _repository.GetAllTests().AsQueryable();
            var provinceTests = _repository.GetTestsByProvince(prov);
            return await Task.FromResult(Ok(_mapper.Map<IEnumerable<TestReadDto>>(provinceTests)));
        }

        //POST api/tests
        [HttpPost]
        public async Task<ActionResult<TestReadDto>> CreateTestAsync(TestCreateDto testCreateDto)
        {
            var testModel = _mapper.Map<Test>(testCreateDto);
            _repository.CreateTest(testModel);
            _repository.SaveChanges();

            var testReadDto = _mapper.Map<TestReadDto>(testModel);

            // to make successful create return 201
            //return await Task.FromResult(CreatedAtRoute(nameof(GetTestByIdAsync), new { Id = testReadDto.Id }, testReadDto));

            //this returns 200
            return await Task.FromResult(Ok(testReadDto));
        }

        //PUT api/tests/{id}
        //PUT request requires the whole attributes of an object
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTestAsync(int id, TestUpdateDto testUpdateDto)
        {
            var testModelFromRepo = _repository.GetTestById(id);
            if (testModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(testUpdateDto, testModelFromRepo);

            _repository.UpdateTest(testModelFromRepo);

            _repository.SaveChanges();

            return await Task.FromResult(NoContent()); // 204 No Content
        }
      
        // DELETE api/tests/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTestAsync(int id)
        {
            var testModelFromRepo = _repository.GetTestById(id);
            if (testModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteTest(testModelFromRepo);
            _repository.SaveChanges();

            return await Task.FromResult(NoContent());
        }

        

        //GET api/tests]
        /*
        [HttpGet]
        public ActionResult<IEnumerable<TestReadDto>> GetAllTests()
        {
            var testItems = _repository.GetAllTests();
            return Ok(_mapper.Map<IEnumerable<TestReadDto>>(testItems));
        }
        */

        //GET api/tests/{id}
        /*
        [HttpGet("{id}", Name = "GetTestById")]
        public ActionResult<TestReadDto> GetTestById(int id)
        {
            var testItem = _repository.GetTestById(id);
            if (testItem != null)
            {
                return Ok(_mapper.Map<TestReadDto>(testItem));
            }
            return NotFound();
        }
        */

        //GET api/tests/province/{prov}
        /*
        [HttpGet("province/{prov}", Name = "FindByProvince")]
        public ActionResult<IEnumerable<TestReadDto>> FindByProvince(string prov)
        {
            //var testItems = _repository.GetAllTests().AsQueryable();
            var provinceTests = _repository.GetTestsByProvince(prov);
            return Ok(_mapper.Map<IEnumerable<TestReadDto>>(provinceTests));
        }
        */

        //POST api/tests
        /*
        [HttpPost]
        public ActionResult<TestReadDto> CreateTest(TestCreateDto testCreateDto)
        {
            var testModel = _mapper.Map<Test>(testCreateDto);
            _repository.CreateTest(testModel);
            _repository.SaveChanges();

            var testReadDto = _mapper.Map<TestReadDto>(testModel);

            // to make successful create return 201
            return CreatedAtRoute(nameof(GetTestById), new { Id = testReadDto.Id }, testReadDto);
            
            //this returns 200
            //return Ok(testReadDto);
        }
        */

        //PUT api/tests/{id}
        //PUT request requires the whole attributes of an object
        //inefficient, error prone -> PATCH is preferred
        /*
        [HttpPut("{id}")]
        public ActionResult UpdateTest(int id, TestUpdateDto testUpdateDto)
        {
            var testModelFromRepo = _repository.GetTestById(id);
            if(testModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(testUpdateDto, testModelFromRepo);

            _repository.UpdateTest(testModelFromRepo);

            _repository.SaveChanges();

            return NoContent(); // 204 No Content
        }
        */

        //JSON PATCH supports 6 operations: Add, Remove, Replace, Copy, Move, Test
        //PATCH api/tests/{id}
        //We are using PUT instead of PATCH in front-end Angular app.
        /*
        [HttpPatch("{id}")]
        public ActionResult PartialTestUpdate(int id, JsonPatchDocument<TestUpdateDto> patchDoc)
        {
            var testModelFromRepo = _repository.GetTestById(id);
            if (testModelFromRepo == null)
            {
                return NotFound();
            }

            var testToPatch = _mapper.Map<TestUpdateDto>(testModelFromRepo);
            patchDoc.ApplyTo(testToPatch, ModelState);
            if(!TryValidateModel(testToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(testToPatch, testModelFromRepo);
            _repository.UpdateTest(testModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
        */

        // DELETE api/tests/{id}
        /*
        [HttpDelete("{id}")]
        public ActionResult DeleteTest(int id)
        {
            var testModelFromRepo = _repository.GetTestById(id);
            if (testModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteTest(testModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
        */
    }
}
