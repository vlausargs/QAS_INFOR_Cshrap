//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBReceiveShippingLoop.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBReceiveShippingLoop
	{
		int LoadESBReceiveShippingLoopSp(string DocumentIDName,
		                                 string BODNOUN,
		                                 string BODVERB,
		                                 string DocumentID,
		                                 string LineNumber,
		                                 decimal? QtyShipped,
		                                 string QtyShippedISOUM,
		                                 string Item,
		                                 decimal? OrderQty,
		                                 string ISOUM,
		                                 decimal? EstimatedWeight,
		                                 string EstimatedWeightISOUM,
		                                 string PurchaseOrderRef,
		                                 int? PurchaseOrderLine,
		                                 int? PurchaseOrderRelease,
		                                 decimal? PurchaseOrderQty,
		                                 string PurchaseOrderISOUM,
		                                 string SalesOrderRef,
		                                 int? SalesOrderRelease,
		                                 int? SalesOrderLine,
		                                 decimal? SalesOrderQty,
		                                 string SalesOrderISOUM,
		                                 string RefNum,
		                                 short? RefLine,
		                                 int? RefProdOrderSequence,
		                                 int? RefOperationID,
		                                 string RefConsumedItemLineNum,
		                                 string RefOutputItemLineNum,
		                                 short? RefRelease,
		                                 string SerializedLotID,
		                                 DateTime? SerializedLotExpDate,
		                                 string HoldCode,
		                                 decimal? CountSequence,
		                                 DateTime? ReceivedDateTime,
		                                 string WareHouse,
		                                 string Status,
		                                 ref string InfoBar);
	}
	
	public class LoadESBReceiveShippingLoop : ILoadESBReceiveShippingLoop
	{
		readonly IApplicationDB appDB;
		
		public LoadESBReceiveShippingLoop(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBReceiveShippingLoopSp(string DocumentIDName,
		                                        string BODNOUN,
		                                        string BODVERB,
		                                        string DocumentID,
		                                        string LineNumber,
		                                        decimal? QtyShipped,
		                                        string QtyShippedISOUM,
		                                        string Item,
		                                        decimal? OrderQty,
		                                        string ISOUM,
		                                        decimal? EstimatedWeight,
		                                        string EstimatedWeightISOUM,
		                                        string PurchaseOrderRef,
		                                        int? PurchaseOrderLine,
		                                        int? PurchaseOrderRelease,
		                                        decimal? PurchaseOrderQty,
		                                        string PurchaseOrderISOUM,
		                                        string SalesOrderRef,
		                                        int? SalesOrderRelease,
		                                        int? SalesOrderLine,
		                                        decimal? SalesOrderQty,
		                                        string SalesOrderISOUM,
		                                        string RefNum,
		                                        short? RefLine,
		                                        int? RefProdOrderSequence,
		                                        int? RefOperationID,
		                                        string RefConsumedItemLineNum,
		                                        string RefOutputItemLineNum,
		                                        short? RefRelease,
		                                        string SerializedLotID,
		                                        DateTime? SerializedLotExpDate,
		                                        string HoldCode,
		                                        decimal? CountSequence,
		                                        DateTime? ReceivedDateTime,
		                                        string WareHouse,
		                                        string Status,
		                                        ref string InfoBar)
		{
			StringType _DocumentIDName = DocumentIDName;
			StringType _BODNOUN = BODNOUN;
			StringType _BODVERB = BODVERB;
			StringType _DocumentID = DocumentID;
			StringType _LineNumber = LineNumber;
			DecimalType _QtyShipped = QtyShipped;
			UMType _QtyShippedISOUM = QtyShippedISOUM;
			ItemType _Item = Item;
			QtyUnitType _OrderQty = OrderQty;
			UMType _ISOUM = ISOUM;
			DecimalType _EstimatedWeight = EstimatedWeight;
			UMType _EstimatedWeightISOUM = EstimatedWeightISOUM;
			StringType _PurchaseOrderRef = PurchaseOrderRef;
			IntType _PurchaseOrderLine = PurchaseOrderLine;
			IntType _PurchaseOrderRelease = PurchaseOrderRelease;
			DecimalType _PurchaseOrderQty = PurchaseOrderQty;
			UMType _PurchaseOrderISOUM = PurchaseOrderISOUM;
			StringType _SalesOrderRef = SalesOrderRef;
			IntType _SalesOrderRelease = SalesOrderRelease;
			IntType _SalesOrderLine = SalesOrderLine;
			DecimalType _SalesOrderQty = SalesOrderQty;
			UMType _SalesOrderISOUM = SalesOrderISOUM;
			EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
			CoLineSuffixPoLineProjTaskRmaTrnLineType _RefLine = RefLine;
			IntType _RefProdOrderSequence = RefProdOrderSequence;
			IntType _RefOperationID = RefOperationID;
			StringType _RefConsumedItemLineNum = RefConsumedItemLineNum;
			StringType _RefOutputItemLineNum = RefOutputItemLineNum;
			CoReleaseOperNumPoReleaseType _RefRelease = RefRelease;
			StringType _SerializedLotID = SerializedLotID;
            DateTimeType _SerializedLotExpDate = SerializedLotExpDate;
			StringType _HoldCode = HoldCode;
			DecimalType _CountSequence = CountSequence;
			DateTimeType _ReceivedDateTime = ReceivedDateTime;
			StringType _WareHouse = WareHouse;
			StringType _Status = Status;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBReceiveShippingLoopSp";
				
				appDB.AddCommandParameter(cmd, "DocumentIDName", _DocumentIDName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BODNOUN", _BODNOUN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BODVERB", _BODVERB, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineNumber", _LineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyShippedISOUM", _QtyShippedISOUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderQty", _OrderQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISOUM", _ISOUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstimatedWeight", _EstimatedWeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstimatedWeightISOUM", _EstimatedWeightISOUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurchaseOrderRef", _PurchaseOrderRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurchaseOrderLine", _PurchaseOrderLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurchaseOrderRelease", _PurchaseOrderRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurchaseOrderQty", _PurchaseOrderQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurchaseOrderISOUM", _PurchaseOrderISOUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesOrderRef", _SalesOrderRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesOrderRelease", _SalesOrderRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesOrderLine", _SalesOrderLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesOrderQty", _SalesOrderQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesOrderISOUM", _SalesOrderISOUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefProdOrderSequence", _RefProdOrderSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefOperationID", _RefOperationID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefConsumedItemLineNum", _RefConsumedItemLineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefOutputItemLineNum", _RefOutputItemLineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerializedLotID", _SerializedLotID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerializedLotExpDate", _SerializedLotExpDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HoldCode", _HoldCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CountSequence", _CountSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceivedDateTime", _ReceivedDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WareHouse", _WareHouse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
