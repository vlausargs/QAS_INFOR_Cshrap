//PROJECT NAME: Production
//CLASS NAME: IApsORDATTRSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsORDATTRSave
	{
		int? ApsORDATTRSaveSp(int? InsertFlag,
		int? AltNo,
		string ATTID,
		string ATTVALUE,
		string ORDERID);
	}
}

