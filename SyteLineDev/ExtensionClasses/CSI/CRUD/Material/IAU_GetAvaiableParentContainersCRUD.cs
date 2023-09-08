//PROJECT NAME: Material
//CLASS NAME: IAU_GetAvaiableParentContainersCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IAU_GetAvaiableParentContainersCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse SelectOptional_ModuleForInsert();
		void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName);
		ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName);
		void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		ICollectionLoadResponse SelectTv_Tmp_ContainerForInsert(string ContainerNum);
		void InsertTv_Tmp_Container(ICollectionLoadResponse tv_tmp_containerLoadResponse);
		ICollectionLoadResponse SelectContainer(string Whse, string Loc);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_AU_GetAvaiableParentContainersSp(string AltExtGenSp, string ContainerNum, string Whse, string Loc);
	}
}

