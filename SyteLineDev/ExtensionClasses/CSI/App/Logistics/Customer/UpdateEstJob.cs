//PROJECT NAME: Logistics
//CLASS NAME: UpdateEstJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateEstJob : IUpdateEstJob
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateEstJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateEstJobSp(string EstNum,
		int? EstLine,
		string RefNum,
		int? RefLineSuf,
		int? ProductCycle,
		decimal? QtyCycle,
		string Item,
		string BOMType,
		string CoProductMix,
		string AlternateID,
		string Infobar)
		{
			CoNumType _EstNum = EstNum;
			CoLineType _EstLine = EstLine;
			JobPoProjReqTrnNumType _RefNum = RefNum;
			SuffixPoLineProjTaskReqTrnLineType _RefLineSuf = RefLineSuf;
			MO_ProductCycleType _ProductCycle = ProductCycle;
			QtyUnitType _QtyCycle = QtyCycle;
			ItemType _Item = Item;
			MO_JobConfigTypeType _BOMType = BOMType;
			ProdMixType _CoProductMix = CoProductMix;
			MO_BOMAlternateType _AlternateID = AlternateID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateEstJobSp";
				
				appDB.AddCommandParameter(cmd, "EstNum", _EstNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstLine", _EstLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCycle", _ProductCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyCycle", _QtyCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BOMType", _BOMType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoProductMix", _CoProductMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlternateID", _AlternateID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
