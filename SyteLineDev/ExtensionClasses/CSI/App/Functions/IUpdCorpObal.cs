//PROJECT NAME: Data
//CLASS NAME: IUpdCorpObal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdCorpObal
	{
		(int? ReturnCode,
			string Message) UpdCorpObalSp(
			string CorpCustNum,
			decimal? Adjust,
			string Operator,
			string Message);
	}
}

