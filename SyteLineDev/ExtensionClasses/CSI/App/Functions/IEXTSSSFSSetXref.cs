//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSSetXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSSetXref
	{
		(int? ReturnCode,
			string Infobar) EXTSSSFSSetXrefSp(
			string PRefType,
			string PRefNum,
			int? PRefLine,
			int? PRefRel,
			string PParType,
			string PParNum,
			int? PParLine,
			int? PParRel,
			string POldParType,
			string POldParNum,
			int? POldParLine,
			int? POldParRel,
			string PItem,
			string ParmsSite,
			string Infobar);
	}
}

