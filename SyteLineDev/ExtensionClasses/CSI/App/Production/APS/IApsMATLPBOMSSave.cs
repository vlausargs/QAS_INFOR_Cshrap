//PROJECT NAME: Production
//CLASS NAME: IApsMATLPBOMSSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMATLPBOMSSave
	{
		int? ApsMATLPBOMSSaveSp(int? InsertFlag,
		int? AltNo,
		string PBOMID,
		string MATERIALID);
	}
}

