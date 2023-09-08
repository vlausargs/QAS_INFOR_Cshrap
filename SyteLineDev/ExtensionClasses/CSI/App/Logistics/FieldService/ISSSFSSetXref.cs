//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSetXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSetXref
	{
		(int? ReturnCode,
			string Infobar) SSSFSSetXrefSp(
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

