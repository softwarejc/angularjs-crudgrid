using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Utils.Web
{
    public abstract class BaseValidatableViewModel<TViewModel, TEntity> : BaseEntityMapperViewModel<TViewModel, TEntity>, IValidatableObject
        where TEntity : class 
        where TViewModel : class
    {
        /// <summary>
        /// Determines whether the mapped entity is valid.
        /// </summary>
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var modelErrors = new List<ValidationResult>();

            // Get the model to validate
            TEntity entity = this.MapToEntity();

            // Create a validation context with the model as instance
            var modelValidationContext = new ValidationContext(entity);

            // Validate
            Validator.TryValidateObject(entity, modelValidationContext, modelErrors, validateAllProperties: true);

            return modelErrors;
        }
    }
}