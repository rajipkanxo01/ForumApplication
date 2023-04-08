using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using HTTPClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HTTPClients.Implementations;

public class PostHttpClient : IPostService
{
    private HttpClient client;
    public string? Jwt { get; set; } = UserHttpClient.Jwt;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Jwt);
    }

    public async Task<Post?> CreateAsync(PostDto postDto)
    {
        
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/post/create", postDto);
        string? result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Post? post = JsonSerializer.Deserialize<Post>(result);
        return post;
    }

    public async Task<ICollection<Post>> GetPostsByForumId(int id)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/Post/{id}");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<Post> allPosts = JsonSerializer.Deserialize<ICollection<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return allPosts;
    }
}