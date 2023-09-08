//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConsoleLoadTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSConsoleLoadTrans
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSConsoleLoadTransSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string PlanAct,
		string SiteRef = null,
		string FilterString = null);
	}
}

