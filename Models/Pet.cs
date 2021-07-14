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
        public string name {get; set;}

        [Required]
        public PetBreedType breed {get; set;}

        [Required]
        public string color {get; set;}

        public DateTime checkedinAt {get;set;}

        [ForeignKey("PetOwners")]
        public PetOwner petOwner {get; set;}
    }
}
