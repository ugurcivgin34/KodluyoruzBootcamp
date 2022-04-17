// See https://aka.ms/new-console-template for more information

using RestSharp;

var client = new RestClient("https://localhost:7216/api/Products");
client.Timeout = -1;
var request = new RestRequest(Method.GET);
request.AddHeader("Content-Type", "application/json");
var body = @"{
" + "\n" +
@"    ""name"": ""Product 1"",
" + "\n" +
@"        ""price"": 10
" + "\n" +
@"}";
request.AddParameter("application/json", body, ParameterType.RequestBody);
IRestResponse response = client.Execute(request);
Console.WriteLine(response.Content);