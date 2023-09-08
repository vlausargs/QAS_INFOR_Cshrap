//PROJECT NAME: Data
//CLASS NAME: IUpdPbal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdPbal
	{
		(int? ReturnCode,
			string Message) UpdPbalSp(
			string CorpCustNum,
			decimal? Adjust,
			string Operator,
			string Message);
	}
}

