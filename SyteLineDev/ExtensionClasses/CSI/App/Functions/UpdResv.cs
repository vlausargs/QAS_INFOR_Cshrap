//PROJECT NAME: Data
//CLASS NAME: UpdResv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdResv : IUpdResv
	{
		readonly IApplicationDB appDB;
		
		public UpdResv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UpdResvSp(
			int? DelRsvd,
			Guid? RsiRowPointer,
			decimal? AdjQty,
			decimal? ConvFactor,
			string FROMBase,
			string Infobar,
			Guid? SessionID,
			int? ProcessTmpSer = 0,
			int? ClearUnusedSerials = 0,
			int? SkipInventoryUpdate = 0)
		{
			Flag _DelRsvd = DelRsvd;
			RowPointerType _RsiRowPointer = RsiRowPointer;
			QtyUnitType _AdjQty = AdjQty;
			UMConvFactorType _ConvFactor = ConvFactor;
			StringType _FROMBase = FROMBase;
			Infobar _Infobar = Infobar;
			RowPointerType _SessionID = SessionID;
			ListYesNoType _ProcessTmpSer = ProcessTmpSer;
			ListYesNoType _ClearUnusedSerials = ClearUnusedSerials;
			ListYesNoType _SkipInventoryUpdate = SkipInventoryUpdate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdResvSp";
				
				appDB.AddCommandParameter(cmd, "DelRsvd", _DelRsvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RsiRowPointer", _RsiRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AdjQty", _AdjQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvFactor", _ConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FROMBase", _FROMBase, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessTmpSer", _ProcessTmpSer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ClearUnusedSerials", _ClearUnusedSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkipInventoryUpdate", _SkipInventoryUpdate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
