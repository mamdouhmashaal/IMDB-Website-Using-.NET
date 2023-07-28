using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Allmodel : DbContext
    {
        public Allmodel() : base("Team")
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public DbSet<Directors> Directors { get; set; }
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "the string length must be 50")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "the string length must be 50")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Profile Image")]
        public string ProfileImage { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Movie
    {
        [Key]
        [ForeignKey("User")]
        public int MovieId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "the string length must be 50")]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Movie Image")]
        public string MovieImage { get; set; }

        public string MovieActors { get; set; }
        public string MovieDirectors { get; set; }


        public virtual User User { get; set; }
       
    }

    public class Actors
    {
        [Key]
        [ForeignKey("User")]
        public int ActorId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "the string length must be 50")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "the string length must be 50")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }
        public string ParticipatedMovies { get; set; }


        public virtual User User { get; set; }
    }

    public class Directors
    {
        [Key]
        [ForeignKey("User")]
        public int DirectorId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "the string length must be 50")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "the string length must be 50")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ProducedMovies { get; set; }
        

        public virtual User User { get; set; }
    }
}