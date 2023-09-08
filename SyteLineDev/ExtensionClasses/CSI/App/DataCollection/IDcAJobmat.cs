//PROJECT NAME: DataCollection
//CLASS NAME: IDcAJobmat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcAJobmat
	{
		(int? ReturnCode, string Infobar) DcAJobmatSp(string TermId,
		string EmpNum,
		DateTime? TTransDate,
		string TransType,
		string JobNum,
		int? JobSuffix = 0,
		int? OperNum = null,
		string Item = null,
		string UM = null,
		string CurWhse = null,
		decimal? TcQtuQty = null,
		string Location = null,
		string Lot = null,
		string Infobar = null);
	}
}

