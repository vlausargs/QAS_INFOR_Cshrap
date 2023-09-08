//PROJECT NAME: Data
//CLASS NAME: CalcDet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalcDet : ICalcDet
	{
		readonly IApplicationDB appDB;
		
		public CalcDet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PLbrCost,
			decimal? PMatlCost,
			decimal? PFovhdCost,
			decimal? PVovhdCost,
			decimal? POutCost,
			string Infobar) CalcDetSp(
			Guid? JobRecid,
			decimal? PLbrCost,
			decimal? PMatlCost,
			decimal? PFovhdCost,
			decimal? PVovhdCost,
			decimal? POutCost,
			string Infobar,
			decimal? BreakQty = 1M,
			int? UseVendorPrice = 0)
		{
			RowPointerType _JobRecid = JobRecid;
			AmtTotType _PLbrCost = PLbrCost;
			AmtTotType _PMatlCost = PMatlCost;
			AmtTotType _PFovhdCost = PFovhdCost;
			AmtTotType _PVovhdCost = PVovhdCost;
			AmtTotType _POutCost = POutCost;
			InfobarType _Infobar = Infobar;
			QtyUnitType _BreakQty = BreakQty;
			ListYesNoType _UseVendorPrice = UseVendorPrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcDetSp";
				
				appDB.AddCommandParameter(cmd, "JobRecid", _JobRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLbrCost", _PLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMatlCost", _PMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFovhdCost", _PFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVovhdCost", _PVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POutCost", _POutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BreakQty", _BreakQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseVendorPrice", _UseVendorPrice, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PLbrCost = _PLbrCost;
				PMatlCost = _PMatlCost;
				PFovhdCost = _PFovhdCost;
				PVovhdCost = _PVovhdCost;
				POutCost = _POutCost;
				Infobar = _Infobar;
				
				return (Severity, PLbrCost, PMatlCost, PFovhdCost, PVovhdCost, POutCost, Infobar);
			}
		}
	}
}
