using CSI.Data.CRUD;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace CSI.Admin.SiteOnBoarding
{
    public interface ICollectionToListConvertor
    {
        List<Dictionary<string, string>> ConvertCollectionLoadResponseToList(ICollectionLoadResponse responseData, Dictionary<string, string> tableColumns);
    }

    public class CollectionToListConvertor : ICollectionToListConvertor
    {

        public List<Dictionary<string, string>> ConvertCollectionLoadResponseToList(ICollectionLoadResponse responseData, Dictionary<string, string> tableColumns)
        {
            return responseData.Items.AsEnumerable().Select(
                x =>
                {
                    var dictionary = new Dictionary<string, string>();
                    foreach (var column in tableColumns)
                    {
                        var value = x.GetValue(column.Key);
                        var key = XmlConvert.EncodeName(column.Key) ?? string.Empty;
                        if (!dictionary.ContainsKey(key))
                            dictionary.Add(key, value.ToString());
                    }
                    return dictionary;
                }
            ).ToList();
        }
    }
}