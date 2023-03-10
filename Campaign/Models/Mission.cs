namespace Campaign.Models
{
  public class Mission
  {
    public int MissionId { get; set; }
    public string Name { get; set; }
    public int OperationId { get; set; }
    public Operation Operation { get; set; }
  }
}