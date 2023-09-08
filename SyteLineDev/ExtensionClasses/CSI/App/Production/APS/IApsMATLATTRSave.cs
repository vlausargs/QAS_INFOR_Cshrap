//PROJECT NAME: Production
//CLASS NAME: IApsMATLATTRSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMATLATTRSave
	{
		int? ApsMATLATTRSaveSp(int? InsertFlag,
		int? AltNo,
		string ATTID,
		string ATTVALUE,
		string MATERIALID);
	}
}

