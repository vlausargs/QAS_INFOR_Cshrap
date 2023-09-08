//PROJECT NAME: DataCollection
//CLASS NAME: DcAPhysinSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcAPhysinSerial : IDcAPhysinSerial
	{
		readonly IApplicationDB appDB;
		
		
		public DcAPhysinSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcAPhysinSerialSp(Guid? PPhyinvRowPointer,
		string PSerNum,
		string Infobar)
		{
			RowPointerType _PPhyinvRowPointer = PPhyinvRowPointer;
			SerNumType _PSerNum = PSerNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcAPhysinSerialSp";
				
				appDB.AddCommandParameter(cmd, "PPhyinvRowPointer", _PPhyinvRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSerNum", _PSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
