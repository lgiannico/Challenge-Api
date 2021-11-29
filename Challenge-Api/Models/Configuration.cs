using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge_Api.Models
{
  public class Configuration
  {
    public string GetEnvironment(string url)
    {
      return Environment.GetEnvironmentVariable(url);
    }

    public string GetApiKey(string api)
    {
      return Environment.GetEnvironmentVariable(api);
    }

  }
}
