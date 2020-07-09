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
      var response = await client.GetProtectedAsync<PlansCollectionPagingResponse>($"{_baseUrl}/api/plans?query={query}&page={page}");
      return response.Result;
    }


  }
}