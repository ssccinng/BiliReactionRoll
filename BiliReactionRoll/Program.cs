using BiliReactionRoll;
using System.Collections.Immutable;
using System.Net.Http.Json;

var client = new HttpClient();
var cookie = Environment.GetEnvironmentVariable("BILI_COOKIE");
if (!string.IsNullOrEmpty(cookie))
{
    client.DefaultRequestHeaders.Add("Cookie", cookie);
}
else
{
    Console.WriteLine("Cookie 未设置，请设置环境变量 BILI_COOKIE");
    return;
}

string requestUri = "https://api.bilibili.com/x/polymer/web-dynamic/v1/detail/reaction?id=1040052976726573072&offset={0}&web_location=333.1369";

var data = (await GetData("")).ToArray();

Console.WriteLine("获取数据完成");
Console.WriteLine("数据如下：");
System.Console.WriteLine(string.Join(", ", data));

var result = Random.Shared.GetItems(data, 5);

Console.WriteLine("随机抽取结果如下：");
foreach (var item in result)
{
    Console.WriteLine(item);
}



async Task<ImmutableArray<string>> GetData(string offset)
{
    var response = await client.GetAsync(string.Format(requestUri, offset));
    response.EnsureSuccessStatusCode();
    var data = await response.Content.ReadFromJsonAsync<BData>();
    var names = data.data.items.Where(s => s.action == "赞了").Select(s => s.name);
    if (!data.data.has_more)
    {
        return [.. names];
    }
    else
    {
        return [.. names, .. await GetData(data.data.offset)];
    }
}
