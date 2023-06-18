using System.Diagnostics;
using System.Text.Json.Serialization;

namespace GitHubSdk.Models;

[DebuggerDisplay("Title={Title}, State={State}")]
public record Milestone
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("state")]
    public string? State { get; init; }

    [JsonPropertyName("node_id")]
    public string? NodeId { get; init; }

    [JsonPropertyName("number")]
    public int Number { get; init; }

    [JsonPropertyName("open_issues")]
    public int OpenIssues { get; init; }

    [JsonPropertyName("closed_issues")]
    public int ClosedIssues { get; init; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; init; }

    [JsonPropertyName("closed_at")]
    public DateTime? ClosedAt { get; init; }

    [JsonPropertyName("due_on")]
    public DateTime? DueOn { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; init; }

    [JsonPropertyName("labels_url")]
    public string? LabelsUrl { get; init; }
}
