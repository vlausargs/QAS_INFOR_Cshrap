//PROJECT NAME: Logistics
//CLASS NAME: ICreateFixedAsset.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICreateFixedAsset
	{
		(int? ReturnCode, string Infobar) CreateFixedAssetSp(string FaNum,
		string FaClass,
		string Dept,
		string PoNum,
		string ManufacturerId,
		string Infobar,
		string FaDesc = null);
	}
}

