//PROJECT NAME: Data
//CLASS NAME: ClonePo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ClonePo : IClonePo
	{
		readonly IApplicationDB appDB;
		
		public ClonePo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ToPoNum,
			string Infobar) ClonePoSp(
			string FromPoNum,
			string ToPoNum,
			string FromPoType,
			int? CopyCharges,
			string Infobar)
		{
			PoNumType _FromPoNum = FromPoNum;
			PoNumType _ToPoNum = ToPoNum;
			PoTypeType _FromPoType = FromPoType;
			GenericNoType _CopyCharges = CopyCharges;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ClonePoSp";
				
				appDB.AddCommandParameter(cmd, "FromPoNum", _FromPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToPoNum", _ToPoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromPoType", _FromPoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyCharges", _CopyCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ToPoNum = _ToPoNum;
				Infobar = _Infobar;
				
				return (Severity, ToPoNum, Infobar);
			}
		}
	}
}
