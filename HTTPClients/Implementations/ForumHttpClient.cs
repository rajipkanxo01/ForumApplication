using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using HTTPClients.ClientInterfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.DTOs;
using Shared.Models;


namespace HTTPClients.Implementations;

public class ForumHttpClient : IForumService
{
    private readonly HttpClient client;
    public string? Jwt { get; set; } = UserHttpClient.Jwt;


    public ForumHttpClient(HttpClient client)
    {
        this.client = client;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Jwt);
    }

    public async Task<Forum> CreateAsync(ForumDto dto)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/forum/create", dto);
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Forum? forum = JsonSerializer.Deserialize<Forum>(result);
        return forum;
    }
}