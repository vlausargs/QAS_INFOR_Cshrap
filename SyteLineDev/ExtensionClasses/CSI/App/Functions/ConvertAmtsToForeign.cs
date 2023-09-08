//PROJECT NAME: Data
//CLASS NAME: ConvertAmtsToForeign.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvertAmtsToForeign : IConvertAmtsToForeign
	{
		readonly IApplicationDB appDB;
		
		public ConvertAmtsToForeign(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ConvertAmtsToForeignSp(
			string PPoNum,
			DateTime? PoOrderDate,
			string PCurrCode,
			string OldCurrCode,
			string Infobar)
		{
			PoNumType _PPoNum = PPoNum;
			DateType _PoOrderDate = PoOrderDate;
			CurrCodeType _PCurrCode = PCurrCode;
			CurrCodeType _OldCurrCode = OldCurrCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ConvertAmtsToForeignSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoOrderDate", _PoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldCurrCode", _OldCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
