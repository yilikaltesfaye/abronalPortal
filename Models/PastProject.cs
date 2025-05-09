public class PastProject
{
    public string ProjectId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<string> Technologies { get; set; } = new List<string>();
    public string GithubUrl { get; set; } = string.Empty;
    public string LiveUrl { get; set; } = string.Empty;
    public List<string> Screenshots { get; set; } = new List<string>();
    public string Contribution { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
}
