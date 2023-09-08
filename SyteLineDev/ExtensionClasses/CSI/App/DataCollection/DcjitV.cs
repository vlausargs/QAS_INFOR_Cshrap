//PROJECT NAME: DataCollection
//CLASS NAME: DcjitV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjitV : IDcjitV
	{
		readonly IApplicationDB appDB;
		
		public DcjitV(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? CanOverride,
			string Infobar) DcjitVSp(
			int? DcjitTransNum,
			int? CanOverride,
			string Infobar)
		{
			DcTransNumType _DcjitTransNum = DcjitTransNum;
			ListYesNoType _CanOverride = CanOverride;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcjitVSp";
				
				appDB.AddCommandParameter(cmd, "DcjitTransNum", _DcjitTransNum, ParameterDirection.Input);
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
