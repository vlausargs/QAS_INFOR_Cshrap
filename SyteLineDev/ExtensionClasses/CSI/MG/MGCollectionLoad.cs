using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.MG;
using Mongoose.Core.Common;
using Mongoose.IDO;
using Mongoose.IDO.DataAccess;
using CSI.Data.CRUD;
using CSI.Data.SQL;

namespace CSI.MG
{
    public class MGCollectionLoad : ICollectionLoad
    {
        IIDOExtensionClassContext context;
        ILoadRequestVariablesUpdate loadRequestVariablesUpdate;

        public MGCollectionLoad(IIDOExtensionClassContext context, ILoadRequestVariablesUpdate loadRequestVariablesUpdate)
        {
            this.context = context;
            this.loadRequestVariablesUpdate = loadRequestVariablesUpdate;
        }

        public ICollectionLoadResponse Load(ICollectionLoadRequest loadRequest)
        {
            //mongoose load ==============================================================
            LoadCollectionRequestData oCollection = new LoadCollectionRequestData();
            oCollection.IDOName = loadRequest.IDOName;
            oCollection.PropertyList = new PropertyList(string.Join(", ", loadRequest.RequestedColumns));
            oCollection.Filter = loadRequest.IDOWhereClause;
            oCollection.RecordCap = loadRequest.MaximumRows;
            var oResponse = context.Commands.LoadCollection(oCollection);
           
            //oResponse[0, ""].GetValue<decimal>(0);
            var response = new MGCollectionLoadResponse(oResponse);

            loadRequestVariablesUpdate.UpdateRequestVariables(response, loadRequest.ColumnNameByVariableToAssign);

            return response;
        }
    }
}
