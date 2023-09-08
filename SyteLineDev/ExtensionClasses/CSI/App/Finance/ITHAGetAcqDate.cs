//PROJECT NAME: Finance
//CLASS NAME: ITHAGetAcqDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITHAGetAcqDate
	{
		(int? ReturnCode, DateTime? AcqDate,
		int? AddOne,
		string Infobar) THAGetAcqDateSp(string FaNum,
		DateTime? AcqDate,
		int? AddOne,
		string Infobar);
	}
}

