using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GLC.Integration.Cargowiseone.HealthLabRecipt.PipelineComp
{
    [Serializable]
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    [System.Runtime.InteropServices.Guid("00372DEC-0806-428F-8EFD-BBE302842E69")]


    public class DebatchFFInbound : IBaseComponent, IComponent, IComponentUI
    {
        #region IBaseComponent

        /// <summary>
        /// Name of the component.
        /// </summary>
        //[Browsable(false)]
        public string Name
        {
            get { return "DebatchFFInbound"; }
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
            get { return "Debatching HealthLab Recipt Flat Files"; }
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
            IBaseMessageContext messageContext = inmsg.Context;
            Stream originalStream = inmsg.BodyPart.GetOriginalDataStream();
            StreamReader strmread = new StreamReader(originalStream);
            string data = strmread.ReadToEnd();

            data = data.Replace(@"http://GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Inbound.RecReciptFFMaster", "");
            string strxml = "";

            var reciptno = new List<string>();            
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(data);

            

            XmlNodeList xmlnode = xdoc.SelectNodes("HLReciptMaster/HLReciptMaster_Child1");


            foreach (XmlNode node in xmlnode)
            {
                var strcod = node.SelectSingleNode("HLReciptMaster_Child1_Child3").InnerText;
                reciptno.Add(strcod);
            }
            List<string> mylist = reciptno.Distinct().ToList();


            string filepath;
            int cnt = mylist.Count();
            string strxml1 = "";
            string strfinalxml = "";
            for (int i = 0; i < cnt; i++)
            {
                string codeval = mylist[i];
                string headerxml = "";                
                foreach (XmlNode node in xmlnode)
                {
                    string reciptid= node.SelectSingleNode("HLReciptMaster_Child1_Child3").InnerText;
                    string recipttyp = node.SelectSingleNode("HLReciptMaster_Child1_Child1").InnerText;


                    if (codeval == reciptid)
                    {
                        if (recipttyp == "RCH")
                        {
                            headerxml = node.OuterXml.ToString();

                        }
                    }

                    if (codeval == reciptid)
                    {
                        if (recipttyp != "RCH")
                        {
                            strxml1 = strxml1 + node.OuterXml.ToString();
                        }
                    }

                }

                strfinalxml = "<HLReciptDebatched>" + headerxml + strxml1 + " </HLReciptDebatched>";
                filepath = @"C:\HLReciptDebatched\" + codeval + "_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xml";
                strxml1 = "";
                File.WriteAllText(filepath, strfinalxml);
            }


            byte[] bytearray = Encoding.UTF8.GetBytes(strxml);
            MemoryStream strm = new MemoryStream(bytearray);
            originalStream = strm;
            originalStream.Seek(0, SeekOrigin.Begin);
            inmsg.BodyPart.Data = originalStream;
            inmsg.Context = messageContext;
            return inmsg;
        }
        #endregion

    }
}
