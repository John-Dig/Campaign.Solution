namespace Campaign.Models
{
  public class Mission
  {
    public int MissionId { get; set; }
    public string Description { get; set; }
    public int OperationId { get; set; }
    public Operation Operation { get; set; }
  }
}