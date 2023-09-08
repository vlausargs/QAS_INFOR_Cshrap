//PROJECT NAME: DataCollection
//CLASS NAME: DcjrP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjrP : IDcjrP
	{
		readonly IApplicationDB appDB;
		
		
		public DcjrP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? pCanOverride,
		string Infobar) DcjrPSp(int? PTransNum,
		int? pCanOverride,
		string Infobar)
		{
			DcTransNumType _PTransNum = PTransNum;
			IntType _pCanOverride = pCanOverride;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcjrPSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCanOverride", _pCanOverride, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pCanOverride = _pCanOverride;
				Infobar = _Infobar;
				
				return (Severity, pCanOverride, Infobar);
			}
		}
	}
}
