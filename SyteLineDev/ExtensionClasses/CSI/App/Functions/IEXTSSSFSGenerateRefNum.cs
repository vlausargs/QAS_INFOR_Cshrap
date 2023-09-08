//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSGenerateRefNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSGenerateRefNum
	{
		(int? ReturnCode,
			string RefNum,
			string Infobar) EXTSSSFSGenerateRefNumSp(
			string RefType,
			string RefNum,
			string Infobar);
	}
}

