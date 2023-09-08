//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSMTCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSMTCode
	{
		(int? ReturnCode,
			string TDtype,
			string TDto,
			string TDfrom) EXTSSSFSMTCodeSp(
			string MatltranTransType,
			string MatltranRefType,
			string TDref,
			string TDtype,
			string TDto,
			string TDfrom);
	}
}

