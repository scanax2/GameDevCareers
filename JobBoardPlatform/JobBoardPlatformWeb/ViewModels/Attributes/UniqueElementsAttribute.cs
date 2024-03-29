﻿using System.ComponentModel.DataAnnotations;

namespace JobBoardPlatform.PL.ViewModels.Attributes
{
    public class UniqueElementsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            object[] array = value as object[];

            if (array == null)
            {
                return true; // Return true for non-array values
            }

            // Check for duplicate elements in the array
            return array.Distinct().Count() == array.Length;
        }
    }
}
