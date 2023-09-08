//PROJECT NAME: Data
//CLASS NAME: EdiOutObDriver2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiOutObDriver2 : IEdiOutObDriver2
	{
		readonly IApplicationDB appDB;
		
		public EdiOutObDriver2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PFlag,
			string Infobar) EdiOutObDriver2Sp(
			string PTranType,
			string POrderType,
			string PVendNum,
			string PPoNum,
			string PPoItemStat,
			int? PFlag,
			string Infobar)
		{
			LongListType _PTranType = PTranType;
			PoTypeType _POrderType = POrderType;
			VendNumType _PVendNum = PVendNum;
			PoNumType _PPoNum = PPoNum;
			StringType _PPoItemStat = PPoItemStat;
			FlagNyType _PFlag = PFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiOutObDriver2Sp";
				
				appDB.AddCommandParameter(cmd, "PTranType", _PTranType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrderType", _POrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoItemStat", _PPoItemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFlag", _PFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PFlag = _PFlag;
				Infobar = _Infobar;
				
				return (Severity, PFlag, Infobar);
			}
		}
	}
}
