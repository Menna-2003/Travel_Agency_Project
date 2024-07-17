using System.ComponentModel.DataAnnotations;

namespace Travel_Agency_Project.Utility {
    public class FutureDateAttribute : ValidationAttribute {

        protected override ValidationResult IsValid ( object value, ValidationContext validationContext ) {
            if ( value is DateTime dateValue ) {
                if ( dateValue > DateTime.Now ) {
                    return ValidationResult.Success;
                } else {
                    return new ValidationResult( ErrorMessage ?? "The date must be in the future." );
                }
            }
            return new ValidationResult( "Invalid date format." );
        }

    }
}
