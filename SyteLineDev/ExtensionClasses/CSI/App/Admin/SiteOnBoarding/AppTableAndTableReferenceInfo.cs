using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSI.Admin.SiteOnBoarding
{
    public interface IAppTableAndTableReferenceInfo
    {
        List<(string TableName, string AppViewName, int ReferenceCount, string Referenced)> ConvertTableReferenceInfoToList(ICollectionLoadResponse collectionLoadResponse);
    }
    public class AppTableAndTableReferenceInfo : IAppTableAndTableReferenceInfo
    {

        public List<(string TableName, string AppViewName, int ReferenceCount, string Referenced)> ConvertTableReferenceInfoToList(ICollectionLoadResponse collectionLoadResponse)
        {
            if (collectionLoadResponse.Items.Count == 0) throw new Exception("Internal Error: Table AppTable is empty.");

            return collectionLoadResponse.Items.AsEnumerable()
                .Select(
                    record => (record.GetValue<string>(0), record.GetValue<string>(1),
                        record.GetValue<int>(2), record.GetValue<string>(3))).ToList();
        }
    }
}
