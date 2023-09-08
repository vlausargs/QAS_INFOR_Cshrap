using CSI.Data.CRUD;
using System.Collections.Generic;


namespace CSI.Data
{
    public interface ICollectionLoadResponseUtil
    {
        ICollectionLoadResponse ExtractRequiredColumns(ICollectionLoadResponse collectionLoadResponse, List<string> requiredColumns);
        ICollectionLoadResponse CloneCollectionRenameColumns(ICollectionLoadResponse collectionLoadResponse, List<string> newColumns);
        ICollectionLoadResponse Merge(ICollectionLoadResponse collectionLoadResponse1, ICollectionLoadResponse collectionLoadResponse2, bool distinct = false, string orderBy = "");
    }
}