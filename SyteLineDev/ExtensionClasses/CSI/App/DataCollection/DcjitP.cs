//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcjitP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDcjitP
	{
		(int? ReturnCode, string Infobar) DcjitPSp(DateTime? TransDate,
		string Infobar,
		string DocumentNum = null);
	}
	
	public class DcjitP : IDcjitP
	{
		readonly IApplicationDB appDB;
		
		public DcjitP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcjitPSp(DateTime? TransDate,
		string Infobar,
		string DocumentNum = null)
		{
			DateType _TransDate = TransDate;
			InfobarType _Infobar = Infobar;
			DocumentNumType _DocumentNum = DocumentNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcjitPSp";
				
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocumentNum", _DocumentNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
