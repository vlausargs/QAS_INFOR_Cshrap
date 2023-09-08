//PROJECT NAME: Logistics
//CLASS NAME: ChangeCOInvalidDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ChangeCOInvalidDueDate : IChangeCOInvalidDueDate
	{
		readonly IApplicationDB appDB;
		
		
		public ChangeCOInvalidDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ChangeCOInvalidDueDateSp(int? Selected,
		string OrderNum,
		int? Line,
		int? Release,
		string Status,
		DateTime? OldDueDate,
		DateTime? NewDueDate,
		string ShipSite,
		string Infobar)
		{
			ListYesNoType _Selected = Selected;
			CoNumType _OrderNum = OrderNum;
			CoLineType _Line = Line;
			CoReleaseType _Release = Release;
			CoStatusType _Status = Status;
			DateType _OldDueDate = OldDueDate;
			DateType _NewDueDate = NewDueDate;
			SiteType _ShipSite = ShipSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeCOInvalidDueDateSp";
				
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderNum", _OrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Line", _Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Release", _Release, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldDueDate", _OldDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewDueDate", _NewDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
