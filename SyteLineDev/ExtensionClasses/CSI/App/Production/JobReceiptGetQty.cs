//PROJECT NAME: CSIProduct
//CLASS NAME: JobReceiptGetQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IJobReceiptGetQty
	{
		int JobReceiptGetQtySp(string Job,
		                       short? Suffix,
		                       string Item,
		                       int? OperNum,
		                       ref decimal? QtyMoved,
		                       ref decimal? QtyComplete,
		                       ref string ItemSerialPrefix,
		                       ref string Infobar);
	}
	
	public class JobReceiptGetQty : IJobReceiptGetQty
	{
		readonly IApplicationDB appDB;
		
		public JobReceiptGetQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int JobReceiptGetQtySp(string Job,
		                              short? Suffix,
		                              string Item,
		                              int? OperNum,
		                              ref decimal? QtyMoved,
		                              ref decimal? QtyComplete,
		                              ref string ItemSerialPrefix,
		                              ref string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ItemType _Item = Item;
			OperNumType _OperNum = OperNum;
			QtyUnitType _QtyMoved = QtyMoved;
			QtyUnitType _QtyComplete = QtyComplete;
			SerialPrefixType _ItemSerialPrefix = ItemSerialPrefix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobReceiptGetQtySp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyMoved", _QtyMoved, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyComplete", _QtyComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialPrefix", _ItemSerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyMoved = _QtyMoved;
				QtyComplete = _QtyComplete;
				ItemSerialPrefix = _ItemSerialPrefix;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
