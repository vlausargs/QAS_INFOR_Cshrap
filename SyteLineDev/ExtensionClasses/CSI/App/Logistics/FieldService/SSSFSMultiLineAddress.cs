//PROJECT NAME: Logistics
//CLASS NAME: SSSFSMultiLineAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSMultiLineAddress : ISSSFSMultiLineAddress
	{
		readonly IApplicationDB appDB;
		
		public SSSFSMultiLineAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSMultiLineAddressSp(
			string Contact = null,
			string Name = null,
			string Addr1 = null,
			string Addr2 = null,
			string Addr3 = null,
			string Addr4 = null,
			string CityZip = null,
			string Country = null)
		{
			AddressType _Contact = Contact;
			NameType _Name = Name;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			AddressType _CityZip = CityZip;
			AddressType _Country = Country;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSMultiLineAddressSp](@Contact, @Name, @Addr1, @Addr2, @Addr3, @Addr4, @CityZip, @Country)";
				
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CityZip", _CityZip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
