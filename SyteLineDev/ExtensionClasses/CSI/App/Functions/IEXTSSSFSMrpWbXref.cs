//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSMrpWbXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSMrpWbXref
	{
		(int? ReturnCode,
			string Infobar) EXTSSSFSMrpWbXrefSp(
			string OrdType,
			string OrdNum,
			int? OrdLineSuf,
			int? OrdRelease,
			int? OrdSeq,
			string RefType,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Infobar);
	}
}

