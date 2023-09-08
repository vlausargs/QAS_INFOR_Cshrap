//PROJECT NAME: Finance
//CLASS NAME: IFaCostsNextSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFaCostsNextSeq
	{
		(int? ReturnCode, int? pSeq,
		string Infobar) FaCostsNextSeqSp(string pFaNum,
		int? pSeq,
		string Infobar);
	}
}

