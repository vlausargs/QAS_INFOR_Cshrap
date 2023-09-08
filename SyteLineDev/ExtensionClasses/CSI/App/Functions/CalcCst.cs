//PROJECT NAME: Data
//CLASS NAME: CalcCst.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalcCst : ICalcCst
	{
		readonly IApplicationDB appDB;
		
		public CalcCst(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? OldCost,
			decimal? NewCost,
			string Infobar) CalcCstSp(
			Guid? JobRowPointer,
			int? CalcCost,
			decimal? UnitCost,
			decimal? LotCost,
			decimal? OldCost,
			decimal? NewCost,
			string Infobar)
		{
			RowPointerType _JobRowPointer = JobRowPointer;
			ListYesNoType _CalcCost = CalcCost;
			CostPrcType _UnitCost = UnitCost;
			CostPrcType _LotCost = LotCost;
			CostPrcType _OldCost = OldCost;
			CostPrcType _NewCost = NewCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcCstSp";
				
				appDB.AddCommandParameter(cmd, "JobRowPointer", _JobRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcCost", _CalcCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotCost", _LotCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCost", _OldCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewCost", _NewCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OldCost = _OldCost;
				NewCost = _NewCost;
				Infobar = _Infobar;
				
				return (Severity, OldCost, NewCost, Infobar);
			}
		}
	}
}
