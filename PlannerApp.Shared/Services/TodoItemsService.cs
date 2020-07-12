using System.Collections.Generic;
using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using PlannerApp.Shared.Models;

namespace PlannerApp.Shared.Services
{
  public class TodoItemsService
  {
    private readonly string _baseUrl;

    ServiceClient client = new ServiceClient();

    public TodoItemsService(string baseUrl)
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

    public async Task<TodoItemSingleResponse> PostTodoItemAsync(TodoItemRequest request)
    {
      var response = await client.PostProtectedAsync<TodoItemSingleResponse>($"{_baseUrl}/api/todoitems", request);
      return response.Result;
    }

    public async Task<TodoItemSingleResponse> EditTodoItemAsync(TodoItemRequest request)
    {
      var response = await client.PutProtectedAsync<TodoItemSingleResponse>($"{_baseUrl}/api/todoitems", request);
      return response.Result;
    }


    public async Task<TodoItemSingleResponse> ChangeTodoItemStatusAsync(string id)
    {
      var response = await client.PutProtectedAsync<TodoItemSingleResponse>($"{_baseUrl}/api/todoitems/{id}", null);
      return response.Result;
    }

    public async Task<TodoItemSingleResponse> DeleteTodoItemStatusAsync(string id)
    {
      var response = await client.DeleteProtectedAsync<TodoItemSingleResponse>($"{_baseUrl}/api/todoitems/{id}");
      return response.Result;
    }

  }
}