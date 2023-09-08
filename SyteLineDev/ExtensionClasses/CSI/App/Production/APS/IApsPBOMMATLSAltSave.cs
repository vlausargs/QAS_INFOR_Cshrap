//PROJECT NAME: Production
//CLASS NAME: IApsPBOMMATLSAltSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPBOMMATLSAltSave
	{
		int? ApsPBOMMATLSAltSaveSp(int? InsertFlag,
		int? AltNo,
		string BOMID,
		int? ALTID,
		int? SEQNO,
		string MATERIALID,
		int? NEWSEQNO);
	}
}

