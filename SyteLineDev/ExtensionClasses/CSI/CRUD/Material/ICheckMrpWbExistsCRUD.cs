//PROJECT NAME: Material
//CLASS NAME: ICheckMrpWbExistsCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICheckMrpWbExistsCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(int? MrpWbExists, int? rowCount) Mrp_WbLoad(string FromItem, string ToItem, int? MrpWbExists);
		(int? ReturnCode, int? MrpWbExists, string Infobar) AltExtGen_CheckMrpWbExistsSp(string AltExtGenSp, string FromItem, string ToItem, int? MrpWbExists, string Infobar);
	}
}

