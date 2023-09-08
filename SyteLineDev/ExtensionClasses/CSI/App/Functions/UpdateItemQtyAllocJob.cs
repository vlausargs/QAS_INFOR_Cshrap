//PROJECT NAME: Data
//CLASS NAME: UpdateItemQtyAllocJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdateItemQtyAllocJob : IUpdateItemQtyAllocJob
	{
		readonly IApplicationDB appDB;
		
		public UpdateItemQtyAllocJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UpdateItemQtyAllocJobSp(
			string PAction,
			string PJob,
			int? PSuffix,
			string POldItem,
			string PNewItem,
			decimal? POldMatlQty,
			decimal? PNewMatlQty,
			string POldUM,
			string PNewUM,
			string POldUnits,
			string PNewUnits,
			decimal? POldScrapFact,
			decimal? PNewScrapFact,
			decimal? POldQtyIssued,
			decimal? PNewQtyIssued,
			int? PNewOperNum,
			int? POldOperNum,
			string Infobar)
		{
			StringType _PAction = PAction;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			ItemType _POldItem = POldItem;
			ItemType _PNewItem = PNewItem;
			QtyPerType _POldMatlQty = POldMatlQty;
			QtyPerType _PNewMatlQty = PNewMatlQty;
			UMType _POldUM = POldUM;
			UMType _PNewUM = PNewUM;
			JobmatlUnitsType _POldUnits = POldUnits;
			JobmatlUnitsType _PNewUnits = PNewUnits;
			ScrapFactorType _POldScrapFact = POldScrapFact;
			ScrapFactorType _PNewScrapFact = PNewScrapFact;
			QtyPerType _POldQtyIssued = POldQtyIssued;
			QtyPerType _PNewQtyIssued = PNewQtyIssued;
			OperNumType _PNewOperNum = PNewOperNum;
			OperNumType _POldOperNum = POldOperNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateItemQtyAllocJobSp";
				
				appDB.AddCommandParameter(cmd, "PAction", _PAction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldItem", _POldItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewItem", _PNewItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldMatlQty", _POldMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewMatlQty", _PNewMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldUM", _POldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewUM", _PNewUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldUnits", _POldUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewUnits", _PNewUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldScrapFact", _POldScrapFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewScrapFact", _PNewScrapFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldQtyIssued", _POldQtyIssued, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewQtyIssued", _PNewQtyIssued, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewOperNum", _PNewOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldOperNum", _POldOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
