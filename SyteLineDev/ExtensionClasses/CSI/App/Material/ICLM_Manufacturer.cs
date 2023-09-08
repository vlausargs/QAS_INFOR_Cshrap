//PROJECT NAME: Material
//CLASS NAME: ICLM_Manufacturer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_Manufacturer
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_ManufacturerSp(string Item,
		string RefType,
		string RefNum,
		string Infobar,
		string SiteRef = null,
		string Manufacturer = null);
	}
}

