using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge_Api.Models
{
  public class Article
  {
    public string author{get;set;}
    public string title { get; set; }
     public string description { get; set; }
    public string urlToImage { get; set; }
    public string content { get; set; }
    public DateTime publishedAt { get; set; }
    public Source source { get; set; }

  }
}
