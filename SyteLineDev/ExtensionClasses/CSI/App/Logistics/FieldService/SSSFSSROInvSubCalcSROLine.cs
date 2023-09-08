//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROInvSubCalcSROLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROInvSubCalcSROLine : ISSSFSSROInvSubCalcSROLine
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROInvSubCalcSROLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? InvLine,
			decimal? SroLineMatlTot,
			string Infobar) SSSFSSROInvSubCalcSROLineSp(
			string Mode,
			int? InclBillHold,
			string SRONum,
			int? SROLine,
			string InvNum,
			int? InvLine,
			decimal? SroLineMatlTot,
			DateTime? StartTransDate,
			DateTime? EndTransDate,
			string Infobar,
			string VTXRefType,
			Guid? VTXHdrRowPointer)
		{
			StringType _Mode = Mode;
			ListYesNoType _InclBillHold = InclBillHold;
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			InvNumType _InvNum = InvNum;
			InvLineType _InvLine = InvLine;
			AmountType _SroLineMatlTot = SroLineMatlTot;
			DateType _StartTransDate = StartTransDate;
			DateType _EndTransDate = EndTransDate;
			Infobar _Infobar = Infobar;
			StringType _VTXRefType = VTXRefType;
			RowPointerType _VTXHdrRowPointer = VTXHdrRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROInvSubCalcSROLineSp";
				
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclBillHold", _InclBillHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvLine", _InvLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SroLineMatlTot", _SroLineMatlTot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartTransDate", _StartTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDate", _EndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VTXRefType", _VTXRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VTXHdrRowPointer", _VTXHdrRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvLine = _InvLine;
				SroLineMatlTot = _SroLineMatlTot;
				Infobar = _Infobar;
				
				return (Severity, InvLine, SroLineMatlTot, Infobar);
			}
		}
	}
}
