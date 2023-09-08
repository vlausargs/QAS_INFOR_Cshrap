//PROJECT NAME: Codes
//CLASS NAME: IGenerateInvDistProceduralMarkings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGenerateInvDistProceduralMarkings
	{
		(int? ReturnCode, string Infobar) GenerateInvDistProceduralMarkingsSp(string InvNum,
		int? InvSeq,
		string Infobar = null);
	}
}

