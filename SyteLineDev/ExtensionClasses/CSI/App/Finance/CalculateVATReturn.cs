//PROJECT NAME: CSIFinance
//CLASS NAME: CalculateVATReturn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface ICalculateVATReturn
	{
		(int? ReturnCode, decimal? Box1TotalSalesVatDue, decimal? Box2TotalAcqVatDue, decimal? Box3TotalVatDue, decimal? Box4TotalReclaimedVat, decimal? Box5NetVatDue, decimal? Box6TotalSalesExVat, decimal? Box7TotalPurchaseExVat, decimal? Box8TotalGoodsSuppliedExVat, decimal? Box9TotalAcqExVat) CalculateVATReturnSp(DateTime? StartDate,
		DateTime? EndDate,
		short? DateStartingOffset = null,
		short? DateEndingOffset = null,
		string TaxJur = null,
		byte? TaxSystem = (byte)1,
		decimal? Box1TotalSalesVatDue = null,
		decimal? Box2TotalAcqVatDue = null,
		decimal? Box3TotalVatDue = null,
		decimal? Box4TotalReclaimedVat = null,
		decimal? Box5NetVatDue = null,
		decimal? Box6TotalSalesExVat = null,
		decimal? Box7TotalPurchaseExVat = null,
		decimal? Box8TotalGoodsSuppliedExVat = null,
		decimal? Box9TotalAcqExVat = null);
	}
	
	public class CalculateVATReturn : ICalculateVATReturn
	{
		readonly IApplicationDB appDB;
		
		public CalculateVATReturn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? Box1TotalSalesVatDue, decimal? Box2TotalAcqVatDue, decimal? Box3TotalVatDue, decimal? Box4TotalReclaimedVat, decimal? Box5NetVatDue, decimal? Box6TotalSalesExVat, decimal? Box7TotalPurchaseExVat, decimal? Box8TotalGoodsSuppliedExVat, decimal? Box9TotalAcqExVat) CalculateVATReturnSp(DateTime? StartDate,
		DateTime? EndDate,
		short? DateStartingOffset = null,
		short? DateEndingOffset = null,
		string TaxJur = null,
		byte? TaxSystem = (byte)1,
		decimal? Box1TotalSalesVatDue = null,
		decimal? Box2TotalAcqVatDue = null,
		decimal? Box3TotalVatDue = null,
		decimal? Box4TotalReclaimedVat = null,
		decimal? Box5NetVatDue = null,
		decimal? Box6TotalSalesExVat = null,
		decimal? Box7TotalPurchaseExVat = null,
		decimal? Box8TotalGoodsSuppliedExVat = null,
		decimal? Box9TotalAcqExVat = null)
		{
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			DateOffsetType _DateStartingOffset = DateStartingOffset;
			DateOffsetType _DateEndingOffset = DateEndingOffset;
			TaxJurType _TaxJur = TaxJur;
			TaxSystemType _TaxSystem = TaxSystem;
			AmountType _Box1TotalSalesVatDue = Box1TotalSalesVatDue;
			AmountType _Box2TotalAcqVatDue = Box2TotalAcqVatDue;
			AmountType _Box3TotalVatDue = Box3TotalVatDue;
			AmountType _Box4TotalReclaimedVat = Box4TotalReclaimedVat;
			AmountType _Box5NetVatDue = Box5NetVatDue;
			AmountType _Box6TotalSalesExVat = Box6TotalSalesExVat;
			AmountType _Box7TotalPurchaseExVat = Box7TotalPurchaseExVat;
			AmountType _Box8TotalGoodsSuppliedExVat = Box8TotalGoodsSuppliedExVat;
			AmountType _Box9TotalAcqExVat = Box9TotalAcqExVat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalculateVATReturnSp";
				
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingOffset", _DateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEndingOffset", _DateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxJur", _TaxJur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxSystem", _TaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Box1TotalSalesVatDue", _Box1TotalSalesVatDue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Box2TotalAcqVatDue", _Box2TotalAcqVatDue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Box3TotalVatDue", _Box3TotalVatDue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Box4TotalReclaimedVat", _Box4TotalReclaimedVat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Box5NetVatDue", _Box5NetVatDue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Box6TotalSalesExVat", _Box6TotalSalesExVat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Box7TotalPurchaseExVat", _Box7TotalPurchaseExVat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Box8TotalGoodsSuppliedExVat", _Box8TotalGoodsSuppliedExVat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Box9TotalAcqExVat", _Box9TotalAcqExVat, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Box1TotalSalesVatDue = _Box1TotalSalesVatDue;
				Box2TotalAcqVatDue = _Box2TotalAcqVatDue;
				Box3TotalVatDue = _Box3TotalVatDue;
				Box4TotalReclaimedVat = _Box4TotalReclaimedVat;
				Box5NetVatDue = _Box5NetVatDue;
				Box6TotalSalesExVat = _Box6TotalSalesExVat;
				Box7TotalPurchaseExVat = _Box7TotalPurchaseExVat;
				Box8TotalGoodsSuppliedExVat = _Box8TotalGoodsSuppliedExVat;
				Box9TotalAcqExVat = _Box9TotalAcqExVat;
				
				return (Severity, Box1TotalSalesVatDue, Box2TotalAcqVatDue, Box3TotalVatDue, Box4TotalReclaimedVat, Box5NetVatDue, Box6TotalSalesExVat, Box7TotalPurchaseExVat, Box8TotalGoodsSuppliedExVat, Box9TotalAcqExVat);
			}
		}
	}
}
