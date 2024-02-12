using HtmlGenerator.Model;
using Newtonsoft.Json.Linq;

namespace HtmlGenerator
{
    public class HtmlGenerator
    {
        public string CreateHtml(string template, string jsonData)
        {
            List<ProductItem>? productItems = LoadJson(jsonData) ?? throw new Exception("Couldn't read JSON template");
            var result = MatchDataWithPattern(template, productItems);
            return result;
        }

        private string MatchDataWithPattern(string pattern, List<ProductItem> productItems)
        {
            var patternList = pattern.Split("\r\n").ToList();
            var resultStr = patternList.Where(x => x.StartsWith("<ul")).FirstOrDefault() ?? "";

            var footerStr = patternList.Where(x => x.StartsWith("</ul")).FirstOrDefault();

            foreach (var item in productItems)
            {
                var tempList = patternList.GetRange(2, 6);
                for (int i = 0; i < tempList.Count - 1; i++)
                {
                    tempList[i] = tempList[i].Replace("{{product.name}}", item.Name);
                    tempList[i] = tempList[i].Replace("{{product.price | price }}", "$" + item.Price);
                    tempList[i] = tempList[i].Replace("{{product.description | paragraph }}", item.Description);
                }
                resultStr += Environment.NewLine + String.Join(Environment.NewLine, tempList);
            }

            resultStr += Environment.NewLine + footerStr;

            return resultStr;
        }

        private List<ProductItem>? LoadJson(string jsonData)
        {
            var productItems = JObject.Parse(jsonData).Value<JArray>("products").ToObject<List<ProductItem>>();
            return productItems;
        }


    }
}
