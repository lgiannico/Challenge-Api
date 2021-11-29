using Challenge_Api.Models;
using Challenge_Api.Requests;
using Challenge_Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Challenge_Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class NewsController : ControllerBase
  {

    private readonly ILogger<NewsController> _logger;
    private readonly NewsService _newsService;

    public NewsController(ILogger<NewsController> logger, NewsService newsService)
    {
      _logger = logger;
      _newsService = newsService;
    }

    [HttpGet]
    public async Task<NewaApiResponse> Get(SearchArticle request)
    {
      _logger.LogInformation("GetNewByCountry has been called");
      try
      {
        _logger.LogWarning($"Request Parameters  :{request} ");
        return await _newsService.GetNewByCountry(request);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        throw e;
      }
    }

    [HttpGet]
    [Route("GetByParams")]
    public async Task<NewaApiResponse> GetByParams(SearchArticle request )
    {
      _logger.LogInformation("GetNewByCountry has been called");
      try
      {
        _logger.LogWarning($"Request Parameters   :{request} ");
        return await _newsService.GetNewsByParams(request);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        throw e;
      }
    }
  }
}
