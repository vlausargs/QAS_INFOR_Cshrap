//PROJECT NAME: Data
//CLASS NAME: ISitcubal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISitcubal
	{
		(int? ReturnCode,
			string Infobar) SitcubalSp(
			string CustNum,
			string CorpCustNum,
			string Infobar);
	}
}

