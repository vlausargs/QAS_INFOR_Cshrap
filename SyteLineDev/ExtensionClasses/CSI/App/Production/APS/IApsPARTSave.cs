//PROJECT NAME: Production
//CLASS NAME: IApsPARTSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPARTSave
	{
		int? ApsPARTSaveSp(int? InsertFlag,
		int? AltNo,
		string PARTID,
		string DESCR,
		string FAMILY,
		string PROCPLANID);
	}
}

