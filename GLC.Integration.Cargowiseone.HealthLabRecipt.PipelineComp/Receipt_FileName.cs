using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO.Compression;
using System.IO;
using Microsoft.BizTalk.Message.Interop;
using Microsoft.BizTalk.Component.Interop;

namespace GLC.Integration.Cargowiseone.ClassicWatch.PipelineComp
{
    [Serializable]
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    [System.Runtime.InteropServices.Guid("08D8DE79-2AF6-4603-8DEB-4B393A93F8BF")]
    public class Receipt_FileName : IBaseComponent, IComponent, IComponentUI
    {
        #region IBaseComponent

        /// <summary>
        /// Name of the component.
        /// </summary>
        //[Browsable(false)]
        public string Name
        {
            get { return "ReceiptFileName"; }
        }

        /// <summary>
        /// Version of the component.
        /// </summary>
        //[Browsable(false)]
        public string Version
        {
            get { return "1.0"; }
        }

        /// <summary>
        /// Description of the component.
        /// </summary>
        // [Browsable(false)]
        public string Description
        {
            get { return "ReceiptFileName"; }
        }

        #endregion
        #region IComponentUI
        public IntPtr Icon
        {
            get
            {
                return new System.IntPtr();
            }
        }

        public System.Collections.IEnumerator Validate(object projectSystem)
        {
            return null;
        }
        #endregion
        #region IComponent

        public Microsoft.BizTalk.Message.Interop.IBaseMessage Execute(Microsoft.BizTalk.Component.Interop.IPipelineContext pc, Microsoft.BizTalk.Message.Interop.IBaseMessage inmsg)
        {
            IBaseMessageContext context = inmsg.Context;
            Stream originalDataStream = inmsg.BodyPart.GetOriginalDataStream();
            string xml = new StreamReader(originalDataStream).ReadToEnd();
            DateTime now = new DateTime();
            now = DateTime.Now;
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            string configfile = File.ReadAllText(@"C:\eAdapterOutbound\Reciptcount_File\Receipt_Count.txt");

            string[] configval = configfile.Split(',');

            int reciptcnt = Convert.ToInt32(configval[0]);

            string reciptdate = configval[1];

            if(now.ToString("ddMMyyyy")==reciptdate)
            {
                reciptcnt = reciptcnt + 1;
            }

            else
            {
                reciptdate = now.ToString("ddMMyyyy");
                reciptcnt = 1;
            }

            string strval = reciptcnt + "," + reciptdate;

            File.WriteAllText(@"C:\eAdapterOutbound\Reciptcount_File\Receipt_Count.txt", strval);

            string str3 = "RECEIPT_REPORT" + "_" + now.ToString("ddMMyyyy")+"_" + reciptcnt;
            context.Promote("ReceivedFileName", "http://schemas.microsoft.com/BizTalk/2003/file-properties", str3);
            originalDataStream.Seek(0L, SeekOrigin.Begin);
            inmsg.BodyPart.Data = originalDataStream;
            inmsg.Context = context;
            return inmsg;
        }
        #endregion

    }
}


