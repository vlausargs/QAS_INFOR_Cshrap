//PROJECT NAME: Data
//CLASS NAME: FTCSIDeleteTmpser.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTCSIDeleteTmpser : IFTCSIDeleteTmpser
	{
		readonly IApplicationDB appDB;
		
		public FTCSIDeleteTmpser(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FTCSIDeleteTmpserSp(
			long? TimeBeforePurgeThrough,
			string Infobar)
		{
			LongType _TimeBeforePurgeThrough = TimeBeforePurgeThrough;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTCSIDeleteTmpserSp";
				
				appDB.AddCommandParameter(cmd, "TimeBeforePurgeThrough", _TimeBeforePurgeThrough, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
