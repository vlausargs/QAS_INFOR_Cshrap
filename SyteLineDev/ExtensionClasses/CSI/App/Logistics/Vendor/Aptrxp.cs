//PROJECT NAME: Logistics
//CLASS NAME: Aptrxp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class Aptrxp : IAptrxp
	{
		readonly IApplicationDB appDB;
		
		
		public Aptrxp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PostExtFin,
		decimal? ExtFinOperationCounter,
		string Infobar) AptrxpSp(string PVendNum,
		int? PVoucher,
		Guid? PSessionID,
		int? PostExtFin,
		decimal? ExtFinOperationCounter,
		string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			VoucherType _PVoucher = PVoucher;
			RowPointerType _PSessionID = PSessionID;
			ListYesNoType _PostExtFin = PostExtFin;
			OperationCounterType _ExtFinOperationCounter = ExtFinOperationCounter;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AptrxpSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostExtFin", _PostExtFin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtFinOperationCounter", _ExtFinOperationCounter, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PostExtFin = _PostExtFin;
				ExtFinOperationCounter = _ExtFinOperationCounter;
				Infobar = _Infobar;
				
				return (Severity, PostExtFin, ExtFinOperationCounter, Infobar);
			}
		}
	}
}
