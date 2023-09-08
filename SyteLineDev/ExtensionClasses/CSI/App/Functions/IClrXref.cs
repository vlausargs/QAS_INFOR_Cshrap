//PROJECT NAME: Data
//CLASS NAME: IClrXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IClrXref
	{
		(int? ReturnCode,
			string Infobar) ClrXrefSp(
			string RefType,
			string RefNum,
			int? RefLine,
			int? RefRel,
			string ParNum,
			int? ParLine,
			int? ParRel,
			string Infobar,
			string ORefType = null);
	}
}

