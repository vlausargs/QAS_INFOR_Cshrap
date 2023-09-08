//PROJECT NAME: DataCollection
//CLASS NAME: DcmoveV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcmoveV : IDcmoveV
	{
		readonly IApplicationDB appDB;
		
		public DcmoveV(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? CanOverride,
			string Infobar) DcmoveVSp(
			int? DcmoveTransNum,
			int? CanOverride,
			string Infobar)
		{
			DcTransNumType _DcmoveTransNum = DcmoveTransNum;
			ListYesNoType _CanOverride = CanOverride;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcmoveVSp";
				
				appDB.AddCommandParameter(cmd, "DcmoveTransNum", _DcmoveTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanOverride", _CanOverride, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CanOverride = _CanOverride;
				Infobar = _Infobar;
				
				return (Severity, CanOverride, Infobar);
			}
		}
	}
}
