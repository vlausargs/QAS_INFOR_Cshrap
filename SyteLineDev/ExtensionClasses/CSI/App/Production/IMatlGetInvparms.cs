//PROJECT NAME: Production
//CLASS NAME: IMatlGetInvparms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IMatlGetInvparms
	{
		(int? ReturnCode, string DefWhse,
		string EcnEst,
		string EcnJob,
		string EcnStd,
		int? NegFlag,
		string Infobar) MatlGetInvparmsSp(string DefWhse,
		string EcnEst,
		string EcnJob,
		string EcnStd,
		int? NegFlag,
		string Infobar);
	}
}

