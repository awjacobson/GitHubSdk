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
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(productName, productVersion));
    }

    /// <summary>
    /// Lists milestones for a repository.
    /// </summary>
    /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
    /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
    /// <param name="state"></param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <remarks>
    /// https://docs.github.com/en/rest/issues/milestones?apiVersion=2022-11-28#list-milestones
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

    /// <summary>
    /// Closes a milestone using the given milestone number.
    /// </summary>
    /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
    /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
    /// <param name="milestoneNumber">The number that identifies the milestone.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns></returns>
    /// <remarks>
    /// https://docs.github.com/en/rest/issues/milestones?apiVersion=2022-11-28#update-a-milestone
    /// </remarks>
    public Task CloseMilestoneAsync(string owner, string repo, int milestoneNumber, CancellationToken cancellationToken = default)
    {
        var requestUri = "/repos"
            .AppendPathSegment(owner)
            .AppendPathSegment(repo)
            .AppendPathSegment("milestones")
            .AppendPathSegment(milestoneNumber);

        return _client.PatchAsync(requestUri, JsonContent.Create(new { state = "closed" }));
    }
}
