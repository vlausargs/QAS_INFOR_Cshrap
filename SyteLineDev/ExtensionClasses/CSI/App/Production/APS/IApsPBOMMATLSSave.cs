//PROJECT NAME: Production
//CLASS NAME: IApsPBOMMATLSSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPBOMMATLSSave
	{
		int? ApsPBOMMATLSSaveSp(int? InsertFlag,
		int? AltNo,
		string BOMID,
		string MATERIALID,
		int? SEQNO,
		int? BOMFLAGS,
		decimal? QUANTITY,
		int? MERGETO,
		decimal? SHRINK,
		int? ALTID,
		string REFORDERID,
		DateTime? EFFDATE,
		DateTime? OBSDATE);
	}
}

