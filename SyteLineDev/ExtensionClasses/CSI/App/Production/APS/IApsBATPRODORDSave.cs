//PROJECT NAME: Production
//CLASS NAME: IApsBATPRODORDSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBATPRODORDSave
	{
		int? ApsBATPRODORDSaveSp(int? InsertFlag,
		int? AltNo,
		int? BATPRODID,
		string ORDERID,
		string JSID);
	}
}

