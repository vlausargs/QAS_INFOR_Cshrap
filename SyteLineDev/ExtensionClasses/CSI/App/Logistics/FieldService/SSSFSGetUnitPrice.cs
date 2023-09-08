//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetUnitPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetUnitPrice : ISSSFSGetUnitPrice
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetUnitPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? FsSaleAmount,
			decimal? FsListAmount) SSSFSGetUnitPriceSp(
			string FsUnitConsCoNum,
			int? FsUnitConsCoLine,
			string InItem,
			decimal? FsSaleAmount,
			decimal? FsListAmount)
		{
			CoNumType _FsUnitConsCoNum = FsUnitConsCoNum;
			CoLineType _FsUnitConsCoLine = FsUnitConsCoLine;
			ItemType _InItem = InItem;
			CostPrcType _FsSaleAmount = FsSaleAmount;
			CostPrcType _FsListAmount = FsListAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSGetUnitPriceSp";
				
				appDB.AddCommandParameter(cmd, "FsUnitConsCoNum", _FsUnitConsCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FsUnitConsCoLine", _FsUnitConsCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InItem", _InItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FsSaleAmount", _FsSaleAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FsListAmount", _FsListAmount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FsSaleAmount = _FsSaleAmount;
				FsListAmount = _FsListAmount;
				
				return (Severity, FsSaleAmount, FsListAmount);
			}
		}
	}
}
