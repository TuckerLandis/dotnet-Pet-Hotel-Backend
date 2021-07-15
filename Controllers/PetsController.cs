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
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.Pets
            .Include(pet => pet.petOwner)
            .ToList();
        }

        [HttpPost]
          public IActionResult Post([FromBody] Pet pet) {
              Console.WriteLine(pet);
            _context.Pets.Add(pet);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPets), pet);
        }


        [HttpPut("{id}/checkin")]
        public IActionResult checkIn([FromBody] int id) {
            Console.WriteLine(id);

            Pet petToUpdate = _context.Pets.Find(id);
            petToUpdate.checkedinAt = DateTime.Now;
            _context.Pets.Update(petToUpdate);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePet(int id){
            Pet petToRemove = _context.Pets.Find(id);
            if(petToRemove == null) return NotFound();
            _context.Pets.Remove(petToRemove);
            _context.SaveChanges();
            return NoContent();
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
