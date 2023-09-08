//PROJECT NAME: Data
//CLASS NAME: IClrXpar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IClrXpar
	{
		(int? ReturnCode,
			string Infobar) ClrXparSp(
			string RefType,
			string RefNum,
			int? RefLine,
			int? RefRel,
			string ChlNum,
			int? ChlLine,
			int? ChlRel,
			string Infobar,
			string ORefType = null);
	}
}

