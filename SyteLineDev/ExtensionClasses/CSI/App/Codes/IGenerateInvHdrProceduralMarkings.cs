//PROJECT NAME: Codes
//CLASS NAME: IGenerateInvHdrProceduralMarkings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGenerateInvHdrProceduralMarkings
	{
		(int? ReturnCode, string Infobar) GenerateInvHdrProceduralMarkingsSp(string InvNum,
		int? InvSeq,
		string CustNum,
		string TaxCode,
		string ApplyToInvNum = null,
		string Infobar = null);
	}
}

