using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.JoinEntities = new HashSet<RepairLicense>();
    }
    public int EngineerId { get; set; }
    public string EngineerName { get; set; }
    public virtual ICollection<RepairLicense> JoinEntities { get;}
  }
}