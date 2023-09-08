//PROJECT NAME: Logistics
//CLASS NAME: RmaItemCloseHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaItemCloseHeader : IRmaItemCloseHeader
	{
		readonly IApplicationDB appDB;
		
		
		public RmaItemCloseHeader(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RmaItemCloseHeaderSp(string PRmaNum,
		string Infobar)
		{
			RmaNumType _PRmaNum = PRmaNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaItemCloseHeaderSp";
				
				appDB.AddCommandParameter(cmd, "PRmaNum", _PRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
