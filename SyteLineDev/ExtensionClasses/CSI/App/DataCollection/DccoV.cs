//PROJECT NAME: DataCollection
//CLASS NAME: DccoV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DccoV : IDccoV
	{
		readonly IApplicationDB appDB;
		
		public DccoV(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? CanOverride,
			string Infobar) DccoVSp(
			int? DccoTransNum,
			int? CanOverride,
			string Infobar)
		{
			DcTransNumType _DccoTransNum = DccoTransNum;
			ListYesNoType _CanOverride = CanOverride;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DccoVSp";
				
				appDB.AddCommandParameter(cmd, "DccoTransNum", _DccoTransNum, ParameterDirection.Input);
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
