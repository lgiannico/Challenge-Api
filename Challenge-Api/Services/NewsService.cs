using Challenge_Api.Models;
using Challenge_Api.Requests;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Api.Services
{
  public class NewsService
  {
    private string _newsApiUrl;
    private string _apikey;
    protected Configuration _config;
    public NewsService()
    {
      _newsApiUrl = Environment.GetEnvironmentVariable("urlNewsApi");
      _apikey = Environment.GetEnvironmentVariable("newsApiKey");
    }

    public async Task<NewaApiResponse> GetNewByCountry(SearchArticle req)
    {
      string country = req.country == null || req.country == "" ? country = "ar" : country = req.country;
      string url = _newsApiUrl + "top-headlines?" +"country=" + req.country;
    
      return await SendRequest(url);
    }

    public async Task<NewaApiResponse> GetNewsByParams(SearchArticle req)
    {
      string country = req.country == null || req.country == "" ? country = "ar" : country = req.country;
      //string q = req.keyword == null || req.keyword == "" ? q = "ar" : q = req.country;
      string url = _newsApiUrl
        + "everything?"
        
        + "dateFrom=" + req.sinceDate
        + "&dateTo=" +   req.toDate
        //+ "country=" + req.country
        + "&sortBy=relevancy";
      string containKey = req.keyword == null || req.keyword == "" ? "" : (url=url+ "&qInTitle=" + req.keyword);

      return await SendRequest(url);
    }

    public async Task<NewaApiResponse> SendRequest(string url)
    {
      string response;
      using (var client = new WebClient())
      {
        client.Headers.Add("content-type", "application/json");
        client.Headers.Add("x-api-key", _apikey);
        response = await client.DownloadStringTaskAsync(url);
      }
      return JsonConvert.DeserializeObject<NewaApiResponse>(response);

    }
  }
}
