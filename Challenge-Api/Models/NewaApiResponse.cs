using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge_Api.Models
{
  public class NewaApiResponse
  {
    public string status { get; set; }
    public int totalResults { get; set; }
    public List<Article> articles { get; set; } = new List<Article>();
  }
}
