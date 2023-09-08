//PROJECT NAME: Material
//CLASS NAME: MrpChkXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpChkXref : IMrpChkXref
	{
		readonly IApplicationDB appDB;
		
		public MrpChkXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string PErrMsg)
		{
			MrpOrderTypeType _POrderType = POrderType;
			MrpOrderType _PReference = PReference;
			MrpOrderLineType _PRefLine = PRefLine;
			UnknownRefReleaseType _PRefRel = PRefRel;
			ItemType _PItem = PItem;
			RefTypeIJKPRTType _PXrefType = PXrefType;
			JobPoProjReqTrnNumType _PXrefNum = PXrefNum;
			SuffixPoReqTrnLineType _PXrefLine = PXrefLine;
			PoReleaseType _PXrefRel = PXrefRel;
			ListYesNoType _PSuffix = PSuffix;
			FlagNyType _PValidXref = PValidXref;
			FlagNyType _PComplXref = PComplXref;
			LongListType _PErrMsg = PErrMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpChkXrefSp";
				
				appDB.AddCommandParameter(cmd, "POrderType", _POrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReference", _PReference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLine", _PRefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRel", _PRefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXrefType", _PXrefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXrefNum", _PXrefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXrefLine", _PXrefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXrefRel", _PXrefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PValidXref", _PValidXref, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PComplXref", _PComplXref, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PErrMsg", _PErrMsg, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PValidXref = _PValidXref;
				PComplXref = _PComplXref;
				PErrMsg = _PErrMsg;
				
				return (Severity, PValidXref, PComplXref, PErrMsg);
			}
		}
	}
}
