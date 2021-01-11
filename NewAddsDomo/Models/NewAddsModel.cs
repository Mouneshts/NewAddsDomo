using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace NewAddsDomo.Models
{
    public class NewAddsModel
    {
        [Required(ErrorMessage = " Enter First Name"),
         Display(Name = "First Name"),
         StringLength(maximumLength: 10, MinimumLength = 2, ErrorMessage = "useername length Must be Max 10 & Min 2")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = " Enter Last Name"),
         Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = " Enter First Name"),
         EmailAddress,
         Display(Name = "Email Id")]
        public String Email { get; set; }


        [Required(ErrorMessage = " Enter Password"),
        Display(Name = "Password"),
        StringLength(maximumLength: 50, MinimumLength = 8, ErrorMessage = "Password min 8 and Max 50 "),
        DataType(DataType.Password, ErrorMessage = "Password Must Match")]
        public String Password { get; set; }

        [Required(ErrorMessage = " Enter Password"),
         Display(Name = "Confim Password"),
         StringLength(maximumLength: 50, MinimumLength = 8, ErrorMessage = "Password min 8 and Max 50 "),
         DataType(DataType.Password),
         Compare("Password")]
        public String ConfimPassword { get; set; }


        [Required(ErrorMessage = " Select the Gender")
        , Display(Name = "Gender")]
        public Char Gender { get; set; }


        [Required(ErrorMessage = " Enter Location"),
         Display(Name = "Location"),
        StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = " Enter valid PhoneNumber")]
        public String Location { get; set; }

        [Required(ErrorMessage = " Enter Phone Number"),
         Display(Name = "Phone Number"),
         StringLength(maximumLength: 13, MinimumLength = 10, ErrorMessage = " Enter valid PhoneNumber")]
        public int PhoneNumber { get; set; }


        [Required(ErrorMessage = "Upload Profile Image"),
         Display(Name = "Profile")]
        public int Rimg { get; set; }



    }


}