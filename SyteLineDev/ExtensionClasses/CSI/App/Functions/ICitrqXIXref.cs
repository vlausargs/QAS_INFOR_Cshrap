//PROJECT NAME: Data
//CLASS NAME: ICitrqXIXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICitrqXIXref
	{
		(int? ReturnCode,
			string CurReqNum,
			int? CurReqLine,
			string Infobar) CitrqXIXrefSp(
			string SourceFile,
			string SourceRefType,
			string SourceRefNum,
			int? SourceRefLineSuf,
			int? SourceRefRelease,
			string PWhse,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			decimal? PQtyOrdered,
			DateTime? PDueDate,
			string PRefType,
			string PStat,
			string PStatFldName,
			string PItem,
			string PItemDescription,
			decimal? PItemCurUCost,
			string PItemUM,
			string PPrefix = null,
			int? ObsslowFlag = 0,
			string CurReqNum = null,
			int? CurReqLine = null,
			string Infobar = null);
	}
}

