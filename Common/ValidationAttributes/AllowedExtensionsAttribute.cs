using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Common.ValidationAttributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] extensions;

        public AllowedExtensionsAttribute(string[] Extensions)
        {
            this.extensions = Extensions;
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var files = value as List<IFormFile>;
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!(files == null))
                {
                    if (!this.extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult($"This image extension is not allowed!");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
