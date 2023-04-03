using HTTPClients.ClientInterfaces;
using System.Net.Http.Json;
using System.Text.Json;
using Shared.DTOs;
using Shared.Models;

namespace HTTPClients.Implementations;

public class UserHTTPClient : IUserService
{
    private readonly HttpClient client;

    public UserHTTPClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<User> CreateAsync(UserDto userDto)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/user", userDto);

        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User? user = JsonSerializer.Deserialize<User>(result);
        return user;
    }

    public async Task<UserDto> GetUserByUsernameAsync(string username)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/user/{username}");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        UserDto user = JsonSerializer.Deserialize<UserDto>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }
}