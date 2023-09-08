using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG
{
    public class MGInvoker : IMGInvoker
    {
        IIDOExtensionClassContext context;

        public MGInvoker(IIDOExtensionClassContext context)
        {
            this.context = context;
        }

        public IMGInvokeResponseData Invoke(IMGInvokeRequestData requestData)
        {
            var response = context.Commands.Invoke((requestData as MGInvokeRequestData).InvokeRequestData);
            return new MGInvokeResponseData(response);
        }

        public IMGInvokeResponseData Invoke(string idoName, string methodName, params object[] parameters)
        {
            var response = context.Commands.Invoke(idoName, methodName, parameters);
            return new MGInvokeResponseData(response);
        }
        public IMGLoadCollectionResponseData LoadCollection(string idoName, string methodName, params object[] parameters)
        {
            InvokeParameterList invokeParameters = new InvokeParameterList();
            foreach (object parm in parameters)
                invokeParameters.Add(parm);
            LoadCollectionRequestData loadCollectionRequestData = new LoadCollectionRequestData()
            {
                IDOName = idoName,
                CustomLoadMethod= new CustomLoadMethod()
                { Name =methodName, Parameters = invokeParameters },
                PropertyList = new PropertyList(PropertyListForSpecifiedIDOMethod(idoName,methodName)) //this might be a problem. Hope pass null/empty all properties will be gotten.
            };
            var response = context.Commands.LoadCollection(loadCollectionRequestData);
            return new MGLoadCollectionResponseData(response); 
        }
        private string[] PropertyListForSpecifiedIDOMethod(string ido, string idoMethod)
        {
            IList<string> list = new List<string>();
            LoadCollectionRequestData requestData = new LoadCollectionRequestData()
            {
                IDOName = "IdoMethodResultSets",
                Filter = $"CollectionName = '{ido}' And MethodName = '{idoMethod}' And DevelopmentFlag = 0",
                PropertyList = new PropertyList("PropertyName"),
                OrderBy = "Sequence"
            };
            var response = context.Commands.LoadCollection(requestData);
            foreach (var item in response.Items)
                list.Add(item.PropertyValues[0].Value);
            return list.ToArray();
        }
        public object MethodReturnValueOfInt(IMGInvokeResponseData response) { return response.GetReturnValue<int>(); }
        public object MethodReturnValueOfDataTable(IMGLoadCollectionResponseData responseData) { return responseData.GetReturnValueDataTable(); }
    }
}
