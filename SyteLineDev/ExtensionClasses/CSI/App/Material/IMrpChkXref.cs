//PROJECT NAME: Material
//CLASS NAME: IMrpChkXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpChkXref
	{
		(int? ReturnCode,
			int? PValidXref,
			int? PComplXref,
			string PErrMsg) MrpChkXrefSp(
			string POrderType,
			string PReference,
			int? PRefLine,
			int? PRefRel,
			string PItem,
			string PXrefType,
			string PXrefNum,
			int? PXrefLine,
			int? PXrefRel,
			int? PSuffix,
			int? PValidXref,
			int? PComplXref,
			string PErrMsg);
	}
}

