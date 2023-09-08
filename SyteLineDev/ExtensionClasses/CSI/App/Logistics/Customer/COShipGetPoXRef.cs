//PROJECT NAME: Logistics
//CLASS NAME: COShipGetPoXRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class COShipGetPoXRef : ICOShipGetPoXRef
	{
		readonly IApplicationDB appDB;
		
		
		public COShipGetPoXRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PFound,
		string PType) COShipGetPoXRefSp(string PPoNum,
		int? PPoLine,
		int? PPoRelease,
		int? PFound,
		string PType)
		{
			PoNumType _PPoNum = PPoNum;
			PoLineType _PPoLine = PPoLine;
			PoReleaseType _PPoRelease = PPoRelease;
			FlagNyType _PFound = PFound;
			PoTypeType _PType = PType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "COShipGetPoXRefSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoLine", _PPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoRelease", _PPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFound", _PFound, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PFound = _PFound;
				PType = _PType;
				
				return (Severity, PFound, PType);
			}
		}
	}
}
