//PROJECT NAME: Production
//CLASS NAME: IPP_CLM_LoadEstimateWorksheetData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_CLM_LoadEstimateWorksheetData
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) PP_CLM_LoadEstimateWorksheetDataSp(string CoNum,
		int? CoLine,
		decimal? CompQty2,
		decimal? CompQty3,
		decimal? CompQty4,
		decimal? CompQty5,
		string Infobar,
		string FilterString);
	}
}

