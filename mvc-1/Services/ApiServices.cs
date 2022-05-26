namespace Services
{
    public class ApiServices
    {
        public string Url { get; set; }
        public HttpClient Client { get; set; }

        public ApiServices(string endUrl, string token)
        {
            //var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //this.Url = config["UrlString:DefaultUrlString"] + endUrl;
            this.Url = "http://localhost:5145/" + endUrl;
            this.Client = new HttpClient();
            this.Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            this.Client.BaseAddress = new Uri(this.Url);
        }
        
        public ApiServices(string endUrl)
        {
            // var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            // this.Url = config["http://localhost:5145/"] + endUrl;
            this.Url = "http://localhost:5145/" + endUrl;
            this.Client = new HttpClient();
            this.Client.BaseAddress = new Uri(this.Url);
        }

        public ApiServices()
        {
            //var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //this.Url = config["UrlString:DefaultUrlString"] + endUrl;
            this.Url = "http://localhost:5145/";
            this.Client = new HttpClient();
            this.Client.BaseAddress = new Uri(this.Url);
        }

        public void Close()
        {
            this.Client.Dispose();
        }
    }
}
