using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using HTTPClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HTTPClients.Implementations;

public class PostHttpClient : IPostService
{
    public string? Jwt { get; set; }
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Post?> CreateAsync(CreatePostDto postDto)
    {
        LoadClientWithToken();

        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/post/create", postDto);
        Console.WriteLine(responseMessage.RequestMessage!.RequestUri);
        string? result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Post? post = JsonSerializer.Deserialize<Post>(result);
        return post;
    }

    public async Task<Post?> GetPostByIdAsync(int? postId)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/Post/viewpost/{postId}");
        string result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        ;

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result); 
        }

        Post? post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return post;
    }

    public async Task<ICollection<Post>> GetPostsByForumIdAsync(int id)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/Post/forum/{id}");
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
    
    private async void LoadClientWithToken()
    {
        Jwt = await UserHttpClient.GetJwtToken();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Jwt);
    }
}