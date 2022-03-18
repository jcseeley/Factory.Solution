using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<RepairLicense>();
    }
    public int MachineId { get; set; }
    public string MachineName { get; set; }
    public virtual ICollection<RepairLicense> JoinEntities { get; set; }
  }
}