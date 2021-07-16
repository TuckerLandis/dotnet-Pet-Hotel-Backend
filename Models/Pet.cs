using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType {
        Sheperd,
        Poodle,
        Beagle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever
    }
    public enum PetColorType {
        White,
        Black,
        Golden,
        Tricolor,
        Spotted
    }
    public class Pet {
       
        [Required]
        public int id {get; set;}
       
        [Required]
        public string name {get; set;}
       
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType breed {get; set;}
      
        [Required]
        public string color {get; set;}
        public DateTime? checkedInAt {get; set;}

        [Required]
        [ForeignKey("PetOwners")] //s?
        public int petOwnerid {get; set;}

       
        public PetOwner petOwner {get; set;}

        public void checkInPet() {
            this.checkedInAt = DateTime.Now;
        }

        public void checkOutPet() {
            this.checkedInAt = null;
        }

    }
}
