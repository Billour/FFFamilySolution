using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Microsoft.ServiceModel.Dispatcher;
using Microsoft.ServiceModel.Http;

namespace FFSilverlight.Web.Common
{
    /// <summary>
    /// Configuration Management
    /// </summary>
    public class RestfulConfigurationManager : HostConfiguration
    {
        public override void RegisterRequestProcessorsForOperation(HttpOperationDescription operation, IList<Processor> processors, MediaTypeProcessorMode mode)
        {
            processors.ClearMediaTypeProcessors();
            //processors.Add(new FormUrlEncodedProcessor(operation, mode));
            processors.Add(new JsonProcessor(operation, mode));
           
        }

        public override void RegisterResponseProcessorsForOperation(HttpOperationDescription operation, IList<Processor> processors, MediaTypeProcessorMode mode)
        {
            processors.ClearMediaTypeProcessors();
            processors.Add(new JsonProcessor(operation, mode));
            
        }
    }
}