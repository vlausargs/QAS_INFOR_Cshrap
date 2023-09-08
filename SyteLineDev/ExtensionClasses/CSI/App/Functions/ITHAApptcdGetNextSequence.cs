//PROJECT NAME: Data
//CLASS NAME: ITHAApptcdGetNextSequence.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAApptcdGetNextSequence
	{
		(int? ReturnCode,
			int? PSeq,
			string Infobar) THAApptcdGetNextSequenceSp(
			string PVendNum,
			string PBankCode,
			int? PCheckSeq,
			int? PSeq,
			string Infobar);
	}
}

