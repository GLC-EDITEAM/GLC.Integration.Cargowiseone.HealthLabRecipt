namespace GLC.Integration.Cargowiseone.HealthLabRecipt.Pipeline
{
    using System;
    using System.Collections.Generic;
    using Microsoft.BizTalk.PipelineOM;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Component.Interop;
    
    
    public sealed class SendReceiptCSV : Microsoft.BizTalk.PipelineOM.SendPipeline
    {
        
        private const string _strPipeline = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Document xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instanc"+
"e\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" MajorVersion=\"1\" MinorVersion=\"0\">  <Description /> "+
" <CategoryId>8c6b051c-0ff5-4fc2-9ae5-5016cb726282</CategoryId>  <FriendlyName>Transmit</FriendlyName"+
">  <Stages>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"1\" Name=\"Pre-Assemble\" minO"+
"ccurs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4101-4cce-4536-83fa-4a5040674ad6\" />      <Co"+
"mponents>        <Component>          <Name>GLC.Integration.Cargowiseone.ClassicWatch.PipelineComp.R"+
"eceipt_FileName,GLC.Integration.Cargowiseone.HealthLabRecipt.PipelineComp, Version=1.0.0.0, Culture="+
"neutral, PublicKeyToken=0e4207ba20eea07f</Name>          <ComponentName>ReceiptFileName</ComponentNa"+
"me>          <Description>ReceiptFileName</Description>          <Version>1.0</Version>          <Pr"+
"operties />          <CachedDisplayName>ReceiptFileName</CachedDisplayName>          <CachedIsManage"+
"d>true</CachedIsManaged>        </Component>      </Components>    </Stage>    <Stage>      <PolicyF"+
"ileStage _locAttrData=\"Name\" _locID=\"2\" Name=\"Assemble\" minOccurs=\"0\" maxOccurs=\"1\" execMethod=\"All\""+
" stageId=\"9d0e4107-4cce-4536-83fa-4a5040674ad6\" />      <Components>        <Component>          <Na"+
"me>Microsoft.BizTalk.Component.FFAsmComp,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Cul"+
"ture=neutral, PublicKeyToken=31bf3856ad364e35</Name>          <ComponentName>Flat file assembler</Co"+
"mponentName>          <Description>Flat file assembler component.</Description>          <Version>1."+
"0</Version>          <Properties>            <Property Name=\"HeaderSpecName\" />            <Property"+
" Name=\"DocumentSpecName\">              <Value xsi:type=\"xsd:string\">GLC.Integration.Cargowiseone.Hea"+
"lthLabRecipt.Schemas.Outbound.ReceiptSendCSV, GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas, "+
"Version=1.0.0.0, Culture=neutral, PublicKeyToken=0e4207ba20eea07f</Value>            </Property>    "+
"        <Property Name=\"TrailerSpecName\" />            <Property Name=\"TargetCharset\">              "+
"<Value xsi:type=\"xsd:string\" />            </Property>            <Property Name=\"TargetCodePage\">  "+
"            <Value xsi:type=\"xsd:int\">0</Value>            </Property>            <Property Name=\"Pr"+
"eserveBom\">              <Value xsi:type=\"xsd:boolean\">false</Value>            </Property>         "+
"   <Property Name=\"HiddenProperties\">              <Value xsi:type=\"xsd:string\">TargetCodePage</Valu"+
"e>            </Property>          </Properties>          <CachedDisplayName>Flat file assembler</Ca"+
"chedDisplayName>          <CachedIsManaged>true</CachedIsManaged>        </Component>      </Compone"+
"nts>    </Stage>    <Stage>      <PolicyFileStage _locAttrData=\"Name\" _locID=\"3\" Name=\"Encode\" minOc"+
"curs=\"0\" maxOccurs=\"-1\" execMethod=\"All\" stageId=\"9d0e4108-4cce-4536-83fa-4a5040674ad6\" />      <Com"+
"ponents />    </Stage>  </Stages></Document>";
        
        private const string _versionDependentGuid = "b170bbd3-5486-47fe-888d-a3994b6d02a1";
        
        public SendReceiptCSV()
        {
            Microsoft.BizTalk.PipelineOM.Stage stage = this.AddStage(new System.Guid("9d0e4101-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp0 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("GLC.Integration.Cargowiseone.ClassicWatch.PipelineComp.Receipt_FileName,GLC.Integration.Cargowiseone.HealthLabRecipt.PipelineComp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=0e4207ba20eea07f");;
            if (comp0 is IPersistPropertyBag)
            {
                string comp0XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties /></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp0XmlProperties);;
                ((IPersistPropertyBag)(comp0)).Load(pb, 0);
            }
            this.AddComponent(stage, comp0);
            stage = this.AddStage(new System.Guid("9d0e4107-4cce-4536-83fa-4a5040674ad6"), Microsoft.BizTalk.PipelineOM.ExecutionMode.all);
            IBaseComponent comp1 = Microsoft.BizTalk.PipelineOM.PipelineManager.CreateComponent("Microsoft.BizTalk.Component.FFAsmComp,Microsoft.BizTalk.Pipeline.Components, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");;
            if (comp1 is IPersistPropertyBag)
            {
                string comp1XmlProperties = "<?xml version=\"1.0\" encoding=\"utf-16\"?><PropertyBag xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-inst"+
"ance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <Properties>    <Property Name=\"HeaderSpecName\""+
" />    <Property Name=\"DocumentSpecName\">      <Value xsi:type=\"xsd:string\">GLC.Integration.Cargowis"+
"eone.HealthLabRecipt.Schemas.Outbound.ReceiptSendCSV, GLC.Integration.Cargowiseone.HealthLabRecipt.S"+
"chemas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=0e4207ba20eea07f</Value>    </Property>    "+
"<Property Name=\"TrailerSpecName\" />    <Property Name=\"TargetCharset\">      <Value xsi:type=\"xsd:str"+
"ing\" />    </Property>    <Property Name=\"TargetCodePage\">      <Value xsi:type=\"xsd:int\">0</Value> "+
"   </Property>    <Property Name=\"PreserveBom\">      <Value xsi:type=\"xsd:boolean\">false</Value>    "+
"</Property>    <Property Name=\"HiddenProperties\">      <Value xsi:type=\"xsd:string\">TargetCodePage</"+
"Value>    </Property>  </Properties></PropertyBag>";
                PropertyBag pb = PropertyBag.DeserializeFromXml(comp1XmlProperties);;
                ((IPersistPropertyBag)(comp1)).Load(pb, 0);
            }
            this.AddComponent(stage, comp1);
        }
        
        public override string XmlContent
        {
            get
            {
                return _strPipeline;
            }
        }
        
        public override System.Guid VersionDependentGuid
        {
            get
            {
                return new System.Guid(_versionDependentGuid);
            }
        }
    }
}
