using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // all owners
        [HttpGet]
        public IEnumerable<PetOwner> GetAllOwners() {
            var petOwner = _context.PetOwners
            .Include(petOwner => petOwner.PetListForOwner)
            .OrderBy(pet => pet.id)
            .ToList();

            return petOwner;
        }
        

        //post
        [HttpPost]
        public IActionResult Post([FromBody] PetOwner petOwner) {
            _context.Add(petOwner);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllOwners), petOwner);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id){
            PetOwner ownerToDelete = _context.PetOwners.Find(id);
            if(ownerToDelete == null) return NotFound();
              
              _context.PetOwners.Remove(ownerToDelete);
              _context.SaveChanges();
              return NoContent();
               }
        
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]PetOwner newOwner, int id){
            if (id != newOwner.id) return BadRequest();

            if (!_context.PetOwners.Any(owner => owner.id == id)) return NotFound();

            // from brandon, this seems to set a specific entry to a new object?
            // ask dane how this is done
            _context.Entry(newOwner).State = EntityState.Modified;
            _context.SaveChanges();

            PetOwner updatedOwner = _context.PetOwners.Find(id);
            return Ok(updatedOwner);
            
        }

        // single owner
        [HttpGet("{id}")]
        public IActionResult GetOneOwner(int id){
            PetOwner oneOwner = _context.PetOwners.Find(id);
            return Ok(oneOwner);
        }



        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        // [HttpGet]
        // public IEnumerable<PetOwner> GetPets() {
        //     return new List<PetOwner>();
        // }
    }
}
