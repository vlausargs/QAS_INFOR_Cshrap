//PROJECT NAME: Logistics
//CLASS NAME: VoucherBuilderTaxDistribution.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherBuilderTaxDistribution : IVoucherBuilderTaxDistribution
	{
		readonly IApplicationDB appDB;
		
		public VoucherBuilderTaxDistribution(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar) VoucherBuilderTaxDistributionSp(
			Guid? PProcessId,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar,
			string ParmsSite)
		{
			RowPointerType _PProcessId = PProcessId;
			AmountType _PSalesTax1 = PSalesTax1;
			AmountType _PSalesTax2 = PSalesTax2;
			InfobarType _Infobar = Infobar;
			SiteType _ParmsSite = ParmsSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoucherBuilderTaxDistributionSp";
				
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax1", _PSalesTax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSalesTax1 = _PSalesTax1;
				PSalesTax2 = _PSalesTax2;
				Infobar = _Infobar;
				
				return (Severity, PSalesTax1, PSalesTax2, Infobar);
			}
		}
	}
}
