//PROJECT NAME: Finance
//CLASS NAME: ApActive.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AP
{
	public class ApActive : IApActive
	{
		readonly IApplicationDB appDB;
		
		public ApActive(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ApActiveSp(
			string PVendNum,
			int? PVoucher,
			string PParmsCurrCode,
			int? PCurrPlaces,
			string PApParmsInvDue,
			string PNonApOption,
			int? PNewValueFlag,
			int? PRetrieveMsgs = 0,
			string Infobar = null,
			int? BufferUpdates = 0)
		{
			VendNumType _PVendNum = PVendNum;
			VoucherType _PVoucher = PVoucher;
			CurrCodeType _PParmsCurrCode = PParmsCurrCode;
			DecimalPlacesType _PCurrPlaces = PCurrPlaces;
			ApAgeByType _PApParmsInvDue = PApParmsInvDue;
			LongListType _PNonApOption = PNonApOption;
			FlagNyType _PNewValueFlag = PNewValueFlag;
			FlagNyType _PRetrieveMsgs = PRetrieveMsgs;
			InfobarType _Infobar = Infobar;
			ListYesNoType _BufferUpdates = BufferUpdates;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApActiveSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PParmsCurrCode", _PParmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrPlaces", _PCurrPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApParmsInvDue", _PApParmsInvDue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNonApOption", _PNonApOption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewValueFlag", _PNewValueFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRetrieveMsgs", _PRetrieveMsgs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BufferUpdates", _BufferUpdates, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
