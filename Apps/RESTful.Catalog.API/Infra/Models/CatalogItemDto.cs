using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RESTful.Catalog.API.Infra.Models
{
    public class CatalogItemDto : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUri { get; set; }
        public int CatalogTypeId { get; set; }     

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (Name.Length > 5)
            {
                errors.Add(new ValidationResult("Length of Name greater than 5"));
            }

            return errors;
        }
    }
}
