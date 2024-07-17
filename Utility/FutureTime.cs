using System.ComponentModel.DataAnnotations;

namespace Travel_Agency_Project.Utility {
    public class FutureTime : ValidationAttribute {
        protected override ValidationResult IsValid ( object value, ValidationContext validationContext ) {
            if ( value is TimeSpan timeValue ) {
                if ( timeValue > DateTime.Now.TimeOfDay ) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult( ErrorMessage ?? "The time must be in the future." );
                }
            }
            return new ValidationResult( "Invalid time format." );
        }
    }
}
