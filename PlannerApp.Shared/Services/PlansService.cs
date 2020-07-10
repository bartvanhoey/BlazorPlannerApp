using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using PlannerApp.Shared.Models;

namespace PlannerApp.Shared.Services
{
  public class PlansService
  {
    private readonly string _baseUrl;

    ServiceClient client = new ServiceClient();

    public PlansService(string baseUrl)
    {
      _baseUrl = baseUrl;
    }

    public string AccessToken
    {
      get => client.AccessToken;
      set
      {
        client.AccessToken = value;
      }
    }

    public async Task<PlansCollectionPagingResponse> GetAllPlansByPage(int page = 1)
    {
      var response = await client.GetProtectedAsync<PlansCollectionPagingResponse>($"{_baseUrl}/api/plans?page={page}");
      return response.Result;
    }

    public async Task<PlansCollectionPagingResponse> SearchPlansByPage(string query, int page = 1)
    {
      var response = await client.GetProtectedAsync<PlansCollectionPagingResponse>($"{_baseUrl}/api/plans/search?query={query}&page={page}");
      return response.Result;
    }

    public async Task<PlanSingleResponse> PostPlanAsync(PlanRequest request)
    {
      var response = await client.SendFormProtectedAsync<PlanSingleResponse>($"{_baseUrl}/api/plans", ActionType.POST,
        new StringFormKeyValue("Title", request.Title), new StringFormKeyValue("Description", request.Description), 
        new FileFormKeyValue("CoverFile", request.CoverFile, request.FileName));
     
      return response.Result;
    }


  }
}