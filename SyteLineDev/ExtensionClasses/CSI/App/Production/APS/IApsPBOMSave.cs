//PROJECT NAME: Production
//CLASS NAME: IApsPBOMSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPBOMSave
	{
		int? ApsPBOMSaveSp(int? InsertFlag,
		int? AltNo,
		string BOMID,
		string DESCR,
		string EFFECTID);
	}
}

