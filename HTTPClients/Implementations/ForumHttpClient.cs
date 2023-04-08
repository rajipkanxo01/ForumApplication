using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using HTTPClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;


namespace HTTPClients.Implementations;

public class ForumHttpClient : IForumService
{
    public string? Jwt { get; set; }
    private readonly HttpClient client;

    public ForumHttpClient(HttpClient client)
    {
        this.client = client;
    }
    

    public async Task<Forum?> CreateAsync(ForumDto dto)
    {
        LoadClientWithToken();
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/forum/create", dto);
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Forum? forum = JsonSerializer.Deserialize<Forum>(result,new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return forum;
    }

    public async Task<ICollection<Forum>> GetAsync()
    {
        HttpResponseMessage responseMessage = await client.GetAsync("/Forum");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<Forum> forum = JsonSerializer.Deserialize<ICollection<Forum>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return forum;
    }

    public async Task<Forum> GetForumById(int id)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/Forum/{id}");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Forum forum = JsonSerializer.Deserialize<Forum>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return forum;
    }
    
    private async void LoadClientWithToken()
    {
        Jwt = await UserHttpClient.GetJwtToken();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Jwt);
    }
}