using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge_Api.Requests
{
  public class SearchArticle
  {
    public string sinceDate { get; set; }
    public string toDate { get; set; }
    public string country { get; set; }
    public string keyword { get; set; }
  }
}
