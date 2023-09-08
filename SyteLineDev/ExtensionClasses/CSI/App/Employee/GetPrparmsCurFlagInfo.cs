//PROJECT NAME: CSIEmployee
//CLASS NAME: GetPrparmsCurFlagInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IGetPrparmsCurFlagInfo
	{
		(int? ReturnCode, byte? PrparmsCurFlag1, byte? PrparmsCurFlag2, byte? PrparmsCurFlag3, byte? PrparmsCurFlag4) GetPrparmsCurFlagInfoSp(byte? PrparmsCurFlag1 = (byte)0,
		byte? PrparmsCurFlag2 = (byte)0,
		byte? PrparmsCurFlag3 = (byte)0,
		byte? PrparmsCurFlag4 = (byte)0);
	}
	
	public class GetPrparmsCurFlagInfo : IGetPrparmsCurFlagInfo
	{
		readonly IApplicationDB appDB;
		
		public GetPrparmsCurFlagInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? PrparmsCurFlag1, byte? PrparmsCurFlag2, byte? PrparmsCurFlag3, byte? PrparmsCurFlag4) GetPrparmsCurFlagInfoSp(byte? PrparmsCurFlag1 = (byte)0,
		byte? PrparmsCurFlag2 = (byte)0,
		byte? PrparmsCurFlag3 = (byte)0,
		byte? PrparmsCurFlag4 = (byte)0)
		{
			ListYesNoType _PrparmsCurFlag1 = PrparmsCurFlag1;
			ListYesNoType _PrparmsCurFlag2 = PrparmsCurFlag2;
			ListYesNoType _PrparmsCurFlag3 = PrparmsCurFlag3;
			ListYesNoType _PrparmsCurFlag4 = PrparmsCurFlag4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPrparmsCurFlagInfoSp";
				
				appDB.AddCommandParameter(cmd, "PrparmsCurFlag1", _PrparmsCurFlag1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrparmsCurFlag2", _PrparmsCurFlag2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrparmsCurFlag3", _PrparmsCurFlag3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrparmsCurFlag4", _PrparmsCurFlag4, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PrparmsCurFlag1 = _PrparmsCurFlag1;
				PrparmsCurFlag2 = _PrparmsCurFlag2;
				PrparmsCurFlag3 = _PrparmsCurFlag3;
				PrparmsCurFlag4 = _PrparmsCurFlag4;
				
				return (Severity, PrparmsCurFlag1, PrparmsCurFlag2, PrparmsCurFlag3, PrparmsCurFlag4);
			}
		}
	}
}
