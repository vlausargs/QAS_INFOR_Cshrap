//PROJECT NAME: Material
//CLASS NAME: IDeleteItemsOfSpecifiedCategories.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface IDeleteItemsOfSpecifiedCategories
    {
        int? DeleteItemsOfSpecifiedCategoriesSp(
            string ItemCategory);
    }
}

