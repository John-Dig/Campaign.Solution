
using System.Collections.Generic;

namespace Campaign.Models
{
  public class Operation
  {
    public int OperationId { get; set; }
    public string Name { get; set; }
    public List<Mission> Missions { get; set; }
  }
} 