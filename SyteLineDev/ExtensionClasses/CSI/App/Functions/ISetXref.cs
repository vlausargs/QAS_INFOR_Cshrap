//PROJECT NAME: Data
//CLASS NAME: ISetXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISetXref
	{
		(int? ReturnCode,
			string PErrorMsg) SetXrefSp(
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
			int? PUpdateMrp,
			string PErrorMsg,
			string CostCode = null);
	}
}

