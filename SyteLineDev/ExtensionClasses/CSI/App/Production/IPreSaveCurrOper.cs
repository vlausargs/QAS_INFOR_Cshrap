//PROJECT NAME: Production
//CLASS NAME: IPreSaveCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPreSaveCurrOper
	{
		(int? ReturnCode, string Job,
		int? Suffix,
		string JobType,
		string Infobar) PreSaveCurrOperSp(string Item,
		int? OperNum,
		string Wc,
		string Job,
		int? Suffix,
		string JobType,
		string Infobar,
		string AlternateID = null);
	}
}

