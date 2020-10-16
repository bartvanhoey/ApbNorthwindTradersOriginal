using System;
using System.ComponentModel;
namespace AbpNorthwindTraders.Domain.Dtos
{
    [Serializable]
    public class CreateUpdateCategoryDto
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

    }
}