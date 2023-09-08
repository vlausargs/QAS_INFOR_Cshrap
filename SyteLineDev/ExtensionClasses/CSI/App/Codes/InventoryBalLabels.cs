//PROJECT NAME: CSICodes
//CLASS NAME: InventoryBalLabels.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IInventoryBalLabels
	{
		int InventoryBalLabelsSp(ref DateTime? FirstPeriodEnd,
		                         ref DateTime? SecondPeriodEnd,
		                         ref DateTime? ThirdPeriodEnd,
		                         ref DateTime? FourthPeriodEnd);
	}
	
	public class InventoryBalLabels : IInventoryBalLabels
	{
		readonly IApplicationDB appDB;
		
		public InventoryBalLabels(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int InventoryBalLabelsSp(ref DateTime? FirstPeriodEnd,
		                                ref DateTime? SecondPeriodEnd,
		                                ref DateTime? ThirdPeriodEnd,
		                                ref DateTime? FourthPeriodEnd)
		{
			DateTimeType _FirstPeriodEnd = FirstPeriodEnd;
			DateTimeType _SecondPeriodEnd = SecondPeriodEnd;
			DateTimeType _ThirdPeriodEnd = ThirdPeriodEnd;
			DateTimeType _FourthPeriodEnd = FourthPeriodEnd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InventoryBalLabelsSp";
				
				appDB.AddCommandParameter(cmd, "FirstPeriodEnd", _FirstPeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SecondPeriodEnd", _SecondPeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ThirdPeriodEnd", _ThirdPeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FourthPeriodEnd", _FourthPeriodEnd, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FirstPeriodEnd = _FirstPeriodEnd;
				SecondPeriodEnd = _SecondPeriodEnd;
				ThirdPeriodEnd = _ThirdPeriodEnd;
				FourthPeriodEnd = _FourthPeriodEnd;
				
				return Severity;
			}
		}
	}
}
