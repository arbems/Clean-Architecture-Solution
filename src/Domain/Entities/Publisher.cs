using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities;

public class Publisher : AuditableEntity
{
    public int Id { get; set; }
    public string? PublisherName { get; set; }
}