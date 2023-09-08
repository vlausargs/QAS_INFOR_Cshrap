//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROXRefAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROXRefAmt : ISSSFSSROXRefAmt
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROXRefAmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PQtyAvail,
			string Infobar,
			int? POError) SSSFSSROXRefAmtSP(
			string PRefType = null,
			string PRefNum = null,
			int? PRefLine = null,
			int? PRefRel = null,
			string PItem = null,
			decimal? PQtyAvail = null,
			string Infobar = null,
			int? POError = 0)
		{
			FSRefTypeIJKMOPRTType _PRefType = PRefType;
			FSRefNumType _PRefNum = PRefNum;
			FSRefLineType _PRefLine = PRefLine;
			FSRefReleaseType _PRefRel = PRefRel;
			ItemType _PItem = PItem;
			QtyUnitType _PQtyAvail = PQtyAvail;
			Infobar _Infobar = Infobar;
			ListYesNoType _POError = POError;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROXRefAmtSP";
				
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLine", _PRefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRel", _PRefRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyAvail", _PQtyAvail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POError", _POError, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PQtyAvail = _PQtyAvail;
				Infobar = _Infobar;
				POError = _POError;
				
				return (Severity, PQtyAvail, Infobar, POError);
			}
		}
	}
}
