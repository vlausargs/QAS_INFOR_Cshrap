//PROJECT NAME: Logistics
//CLASS NAME: IGetEftOutfileInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetEftOutfileInfo
	{
		(int? ReturnCode, string EFTDirectory,
		string EFTFile,
		DateTime? EFTDate) GetEftOutfileInfoSp(string EFTDirectory,
		string EFTFile,
		DateTime? EFTDate);
	}
}

