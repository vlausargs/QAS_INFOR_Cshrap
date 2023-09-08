//PROJECT NAME: Logistics
//CLASS NAME: IFTSLGetProjectTaksMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetProjectTaksMatl
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTSLGetProjectTaksMatlSp(string ProjNum,
		int? TaskNum = 0,
		int? Seq = 0,
		string Item = "",
		int? OverIssue = 0);
	}
}

