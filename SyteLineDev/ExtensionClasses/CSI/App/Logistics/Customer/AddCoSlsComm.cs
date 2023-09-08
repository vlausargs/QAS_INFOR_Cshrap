//PROJECT NAME: Logistics
//CLASS NAME: AddCoSlsComm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class AddCoSlsComm : IAddCoSlsComm
	{
		readonly IApplicationDB appDB;
		
		public AddCoSlsComm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? AddCoSlsCommSp(
			string CoNum,
			string Slsman,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			SlsmanType _Slsman = Slsman;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AddCoSlsCommSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
