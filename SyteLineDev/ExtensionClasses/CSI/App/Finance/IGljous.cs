//PROJECT NAME: Finance
//CLASS NAME: IGljous.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGljous
	{
		(int? ReturnCode, string Infobar) GljousSp(string PId,
		int? PFromSeq,
		int? PToSeq,
		int? PFirstSeq,
		int? PStepSize,
		string PTitle,
		string Infobar);
	}
}

