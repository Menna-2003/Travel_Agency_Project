using System.ComponentModel.DataAnnotations;
using Travel_Agency_Project.Models;

namespace Travel_Agency_Project.Utility {
    public class GroupNumberRestriction : ValidationAttribute{
        private readonly string _transportationTypeProperty;
        public GroupNumberRestriction( string transportationTypeProperty ) {
            _transportationTypeProperty = transportationTypeProperty;
        }
        protected override ValidationResult? IsValid ( Object value, ValidationContext validationContext ) {
            var groupNumber = ( int ) value;
            var transportationTypeProperty = validationContext.ObjectType.GetProperty( _transportationTypeProperty );
            var transportationType = ( string ) transportationTypeProperty.GetValue( validationContext.ObjectInstance );

            if ( transportationType == "Bike" ) {
                if ( groupNumber < 1 || groupNumber > 20 ) {
                    return new ValidationResult( "Group number for Bike must be between 1 and 20." );
                }
            } else if ( transportationType == "Car" ) {
                if ( groupNumber < 1 || groupNumber > 40 ) {
                    return new ValidationResult( "Group number for car must be between 1 and 40." );
                }
            } else if ( transportationType == "Bus" ) {
                if ( groupNumber < 40 || groupNumber > 500 ) {
                    return new ValidationResult( "Group number for car must be between 40 and 500." );
                }
            } else if ( transportationType == "Plane" ) {
                if ( groupNumber < 500 || groupNumber > 10000 ) {
                    return new ValidationResult( "Group number for car must be between 500 and 10,000." );
                }
            } else {
                return new ValidationResult( "Invalid transportation type." );
            }
            return ValidationResult.Success;
        }
    }
}
