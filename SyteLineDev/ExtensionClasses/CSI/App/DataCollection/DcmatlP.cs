//PROJECT NAME: DataCollection
//CLASS NAME: DcmatlP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcmatlP : IDcmatlP
	{
		readonly IApplicationDB appDB;
		
		
		public DcmatlP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PCanOverride,
		string Infobar) DcmatlPSp(int? PTransNum,
		int? PCanOverride,
		string Infobar)
		{
			DcTransNumType _PTransNum = PTransNum;
			ListYesNoType _PCanOverride = PCanOverride;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcmatlPSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCanOverride", _PCanOverride, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCanOverride = _PCanOverride;
				Infobar = _Infobar;
				
				return (Severity, PCanOverride, Infobar);
			}
		}
	}
}
