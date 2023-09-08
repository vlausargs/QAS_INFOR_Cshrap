//PROJECT NAME: Production
//CLASS NAME: IProjPercentComplete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjPercentComplete
	{
		(ICollectionLoadResponse Data, int? ReturnCode, decimal? CostToComplete) ProjPercentCompleteSp(string ProjNum,
		int? FromRpt = 0,
		string CostCodeType = "P",
		decimal? CostToComplete = null);
	}
}

