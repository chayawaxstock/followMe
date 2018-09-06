using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualiAPI.Models
{
  public class DefinitionGroup
  {
    public WhenStatusOpen eWhenStatusOpen { get; set; }
    public double distance { get; set; }
    public GoogleStatus googleStatus { get; set; }

  }
}
