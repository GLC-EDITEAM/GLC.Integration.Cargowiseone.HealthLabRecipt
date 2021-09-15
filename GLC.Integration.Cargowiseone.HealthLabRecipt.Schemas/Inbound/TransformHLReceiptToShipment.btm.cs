namespace GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Inbound {
    
    
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Inbound.ReciptDebatched", typeof(global::GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Inbound.ReciptDebatched))]
    [Microsoft.XLANGs.BaseTypes.SchemaReference(@"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment", typeof(global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment))]
    public sealed class TransformHLReceiptToShipment : global::Microsoft.XLANGs.BaseTypes.TransformBase {
        
        private const string _strMap = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" xmlns:msxsl=""urn:schemas-microsoft-com:xslt"" xmlns:var=""http://schemas.microsoft.com/BizTalk/2003/var"" exclude-result-prefixes=""msxsl var userCSharp"" version=""1.0""  xmlns:ns0=""http://www.cargowise.com/Schemas/Universal/2011/11""  xmlns:userCSharp=""http://schemas.microsoft.com/BizTalk/2003/userCSharp"">
  <xsl:output omit-xml-declaration=""yes"" method=""xml"" version=""1.0"" />
  <xsl:template match=""/"">
    <xsl:apply-templates select=""/HLReciptDebatched"" />
  </xsl:template>
  <xsl:template match=""/HLReciptDebatched"">
    <xsl:variable name=""var:v1"" select=""userCSharp:StringConcat(&quot;GDS&quot;)"" />
    <xsl:variable name=""var:v2"" select=""userCSharp:StringConcat(&quot;US&quot;)"" />
    <!--<xsl:variable name=""var:v3"" select=""userCSharp:StringConcat(&quot;GLCGDSTRN&quot;)"" />-->
    <!--PROD Value-->
    <xsl:variable name=""var:v3"" select=""userCSharp:StringConcat(&quot;GLCLAXLAX&quot;)"" />
    <xsl:variable name=""var:v4"" select=""userCSharp:StringConcat(&quot;GLC&quot;)"" />
    <!--<xsl:variable name=""var:v5"" select=""userCSharp:StringConcat(&quot;TRN&quot;)"" />-->
    <!--PROD Value-->
    <xsl:variable name=""var:v5"" select=""userCSharp:StringConcat(&quot;LAX&quot;)"" />
    <xsl:variable name=""var:v6"" select=""userCSharp:StringConcat(&quot;WarehouseReceive&quot;)"" />
    <ns0:UniversalShipment>
      <ns0:Shipment>
        <ns0:DataContext>
          <ns0:Company>
            <ns0:Code>
              <xsl:value-of select=""$var:v1"" />
            </ns0:Code>
            <ns0:Country>
              <ns0:Code>
                <xsl:value-of select=""$var:v2"" />
              </ns0:Code>
            </ns0:Country>
          </ns0:Company>
          <ns0:DataProvider>
            <xsl:value-of select=""$var:v3"" />
          </ns0:DataProvider>
          <ns0:EnterpriseID>
            <xsl:value-of select=""$var:v4"" />
          </ns0:EnterpriseID>
          <EventBranch>
            <Code>LOS</Code>
          </EventBranch>
          <ns0:ServerID>
            <xsl:value-of select=""$var:v5"" />
          </ns0:ServerID>
          <ns0:DataTargetCollection>
            <ns0:DataTarget>
              <ns0:Type>
                <xsl:value-of select=""$var:v6"" />
              </ns0:Type>
            </ns0:DataTarget>
          </ns0:DataTargetCollection>
        </ns0:DataContext>
        
       
       
        <ns0:Order>
          <xsl:for-each select=""HLReciptMaster_Child1"">
            <xsl:if test=""HLReciptMaster_Child1_Child1/text()='RCH'"">
              <ns0:OrderNumber>
                <xsl:value-of select=""HLReciptMaster_Child1_Child3/text()"" />
              </ns0:OrderNumber>
              <ns0:ClientReference>
              <xsl:value-of select=""HLReciptMaster_Child1_Child9/text()"" />
                </ns0:ClientReference>
              <ns0:Type>
                <ns0:Code>REC</ns0:Code>
                <ns0:Description>GOODS RECEIPT</ns0:Description>
              </ns0:Type>
              <xsl:variable name=""var:v9"" select=""userCSharp:StringConcat(&quot;RED&quot;)"" />
              <ns0:Warehouse>
                <ns0:Code>
                  <xsl:value-of select=""$var:v9"" />
                </ns0:Code>
                <ns0:Name>RED</ns0:Name>
              </ns0:Warehouse>
            
             <ns0:DateCollection>      
                <ns0:Date>
                  <ns0:Type>Arrival</ns0:Type>
                  <ns0:IsEstimate>true</ns0:IsEstimate>
                  <ns0:Value>
                    <xsl:value-of select=""userCSharp:DateimeConversion_re(HLReciptMaster_Child1_Child6/text())""/>                
                </ns0:Value>
                </ns0:Date>
                <ns0:Date>
                  <ns0:Type>Arrival</ns0:Type>
                  <ns0:IsEstimate>false</ns0:IsEstimate>
                  <ns0:Value>
                   <xsl:value-of select=""userCSharp:DateimeConversion_re(HLReciptMaster_Child1_Child7/text())""/>   
                   </ns0:Value>
                </ns0:Date>
          </ns0:DateCollection>
            </xsl:if>
          </xsl:for-each>
          <ns0:OrderLineCollection>
            <xsl:variable name=""var:v10"" select=""userCSharp:StringConcat(&quot;Complete&quot;)"" />
            <xsl:attribute name=""Content"">
              <xsl:value-of select=""$var:v10"" />
            </xsl:attribute>
            <xsl:for-each select=""HLReciptMaster_Child1"">
              <xsl:if test=""HLReciptMaster_Child1_Child1/text()='RCD'"">

                <ns0:OrderLine>
                  <ns0:ExpiryDate>
                     <xsl:value-of select=""userCSharp:DateimeConversion(HLReciptMaster_Child1_Child12/text())""/>
                  </ns0:ExpiryDate>
                  <ns0:OrderedQty>
                    <xsl:value-of select=""HLReciptMaster_Child1_Child8/text()""/>
                  </ns0:OrderedQty>
                  <ns0:OrderedQtyUnit>
                      <ns0:Code>
                        <xsl:value-of select=""HLReciptMaster_Child1_Child9/text()"" />
                      </ns0:Code>
                    </ns0:OrderedQtyUnit>
                  <ns0:PartAttribute1>
                    <xsl:value-of select=""HLReciptMaster_Child1_Child11/text()"" />
                  </ns0:PartAttribute1>
                  <ns0:Product>
                    <ns0:Code>
                      <xsl:value-of select=""HLReciptMaster_Child1_Child7/text()"" />
                    </ns0:Code>
                  </ns0:Product>
                  <!--<CustomizedFieldCollection>
                    <CustomizedField>
                      <DataType>String</DataType>
                      <Key>ORDERLINEPO#</Key>
                      <Value>
                        <xsl:value-of select=""//OrderLinePurchaseOrderReference/text()"" />
                      </Value>
                    </CustomizedField>
                  </CustomizedFieldCollection>-->
                </ns0:OrderLine>
              </xsl:if>
            </xsl:for-each>

          </ns0:OrderLineCollection>
        </ns0:Order>



        <ns0:OrganizationAddressCollection>
          <ns0:OrganizationAddress>
            <ns0:AddressType>ConsignorDocumentaryAddress</ns0:AddressType>
            <ns0:OrganizationCode>HEALABAU</ns0:OrganizationCode>
          </ns0:OrganizationAddress>          
        </ns0:OrganizationAddressCollection>
      </ns0:Shipment>


    </ns0:UniversalShipment>
  </xsl:template>
  <msxsl:script language=""C#"" implements-prefix=""userCSharp"">
    <![CDATA[     
  public string Replacefun(string strin)    {     strin=strin.Replace("","","""");     return strin;    }    public string StringConcat(string param0){   return param0;}
  
  public string DateimeConversion_re(string strin)            
  {                        DateTime strdatetime = new DateTime();
                           if(strin!=""null,"" && strin!="""" )
                           {
                           string strin1 = strin.Substring(2, 2) + ""/"" + strin.Substring(0, 2) + ""/"" + strin.Substring(4, 4);
                          strdatetime = DateTime.Parse(strin1);            
                          strin = strdatetime.ToString(""yyyy-MM-ddTHH:mm:ss""); 
                          }
                          else
                          {strin="""";}
                          return strin;             
                          }
  public string DateimeConversion(string strin)            
  {                        DateTime strdatetime = new DateTime();
                           if(strin!=""null,"" && strin!="""")
                           {
                           string strin1 = strin.Substring(3, 2) + ""/"" + strin.Substring(0, 2) + ""/"" + strin.Substring(6, 4);
                          strdatetime = DateTime.Parse(strin1);            
                          strin = strdatetime.ToString(""yyyy-MM-ddTHH:mm:ss""); 
                          }
                          else
                          {strin="""";}
                          return strin;             
                          }
                          public bool LogicalEq(string val1, string val2){bool ret = false;double d1 = 0;double d2 = 0;if (IsNumeric(val1, ref d1) && IsNumeric(val2, ref d2)){ret = d1 == d2;}else{ret = String.Compare(val1, val2, StringComparison.Ordinal) == 0;}return ret;}public bool IsNumeric(string val){if (val == null){return false;}double d = 0;return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);}public bool IsNumeric(string val, ref double d){if (val == null){return false;}return Double.TryParse(val, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out d);}
  ]]>
  </msxsl:script>
</xsl:stylesheet>";
        
        private const int _useXSLTransform = 0;
        
        private const string _strArgList = @"<ExtensionObjects />";
        
        private const string _strSrcSchemasList0 = @"GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Inbound.ReciptDebatched";
        
        private const global::GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Inbound.ReciptDebatched _srcSchemaTypeReference0 = null;
        
        private const string _strTrgSchemasList0 = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
        
        private const global::GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment _trgSchemaTypeReference0 = null;
        
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
                _SrcSchemas[0] = @"GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Inbound.ReciptDebatched";
                return _SrcSchemas;
            }
        }
        
        public override string[] TargetSchemas {
            get {
                string[] _TrgSchemas = new string [1];
                _TrgSchemas[0] = @"GLC.Integration.CargowiseoneInboundCommon.Schemas.UniversalShipment";
                return _TrgSchemas;
            }
        }
    }
}
