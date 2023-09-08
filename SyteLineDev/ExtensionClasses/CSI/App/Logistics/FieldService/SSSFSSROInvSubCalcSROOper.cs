//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROInvSubCalcSROOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROInvSubCalcSROOper : ISSSFSSROInvSubCalcSROOper
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROInvSubCalcSROOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? InvLine,
			decimal? SroOperTot,
			string Infobar) SSSFSSROInvSubCalcSROOperSp(
			string Mode,
			int? InclBillHold,
			string SRONum,
			int? SROLine,
			int? SROOper,
			string InvNum,
			int? InvLine,
			DateTime? StartTransDate,
			DateTime? EndTransDate,
			decimal? SroOperTot,
			string Infobar,
			string VTXRefType,
			Guid? VTXHdrRowPointer)
		{
			StringType _Mode = Mode;
			ListYesNoType _InclBillHold = InclBillHold;
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			InvNumType _InvNum = InvNum;
			InvLineType _InvLine = InvLine;
			DateType _StartTransDate = StartTransDate;
			DateType _EndTransDate = EndTransDate;
			AmountType _SroOperTot = SroOperTot;
			Infobar _Infobar = Infobar;
			StringType _VTXRefType = VTXRefType;
			RowPointerType _VTXHdrRowPointer = VTXHdrRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROInvSubCalcSROOperSp";
				
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InclBillHold", _InclBillHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvLine", _InvLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartTransDate", _StartTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDate", _EndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOperTot", _SroOperTot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VTXRefType", _VTXRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VTXHdrRowPointer", _VTXHdrRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvLine = _InvLine;
				SroOperTot = _SroOperTot;
				Infobar = _Infobar;
				
				return (Severity, InvLine, SroOperTot, Infobar);
			}
		}
	}
}
