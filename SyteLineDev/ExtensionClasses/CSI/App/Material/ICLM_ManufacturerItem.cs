//PROJECT NAME: Material
//CLASS NAME: ICLM_ManufacturerItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_ManufacturerItem
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_ManufacturerItemSp(string Item,
		string Manufacturer,
		string RefType,
		string RefNum,
		string Infobar,
		string SiteRef = null,
		string ManufacturerItem = null);
	}
}

