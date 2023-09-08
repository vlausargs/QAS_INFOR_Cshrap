//PROJECT NAME: Logistics
//CLASS NAME: WirePostValidateCloseForm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class WirePostValidateCloseForm : IWirePostValidateCloseForm
	{
		readonly IApplicationDB appDB;
		
		
		public WirePostValidateCloseForm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) WirePostValidateCloseFormSp(Guid? PSessionID,
		string AppmtPayType,
		int? bRemitAdvicePrint,
		string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			AppmtPayTypeType _AppmtPayType = AppmtPayType;
			ListYesNoType _bRemitAdvicePrint = bRemitAdvicePrint;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "WirePostValidateCloseFormSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtPayType", _AppmtPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bRemitAdvicePrint", _bRemitAdvicePrint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
