//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUpdateXrefSroCheckType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSUpdateXrefSroCheckType
	{
		(int? ReturnCode, string SroType) SSSFSUpdateXrefSroCheckTypeSp(string poNum,
		short? poLine,
		string SroType);
	}
	
	public class SSSFSUpdateXrefSroCheckType : ISSSFSUpdateXrefSroCheckType
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUpdateXrefSroCheckType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SroType) SSSFSUpdateXrefSroCheckTypeSp(string poNum,
		short? poLine,
		string SroType)
		{
			PoNumType _poNum = poNum;
			PoLineType _poLine = poLine;
			UnusedCharType _SroType = SroType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUpdateXrefSroCheckTypeSp";
				
				appDB.AddCommandParameter(cmd, "poNum", _poNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "poLine", _poLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroType", _SroType, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SroType = _SroType;
				
				return (Severity, SroType);
			}
		}
	}
}
