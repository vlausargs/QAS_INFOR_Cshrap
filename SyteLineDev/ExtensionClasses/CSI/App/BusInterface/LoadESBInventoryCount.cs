//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBInventoryCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBInventoryCount
	{
		int LoadESBInventoryCountSp(string DocumentID,
		                            string Item,
		                            string Whse,
		                            string Lot,
		                            decimal? HeaderQuantity,
		                            decimal? LineQuantity,
		                            string ISOUMCode,
		                            string HoldCode,
		                            int? Sequence,
		                            int? LineNumber,
		                            DateTime? TransactionDate,
		                            ref string InfoBar);
	}
	
	public class LoadESBInventoryCount : ILoadESBInventoryCount
	{
		readonly IApplicationDB appDB;
		
		public LoadESBInventoryCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBInventoryCountSp(string DocumentID,
		                                   string Item,
		                                   string Whse,
		                                   string Lot,
		                                   decimal? HeaderQuantity,
		                                   decimal? LineQuantity,
		                                   string ISOUMCode,
		                                   string HoldCode,
		                                   int? Sequence,
		                                   int? LineNumber,
		                                   DateTime? TransactionDate,
		                                   ref string InfoBar)
		{
			MarkupElementValueType _DocumentID = DocumentID;
			MarkupElementValueType _Item = Item;
			MarkupElementValueType _Whse = Whse;
			MarkupElementValueType _Lot = Lot;
			DecimalType _HeaderQuantity = HeaderQuantity;
			DecimalType _LineQuantity = LineQuantity;
			MarkupElementValueType _ISOUMCode = ISOUMCode;
			MarkupElementValueType _HoldCode = HoldCode;
			IntType _Sequence = Sequence;
			IntType _LineNumber = LineNumber;
			DateTimeType _TransactionDate = TransactionDate;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBInventoryCountSp";
				
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HeaderQuantity", _HeaderQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineQuantity", _LineQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISOUMCode", _ISOUMCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HoldCode", _HoldCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineNumber", _LineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionDate", _TransactionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
