//PROJECT NAME: Production
//CLASS NAME: IApsUpdateActiveBGTasksCRUD.cs

using CSI.Data.CRUD;

namespace CSI.Production.APS
{
	public interface IApsUpdateActiveBGTasksCRUD
	{
		ICollectionLoadResponse Aps_parm_Select();
		void ActiveBGTasks_Update(string site_ref, string sReplace);
	}
}

