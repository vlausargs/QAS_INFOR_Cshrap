//PROJECT NAME: BusInterface
//CLASS NAME: LoadProcessRequisition.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadProcessRequisition : ILoadProcessRequisition
	{
		readonly IApplicationDB appDB;
		
		
		public LoadProcessRequisition(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LoadProcessRequisitionSp(string ReqNum,
		string ActionCode,
		string StatusCode,
		string Whse,
		DateTime? RequisitionDate,
		string Requester,
		string Infobar)
		{
			ReqNumType _ReqNum = ReqNum;
			StringType _ActionCode = ActionCode;
			StringType _StatusCode = StatusCode;
			WhseType _Whse = Whse;
			DateType _RequisitionDate = RequisitionDate;
			NameType _Requester = Requester;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadProcessRequisitionSp";
				
				appDB.AddCommandParameter(cmd, "ReqNum", _ReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionCode", _ActionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatusCode", _StatusCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequisitionDate", _RequisitionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Requester", _Requester, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
