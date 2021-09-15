namespace GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Outbound {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment", typeof(global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Outbound.ReceiptSendCSV", typeof(global::GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Outbound.ReceiptSendCSV))]
    public sealed class TransformshipmentToReciptCSV : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var s0 userCSharp"" version=""1.0"" xmlns:ns0=""http://GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Outbound.ReceiptSendCSV"" xmlns:s0=""http://www.cargowise.com/Schemas/Universal/2011/11"" xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/s0:UniversalShipment"" />
  </xsl:template>
  <xsl:template match=""/s0:UniversalShipment"">
    <ns0:ReciptCSV>
      <xsl:for-each select=""s0:Shipment"">
        <xsl:variable name=""varactualdate"" >
          <xsl:for-each select=""s0:MilestoneCollection/s0:Milestone"">
            <xsl:if test=""s0:EventCode='FIN'"">
              <xsl:value-of select=""userCSharp:setactualdate(s0:ActualDate/text())""/>
            </xsl:if>
          </xsl:for-each>
        </xsl:variable>
        <xsl:for-each select=""s0:Order"">
          <xsl:variable name=""varorderNo"" select=""s0:OrderNumber/text()""/>
          <xsl:for-each select=""s0:OrderLineCollection/s0:OrderLine"">
        <ReciptCSV_Child1>
          <ReciptCSV_Child1_Child1>
            <xsl:value-of select=""$varactualdate"" />
          </ReciptCSV_Child1_Child1>
          <ReciptCSV_Child1_Child2>
            <xsl:value-of select=""s0:Product/s0:Code/text()"" />
          </ReciptCSV_Child1_Child2>
          <ReciptCSV_Child1_Child3>
            <xsl:value-of select=""s0:ExpectedQuantity/text()"" />
          </ReciptCSV_Child1_Child3>
          <ReciptCSV_Child1_Child4>
            <xsl:value-of select=""s0:OrderedQty/text()"" />
          </ReciptCSV_Child1_Child4>
          <ReciptCSV_Child1_Child5>
            <xsl:value-of select=""$varorderNo""/>
          </ReciptCSV_Child1_Child5>
          <ReciptCSV_Child1_Child6>
            <xsl:value-of select=""s0:PartAttribute1/text()""/>
          </ReciptCSV_Child1_Child6>
         <ReciptCSV_Child1_Child7>
            <xsl:value-of select=""userCSharp:setdate(s0:ExpiryDate/text())""/>
          </ReciptCSV_Child1_Child7>
        </ReciptCSV_Child1>
          </xsl:for-each>
        </xsl:for-each>
      </xsl:for-each>
    </ns0:ReciptCSV>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp"">
    <![CDATA[     
  public string Replacefun(string strin)    {     strin=strin.Replace("","","""");     return strin;    }    public string StringConcat(string param0){   return param0;}
  
   public string setdate(string strin)
    { 
    if(strin !="""")
    {
          strin = strin.Substring(8, 2) + strin.Substring(5, 2) + strin.Substring(0, 4);
       } 
    
    return strin;
   }
  
  public string setactualdate(string strin)
{ 
   if(strin !="""")
    {
        strin = strin.Substring(8, 2) + ""/"" + strin.Substring(5, 2) + ""/"" + strin.Substring(0, 4);
        
     }
    return strin;
   }
 
 public bool LogicalEq(string val1, string val2){bool ret = false;double d1 = 0;double d2 = 0;if (IsNumeric(val1, ref d1) && IsNumeric(val2, ref d2)){ret = d1 == d2;}else{ret = String.Compare(val1, val2, StringComparison.Ordinal) == 0;}return ret;}public bool IsNumeric(string val){if (val == null){return false;}double d = 0;return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);}public bool IsNumeric(string val, ref double d){if (val == null){return false;}return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);}
  ]]>
  </msxsl:script>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
        
        private const global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Outbound.ReceiptSendCSV";
        
        private const global::GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Outbound.ReceiptSendCSV _trgSchemaTypeReference0 = null;
        
        public override string XmlContent {
            get {
                return _strMap;
            }
        }
        
        public override int UseXSLTransform {
            get {
                return _useXSLTransform;
            }
        }
        
        public override string XsltArgumentListContent {
            get {
                return _strArgList;
            }
        }
        
        public override string[] SourceSchemas {
            get {
                string[] _SrcSchemas = new string [1];
                _SrcSchemas[0] = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Outbound.ReceiptSendCSV";
                return _TrgSchemas;
            }
        }
    }
}
