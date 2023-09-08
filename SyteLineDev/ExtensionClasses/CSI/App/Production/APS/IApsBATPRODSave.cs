//PROJECT NAME: Production
//CLASS NAME: IApsBATPRODSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBATPRODSave
	{
		int? ApsBATPRODSaveSp(int? InsertFlag,
		int? AltNo,
		int? BATPRODID,
		string BATDEFID,
		DateTime? BATCHDATE,
		string PROCPLANID);
	}
}

