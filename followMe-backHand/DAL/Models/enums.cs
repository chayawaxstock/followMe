using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
  [Flags]
  public enum eKindMessage { email=2,sms,whatsApp}
  public enum WhenStatusOpen { onOpen, onDateBegin };

}
