//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseRequirementsTimePhaseDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PurchaseRequirementsTimePhaseDetail : IRpt_PurchaseRequirementsTimePhaseDetail
	{
		readonly IApplicationDB appDB;
		
		public Rpt_PurchaseRequirementsTimePhaseDetail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_PurchaseRequirementsTimePhaseDetailSp(
			string Item,
			decimal? QtyOnHand,
			string WhseStarting,
			string WhseEnding,
			int? ShowDepl,
			int? ShowRepl,
			string COStatus,
			string POStatus,
			string PSStatus,
			string JobStatus,
			int? UseJob)
		{
			ItemType _Item = Item;
			QtyUnitType _QtyOnHand = QtyOnHand;
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			FlagNyType _ShowDepl = ShowDepl;
			FlagNyType _ShowRepl = ShowRepl;
			InfobarType _COStatus = COStatus;
			InfobarType _POStatus = POStatus;
			InfobarType _PSStatus = PSStatus;
			InfobarType _JobStatus = JobStatus;
			FlagNyType _UseJob = UseJob;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PurchaseRequirementsTimePhaseDetailSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDepl", _ShowDepl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowRepl", _ShowRepl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COStatus", _COStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POStatus", _POStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSStatus", _PSStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStatus", _JobStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseJob", _UseJob, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
