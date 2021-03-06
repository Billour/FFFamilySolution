//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace System.Xml
{
    using Microsoft.Http;

    public static class XmlContentExtensions
    {
        public static XmlReader ReadAsXmlReader(this HttpContent content)
        {
            var settings = new XmlReaderSettings()
                {
                    CloseInput = true,
                    ConformanceLevel = ConformanceLevel.Auto,
                    MaxCharactersInDocument = 0,
                    IgnoreWhitespace = true,
                    IgnoreProcessingInstructions = true,

                    //NOTE CHANGED CONFIGURATION IN SL CLIENT
//                    ProhibitDtd = true,
                    DtdProcessing = DtdProcessing.Prohibit
                    
                };

            return ReadAsXmlReader(content, settings);
        }

        public static XmlReader ReadAsXmlReader(this HttpContent content, XmlReaderSettings settings)
        {
            return XmlReader.Create(content.ReadAsStream(), settings);
        }
    }
}
