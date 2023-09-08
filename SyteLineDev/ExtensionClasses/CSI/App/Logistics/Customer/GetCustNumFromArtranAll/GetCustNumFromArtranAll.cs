using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;
using CSI.Data.CRUD;
using CSI.Data;
using CSI.Data.Utilities;
using CSI.CRUD.Logistics.Customer;

namespace CSI.Logistics.Customer
{
    public interface IGetCustNumFromArtranAll
    {
        int GetCustNumFromArtranAllSp(string InvNum,
                                      string Site,
                                      ref string CustNum);
    }

    public class GetCustNumFromArtranAll : IGetCustNumFromArtranAll
    {
        readonly IMessageProvider messageProvider;
        readonly IGetCustNumFromArtranAllCRUD getCustNumFromArtranAllCRUD;
        readonly StringUtil stringUtil;

        public GetCustNumFromArtranAll(IMessageProvider messageProvider,
                                     IGetCustNumFromArtranAllCRUD getCustNumFromArtranAllCRUD,
                                     StringUtil stringUtil)
        {
            this.messageProvider = messageProvider ?? throw new ArgumentNullException(nameof(messageProvider));
            this.getCustNumFromArtranAllCRUD = getCustNumFromArtranAllCRUD ?? throw new ArgumentNullException(nameof(getCustNumFromArtranAllCRUD));
            this.stringUtil = stringUtil ?? throw new ArgumentNullException(nameof(stringUtil));
        }

        public int GetCustNumFromArtranAllSp(string InvNum,
                                             string Site,
                                             ref string CustNum)
        {
            int Severity = 0;

            if (InvNum != null)
            {
                 CustNum = getCustNumFromArtranAllCRUD.GetCustNum(InvNum, Site);
            }

            return Severity;
        }
    }
}
