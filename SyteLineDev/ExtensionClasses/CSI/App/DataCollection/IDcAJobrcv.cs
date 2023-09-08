//PROJECT NAME: DataCollection
//CLASS NAME: IDcAJobrcv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcAJobrcv
	{
		(int? ReturnCode, string Infobar) DcAJobrcvSp(string TermId,
		string EmpNum,
		DateTime? TTransDate,
		string JobNum,
		int? JobSuffix = 0,
		int? OperNum = null,
		decimal? TcQtuQty = null,
		string Location = null,
		string Lot = null,
		string DocumentNum = null,
		string Infobar = null);
	}
}

