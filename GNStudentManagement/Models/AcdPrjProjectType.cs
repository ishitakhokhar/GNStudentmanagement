using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;

public partial class AcdPrjProjectType
{
    public int ProjectTypeId { get; set; }

    public string ProjectTypeName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<AcdPrjProjectGroup> AcdPrjProjectGroups { get; set; } = new List<AcdPrjProjectGroup>();
}
