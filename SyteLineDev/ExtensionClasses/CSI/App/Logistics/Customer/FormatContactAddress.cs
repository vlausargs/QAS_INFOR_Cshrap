//PROJECT NAME: CSICustomer
//CLASS NAME: FormatContactAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IFormatContactAddress
	{
		int FormatContactAddressSp(string ContactId,
		                           ref string ContactAddress,
		                           ref string Infobar);

		string FormatContactAddressFn(
			string ContactId);
	}
	
	public class FormatContactAddress : IFormatContactAddress
	{
		readonly IApplicationDB appDB;
		
		public FormatContactAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FormatContactAddressSp(string ContactId,
		                                  ref string ContactAddress,
		                                  ref string Infobar)
		{
			ContactIDType _ContactId = ContactId;
			LongAddress _ContactAddress = ContactAddress;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FormatContactAddressSp";
				
				appDB.AddCommandParameter(cmd, "ContactId", _ContactId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContactAddress", _ContactAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ContactAddress = _ContactAddress;
				Infobar = _Infobar;
				
				return Severity;
			}
		}

		public string FormatContactAddressFn(
			string ContactId)
		{
			ContactIDType _ContactId = ContactId;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatContactAddress](@ContactId)";

				appDB.AddCommandParameter(cmd, "ContactId", _ContactId, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
