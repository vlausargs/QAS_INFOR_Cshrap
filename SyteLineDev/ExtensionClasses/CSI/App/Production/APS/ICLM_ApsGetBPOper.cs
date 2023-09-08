//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetBPOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetBPOper
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetBPOperSp(int? AltNo,
		string ORDERID,
		string BATID,
		string OperFilter = null);
	}
}

