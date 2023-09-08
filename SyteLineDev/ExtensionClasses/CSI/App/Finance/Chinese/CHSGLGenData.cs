//PROJECT NAME: Finance
//CLASS NAME: CHSGLGenData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSGLGenData : ICHSGLGenData
	{
		readonly IApplicationDB appDB;
		
		public CHSGLGenData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CHSGLGenDataSP(
			DateTime? sdate,
			DateTime? edate)
		{
			DateType _sdate = sdate;
			DateType _edate = edate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSGLGenDataSP";
				
				appDB.AddCommandParameter(cmd, "sdate", _sdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "edate", _edate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
