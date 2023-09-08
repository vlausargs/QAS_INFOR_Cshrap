//PROJECT NAME: DataCollection
//CLASS NAME: DctrV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DctrV : IDctrV
	{
		readonly IApplicationDB appDB;
		
		public DctrV(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? CanOverride,
			string Infobar) DctrVSp(
			int? DctrTransNum,
			int? CanOverride,
			string Infobar)
		{
			DcTransNumType _DctrTransNum = DctrTransNum;
			ListYesNoType _CanOverride = CanOverride;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DctrVSp";
				
				appDB.AddCommandParameter(cmd, "DctrTransNum", _DctrTransNum, ParameterDirection.Input);
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
