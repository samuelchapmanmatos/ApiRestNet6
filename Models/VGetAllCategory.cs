using System;
using System.Collections.Generic;

namespace ApiRestNet6.Models
{
    public partial class VGetAllCategory
    {
        public string ParentProductCategoryName { get; set; } = null!;
        public string? ProductCategoryName { get; set; }
        public int? ProductCategoryID { get; set; }
    }
}
