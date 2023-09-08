//PROJECT NAME: CSICustomer
//CLASS NAME: GetReportLabels.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetReportLabels
	{
		(int? ReturnCode, string Label1, string Label2, string Label3) GetReportLabelsSp(string RepID,
		string RepType,
		short? Line,
		string Label1 = null,
		string Label2 = null,
		string Label3 = null);
	}
	
	public class GetReportLabels : IGetReportLabels
	{
		readonly IApplicationDB appDB;
		
		public GetReportLabels(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Label1, string Label2, string Label3) GetReportLabelsSp(string RepID,
		string RepType,
		short? Line,
		string Label1 = null,
		string Label2 = null,
		string Label3 = null)
		{
			ReportIdType _RepID = RepID;
			MiscReportTypeType _RepType = RepType;
			ReportLineType _Line = Line;
			ReportTxtType _Label1 = Label1;
			ReportTxtType _Label2 = Label2;
			ReportTxtType _Label3 = Label3;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetReportLabelsSp";
				
				appDB.AddCommandParameter(cmd, "RepID", _RepID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepType", _RepType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Line", _Line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Label1", _Label1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Label2", _Label2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Label3", _Label3, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Label1 = _Label1;
				Label2 = _Label2;
				Label3 = _Label3;
				
				return (Severity, Label1, Label2, Label3);
			}
		}
	}
}
