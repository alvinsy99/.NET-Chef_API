using System.Collections.Generic;
using AutoMapper;
using ChefAPI.Data;
using ChefAPI.Details;
using ChefAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ChefAPI.Controllers
{
    [ApiController]
    // [controller] -> use the exact controller class name
    //[Route("api/[controller]")]


    // define a route name even if the controller class changes
    [Route("api/chef")]
    public class ChefController : ControllerBase
    {

        // dependency injection
        private readonly I_Chef _repository;
        private readonly IMapper _mapper;

        public ChefController(I_Chef repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET Request
        // api/chef
        [HttpGet]
        public ActionResult <IEnumerable<Chef_Details>> GetAllChefs()
        {
            var allChefs = _repository.GetAllChefs();

            // mapping from allChef, which is list of chefs to Chef_Details model
            return Ok(_mapper.Map<IEnumerable<Chef_Details>>(allChefs));
            
        }


        // GET Request
        // api/chef/{id}
        [HttpGet("{id}", Name= "GetChefById")]
        public ActionResult <Chef_Details> GetChefById(int id)
        {
            // retrieve chef model from db based on id
            var chef = _repository.GetChefById(id);
            if (chef != null)
            {
                return Ok(_mapper.Map<Chef_Details>(chef));
            }

            return NotFound();
        }


        //POST
        // api/chef
        [HttpPost]
        public ActionResult <Chef_Details> AddChef(ChefCreate_Details chefcreate_details)
        {
            var chefModel = _mapper.Map<Chef>(chefcreate_details);

            _repository.AddChef(chefModel);
            _repository.SaveChanges();

            var chef_details = _mapper.Map<Chef_Details>(chefModel);

            return CreatedAtRoute(nameof(GetChefById), new { Id = chef_details.Id }, chef_details);

            //return Ok(chef_details);
        }


        //PUT
        // api/chef
        [HttpPut("{id}")]
        public ActionResult UpdateChef(int id, ChefUpdate_Details chefUpdate)
        {
            // retrieve chef model from db based on id
            var chefFromRepo = _repository.GetChefById(id);
            if (chefFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(chefUpdate, chefFromRepo);
            _repository.UpdateChef(chefFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }


        // PATCH
        // api/chef/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialChefUpdate(int id, JsonPatchDocument<ChefUpdate_Details> chefPartialUpdate)
        {
            var chefFromRepo = _repository.GetChefById(id);
            if (chefFromRepo == null)
            {
                return NotFound();
            }

            var chefToPatch = _mapper.Map<ChefUpdate_Details>(chefFromRepo);
            chefPartialUpdate.ApplyTo(chefToPatch, ModelState);

            if(!TryValidateModel(chefToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(chefToPatch, chefFromRepo);
            _repository.UpdateChef(chefFromRepo);
            _repository.SaveChanges();
        }
    }

    
}