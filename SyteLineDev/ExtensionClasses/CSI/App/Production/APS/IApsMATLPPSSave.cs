//PROJECT NAME: Production
//CLASS NAME: IApsMATLPPSSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMATLPPSSave
	{
		int? ApsMATLPPSSaveSp(int? InsertFlag,
		int? AltNo,
		string PROCPLANID,
		string MATERIALID);
	}
}

