//PROJECT NAME: Finance
//CLASS NAME: CHSDetailLeftOverGenData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSDetailLeftOverGenData : ICHSDetailLeftOverGenData
	{
		readonly IApplicationDB appDB;
		
		public CHSDetailLeftOverGenData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CHSDetailLeftOverGenDataSP(
			string Text,
			DateTime? sdate,
			DateTime? edate)
		{
			StringType _Text = Text;
			DateType _sdate = sdate;
			DateType _edate = edate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSDetailLeftOverGenDataSP";
				
				appDB.AddCommandParameter(cmd, "Text", _Text, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "sdate", _sdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "edate", _edate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
