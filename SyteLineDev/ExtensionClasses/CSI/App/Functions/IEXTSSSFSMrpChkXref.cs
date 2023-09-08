//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSMrpChkXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSMrpChkXref
	{
		(int? ReturnCode,
			int? PValidXref,
			int? PComplXref,
			string PErrMsg) EXTSSSFSMrpChkXrefSp(
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

