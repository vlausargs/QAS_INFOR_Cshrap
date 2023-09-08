//PROJECT NAME: Data
//CLASS NAME: LaunchCustaddrBODs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LaunchCustaddrBODs : ILaunchCustaddrBODs
	{
		readonly IApplicationDB appDB;
		
		public LaunchCustaddrBODs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LaunchCustaddrBODsSP(
			string PActionExpression,
			int? PBillToPartyMaster,
			int? PPayFromPartyMaster,
			int? PCustomerPartyMaster,
			int? PShipToPartyMaster,
			string PCustNum,
			int? PCustSeq,
			Guid? PCustRowPointer,
			string Infobar)
		{
			StringType _PActionExpression = PActionExpression;
			ListYesNoType _PBillToPartyMaster = PBillToPartyMaster;
			ListYesNoType _PPayFromPartyMaster = PPayFromPartyMaster;
			ListYesNoType _PCustomerPartyMaster = PCustomerPartyMaster;
			ListYesNoType _PShipToPartyMaster = PShipToPartyMaster;
			CustNumType _PCustNum = PCustNum;
			CustSeqType _PCustSeq = PCustSeq;
			RowPointer _PCustRowPointer = PCustRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LaunchCustaddrBODsSP";
				
				appDB.AddCommandParameter(cmd, "PActionExpression", _PActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBillToPartyMaster", _PBillToPartyMaster, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayFromPartyMaster", _PPayFromPartyMaster, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustomerPartyMaster", _PCustomerPartyMaster, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShipToPartyMaster", _PShipToPartyMaster, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustRowPointer", _PCustRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
