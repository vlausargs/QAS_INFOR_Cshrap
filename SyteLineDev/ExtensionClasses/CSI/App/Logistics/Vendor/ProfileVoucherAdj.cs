//PROJECT NAME: CSIVendor
//CLASS NAME: ProfileVoucherAdj.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IProfileVoucherAdj
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileVoucherAdjSp(string VendorStarting = null,
		string VendorEnding = null,
		int? VoucherStarting = null,
		int? VoucherEnding = null,
		string PoNumStarting = null,
		string PoNumEnding = null,
		string InvNumStarting = null,
		string InvNumEnding = null,
		DateTime? VoucherDateStarting = null,
		DateTime? VoucherDateEnding = null,
		short? VoucherDateStartingOffset = null,
		short? VoucherDateEndingOffset = null,
		byte? VoucherDateIncrement = (byte)0,
		string VoucherTypeVoucher = null,
		string VoucherTypeDebitMemo = null);
	}
	
	public class ProfileVoucherAdj : IProfileVoucherAdj
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileVoucherAdj(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileVoucherAdjSp(string VendorStarting = null,
		string VendorEnding = null,
		int? VoucherStarting = null,
		int? VoucherEnding = null,
		string PoNumStarting = null,
		string PoNumEnding = null,
		string InvNumStarting = null,
		string InvNumEnding = null,
		DateTime? VoucherDateStarting = null,
		DateTime? VoucherDateEnding = null,
		short? VoucherDateStartingOffset = null,
		short? VoucherDateEndingOffset = null,
		byte? VoucherDateIncrement = (byte)0,
		string VoucherTypeVoucher = null,
		string VoucherTypeDebitMemo = null)
		{
			VendNumType _VendorStarting = VendorStarting;
			VendNumType _VendorEnding = VendorEnding;
			VoucherType _VoucherStarting = VoucherStarting;
			VoucherType _VoucherEnding = VoucherEnding;
			PoNumType _PoNumStarting = PoNumStarting;
			PoNumType _PoNumEnding = PoNumEnding;
			InvNumType _InvNumStarting = InvNumStarting;
			InvNumType _InvNumEnding = InvNumEnding;
			DateType _VoucherDateStarting = VoucherDateStarting;
			DateType _VoucherDateEnding = VoucherDateEnding;
			DateOffsetType _VoucherDateStartingOffset = VoucherDateStartingOffset;
			DateOffsetType _VoucherDateEndingOffset = VoucherDateEndingOffset;
			ListYesNoType _VoucherDateIncrement = VoucherDateIncrement;
			StringType _VoucherTypeVoucher = VoucherTypeVoucher;
			StringType _VoucherTypeDebitMemo = VoucherTypeDebitMemo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileVoucherAdjSp";
				
				appDB.AddCommandParameter(cmd, "VendorStarting", _VendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorEnding", _VendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherStarting", _VoucherStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherEnding", _VoucherEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNumStarting", _PoNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNumEnding", _PoNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumStarting", _InvNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumEnding", _InvNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateStarting", _VoucherDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateEnding", _VoucherDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateStartingOffset", _VoucherDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateEndingOffset", _VoucherDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherDateIncrement", _VoucherDateIncrement, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherTypeVoucher", _VoucherTypeVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VoucherTypeDebitMemo", _VoucherTypeDebitMemo, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
