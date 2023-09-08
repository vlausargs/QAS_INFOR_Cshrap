//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroAllocGetQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSroAllocGetQty : ISSSFSSroAllocGetQty
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroAllocGetQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? oQty,
			string Infobar) SSSFSSroAllocGetQtySp(
			string iWhse,
			string iItem,
			decimal? iMatlQty,
			string iSroStat,
			string iOpStat,
			decimal? oQty,
			string Infobar)
		{
			WhseType _iWhse = iWhse;
			ItemType _iItem = iItem;
			QtyUnitType _iMatlQty = iMatlQty;
			FSSROStatType _iSroStat = iSroStat;
			FSSROOperStatType _iOpStat = iOpStat;
			QtyUnitType _oQty = oQty;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroAllocGetQtySp";
				
				appDB.AddCommandParameter(cmd, "iWhse", _iWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMatlQty", _iMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroStat", _iSroStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iOpStat", _iOpStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oQty", _oQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oQty = _oQty;
				Infobar = _Infobar;
				
				return (Severity, oQty, Infobar);
			}
		}
	}
}
