# GitHubSdk

GitHubSdk is a GitHub client for .NET

## Install GitHubSdk via Nuget
If you want to include GitHubSdk in your project, you can [install it directly from NuGet](https://www.nuget.org/packages/AWJ.GitHubSdk/)

To install GitHubSdk, run the following command in the Package Manager Console
```
PM> Install-Package AWJ.GitHubSdk
```

## Usage
```C#
var assembly = Assembly.GetExecutingAssembly();
var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

var githubClient = new GitHubClient(fvi.ProductName, fvi.ProductVersion, githubAccessToken);
var openMilestones = await githubClient.GetMilestoneListAsync(owner, repo, "open");
log.LogInformation("Open milestones returned from GitHub: {@openMilestones}", openMilestones);
```