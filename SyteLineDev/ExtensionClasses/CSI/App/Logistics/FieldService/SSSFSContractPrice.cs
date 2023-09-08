//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContractPrice : ISSSFSContractPrice
	{
		readonly IApplicationDB appDB;
		
		public SSSFSContractPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? OutUnitPrice) SSSFSContractPriceSp(
			string InType,
			string InSroNum,
			int? InSroLine,
			DateTime? InTransDate,
			string InWorkItem,
			decimal? OutUnitPrice)
		{
			FSSRONumType _InType = InType;
			FSSRONumType _InSroNum = InSroNum;
			FSSROLineType _InSroLine = InSroLine;
			CurrentDateType _InTransDate = InTransDate;
			ItemType _InWorkItem = InWorkItem;
			CostPrcType _OutUnitPrice = OutUnitPrice;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContractPriceSp";
				
				appDB.AddCommandParameter(cmd, "InType", _InType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSroNum", _InSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSroLine", _InSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InTransDate", _InTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InWorkItem", _InWorkItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutUnitPrice", _OutUnitPrice, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutUnitPrice = _OutUnitPrice;
				
				return (Severity, OutUnitPrice);
			}
		}
	}
}
