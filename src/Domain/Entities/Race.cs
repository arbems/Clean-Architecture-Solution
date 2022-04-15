using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities;

public class Race : AuditableEntity
{
    public int Id { get; set; }
    public string? RaceName { get; set; }
}