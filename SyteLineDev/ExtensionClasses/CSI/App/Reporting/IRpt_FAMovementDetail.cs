//PROJECT NAME: Reporting
//CLASS NAME: IRpt_FAMovementDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_FAMovementDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_FAMovementDetailSp(DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		string ClassCodeStarting = null,
		string ClassCodeEnding = null,
		string ExOptdfFaType = null,
		string ExOptdfFaStat = null,
		string AssetStarting = null,
		string AssetEnding = null,
		string VendorStarting = null,
		string VendorEnding = null,
		string LocationStarting = null,
		string LocationEnding = null,
		string DepartmentStarting = null,
		string DepartmentEnding = null,
		string SortBy = null,
		int? STransDateOffset = null,
		int? ETransDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

