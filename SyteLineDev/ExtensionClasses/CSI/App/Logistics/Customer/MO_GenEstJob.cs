//PROJECT NAME: Logistics
//CLASS NAME: MO_GenEstJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class MO_GenEstJob : IMO_GenEstJob
	{
		readonly IApplicationDB appDB;
		
		
		public MO_GenEstJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MO_GenEstJobSp(string CoNum,
		int? CoLine,
		string Item,
		decimal? QtyOrdered,
		int? ProductCycle,
		decimal? QtyPerCycle,
		DateTime? DueDate,
		string Whse,
		string BOMType,
		string CoProductMix,
		string AlternateID,
		string Resource,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			ItemType _Item = Item;
			QtyUnitType _QtyOrdered = QtyOrdered;
			MO_ProductCycleType _ProductCycle = ProductCycle;
			QtyUnitType _QtyPerCycle = QtyPerCycle;
			DateType _DueDate = DueDate;
			WhseType _Whse = Whse;
			MO_JobConfigTypeType _BOMType = BOMType;
			ProdMixType _CoProductMix = CoProductMix;
			MO_BOMAlternateType _AlternateID = AlternateID;
			ApsResourceType _Resource = Resource;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_GenEstJobSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrdered", _QtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCycle", _ProductCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPerCycle", _QtyPerCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMType", _BOMType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoProductMix", _CoProductMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateID", _AlternateID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Resource", _Resource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
