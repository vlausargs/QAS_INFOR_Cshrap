//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXCreatePckHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXCreatePckHeader : ISSSRMXCreatePckHeader
	{
		readonly IApplicationDB appDB;
		
		public SSSRMXCreatePckHeader(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSRMXCreatePckHeaderSp(
			string TPckCall,
			string RefNum,
			string VendNum,
			string ShipCode,
			int? QtyPackages,
			decimal? Weight,
			DateTime? PackDate,
			string Whse,
			string ProcessId,
			int? PackNum,
			string Infobar)
		{
			StringType _TPckCall = TPckCall;
			RMXRefNumType _RefNum = RefNum;
			VendNumType _VendNum = VendNum;
			ShipCodeType _ShipCode = ShipCode;
			PackagesType _QtyPackages = QtyPackages;
			WeightType _Weight = Weight;
			DateType _PackDate = PackDate;
			WhseType _Whse = Whse;
			InfobarType _ProcessId = ProcessId;
			PackNumType _PackNum = PackNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSRMXCreatePckHeaderSp";
				
				appDB.AddCommandParameter(cmd, "TPckCall", _TPckCall, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPackages", _QtyPackages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Weight", _Weight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackDate", _PackDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
