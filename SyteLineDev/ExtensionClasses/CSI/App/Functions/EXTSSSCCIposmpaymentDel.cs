//PROJECT NAME: Data
//CLASS NAME: EXTSSSCCIposmpaymentDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSCCIposmpaymentDel : IEXTSSSCCIposmpaymentDel
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSCCIposmpaymentDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTSSSCCIposmpaymentDelSp(
			string POSNum,
			decimal? GatewayTransNum,
			string Infobar)
		{
			StringType _POSNum = POSNum;
			CCIGatewayTransNumType _GatewayTransNum = GatewayTransNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSCCIposmpaymentDelSp";
				
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GatewayTransNum", _GatewayTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
