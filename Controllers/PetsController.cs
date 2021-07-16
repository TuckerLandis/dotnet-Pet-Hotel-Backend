using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets()
        {
            return _context.Pets
            .Include(pet => pet.petOwner)
            .ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pet petToAdd)
        {
            Console.WriteLine(petToAdd);
            // _context.Pets.Add(petToAdd);
            // _context.SaveChanges();

            PetOwner owner = _context.PetOwners
            .SingleOrDefault(owner => owner.id == petToAdd.petOwnerid);



            if (owner == null)
            {
                ModelState.AddModelError("petOwnerID", "invalid pet owner ID");
                return ValidationProblem(ModelState);
            }
           

            _context.Add(petToAdd);

            _context.SaveChanges();


            return CreatedAtAction(nameof(GetPets), petToAdd);
            // this needs to return a pet object with an owner object with a petcount to pass
            // test #11
        }


        [HttpPut("{id}/checkin")]
        public IActionResult CheckIn(int id)
        {

            Pet petToUpdate = _context.Pets.Find(id);
            petToUpdate.checkInPet();
            _context.Pets.Update(petToUpdate);
            _context.SaveChanges();

            return Ok(petToUpdate);
        }

        [HttpPut("{id}/checkout")]
        public IActionResult CheckOut(int id)
        {

            Pet petToUpdate = _context.Pets.Find(id);
            petToUpdate.checkOutPet();
            _context.Pets.Update(petToUpdate);
            _context.SaveChanges();

            return Ok(petToUpdate);
        }
        // get single pet
        [HttpGet("{id}")]
        public IActionResult GetSinglePet(int id)
        {
            Pet singlePet = _context.Pets.Find(id);


            return Ok(singlePet);
        }
        // delete a pet by ID
        [HttpDelete("{id}")]
        public IActionResult DeletePet(int id)
        {
            Pet petToRemove = _context.Pets.Find(id);
            if (petToRemove == null) return NotFound();
            _context.Pets.Remove(petToRemove);
            _context.SaveChanges();
            return NoContent();
        }
        // update a pet
        [HttpPut("{id}")]
        public IActionResult UpdatePet([FromBody] Pet newPet, int id)
        {
            if (id != newPet.id) return BadRequest();

            if (!_context.Pets.Any(pet => pet.id == id)) return NotFound();

            // from brandon, this seems to set a specific entry to a new object?
            // ask dane how this is done
            _context.Entry(newPet).State = EntityState.Modified;
            _context.SaveChanges();

            Pet updatedPet = _context.Pets.Find(id);
            return Ok(updatedPet);

        }



        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
