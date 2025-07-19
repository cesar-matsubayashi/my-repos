namespace MyRepos.Domain.ReadmeAggreate
{
    public sealed class Readme
    {
        public string Content { get; private set; }
        public string Encoding { get; private set; }
        public string Sha { get; private set; }
        public string Url { get; private set; }
        public string DownloadUrl { get; private set; }

        private Readme(
            string content,
            string encoding,
            string sha,
            string url,
            string downloadUrl)
        {
            Content = content;
            Encoding = encoding;
            Sha = sha;
            Url = url;
            DownloadUrl = downloadUrl;
        }

        public static Readme Create(
            string content,
            string encoding,
            string sha,
            string url,
            string downloadUrl)
        {
            var readme = new Readme(
                content,
                encoding,
                sha,
                url,
                downloadUrl);

            return readme;
        }
    }
}