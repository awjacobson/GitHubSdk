using Flurl;
using GitHubSdk.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace GitHubSdk;

/// <summary>
/// https://docs.github.com/en/rest/guides/getting-started-with-the-rest-api?apiVersion=2022-11-28
/// </summary>
public class GitHubClient
{
    private readonly HttpClient _client;
    private readonly string _baseUrl = "https://api.github.com";

    public GitHubClient(string productName, string productVersion, string accessToken)
    {
        _client = new() { BaseAddress = new(_baseUrl) };
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productName, productVersion));
    }

    /// <summary>
    /// Lists milestones for a repository.
    /// </summary>
    /// <remarks>
    /// https://docs.github.com/en/rest/issues/milestones?apiVersion=2022-11-28
    /// </remarks>
    public Task<List<Milestone>?> GetMilestoneListAsync(string owner, string repo, string state = "all", CancellationToken cancellationToken = default)
    {
        var requestUri = "/repos"
            .AppendPathSegment(owner)
            .AppendPathSegment(repo)
            .AppendPathSegment("milestones")
            .SetQueryParam("state", state);

        return _client.GetFromJsonAsync<List<Milestone>>(requestUri, cancellationToken);
    }
}
