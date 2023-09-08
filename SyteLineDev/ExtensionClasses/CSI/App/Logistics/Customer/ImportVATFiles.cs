//PROJECT NAME: Logistics
//CLASS NAME: ImportVATFiles.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ImportVATFiles : IImportVATFiles
	{
		readonly IApplicationDB appDB;
		
		
		public ImportVATFiles(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ImportVATFilesSp(int? PAction,
		string PInvNum,
		string PVATInvNum,
		decimal? PVATSalesTax,
		decimal? PSalesTax)
		{
			ListYesNoType _PAction = PAction;
			InvNumType _PInvNum = PInvNum;
			InvNumType _PVATInvNum = PVATInvNum;
			AmountType _PVATSalesTax = PVATSalesTax;
			AmountType _PSalesTax = PSalesTax;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ImportVATFilesSp";
				
				appDB.AddCommandParameter(cmd, "PAction", _PAction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVATInvNum", _PVATInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVATSalesTax", _PVATSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
