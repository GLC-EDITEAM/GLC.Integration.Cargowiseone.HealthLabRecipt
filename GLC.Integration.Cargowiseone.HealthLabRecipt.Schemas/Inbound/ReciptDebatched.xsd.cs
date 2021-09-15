namespace GLC.Integration.Cargowiseone.HealthLabRecipt.Schemas.Inbound {
    using Microsoft.XLANGs.BaseTypes;
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.BizTalk.Schema.Compiler", "3.0.1.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [SchemaType(SchemaTypeEnum.Document)]
    [Schema(@"",@"HLReciptDebatched")]
    [System.SerializableAttribute()]
    [SchemaRoots(new string[] {@"HLReciptDebatched"})]
    public sealed class ReciptDebatched : Microsoft.XLANGs.BaseTypes.SchemaBase {
        
        [System.NonSerializedAttribute()]
        private static object _rawSchema;
        
        [System.NonSerializedAttribute()]
        private const string _strSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
<xs:schema xmlns:b=""http://schemas.microsoft.com/BizTalk/2003"" attributeFormDefault=""unqualified"" elementFormDefault=""qualified"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
  <xs:element name=""HLReciptDebatched"">
    <xs:complexType>
      <xs:sequence>
        <xs:element maxOccurs=""unbounded"" name=""HLReciptMaster_Child1"">
          <xs:complexType>
            <xs:sequence>
              <xs:element name=""HLReciptMaster_Child1_Child1"" type=""xs:string"" />
              <xs:element name=""HLReciptMaster_Child1_Child2"" type=""xs:string"" />
              <xs:element name=""HLReciptMaster_Child1_Child3"" type=""xs:unsignedShort"" />
              <xs:element name=""HLReciptMaster_Child1_Child4"" type=""xs:unsignedShort"" />
              <xs:element name=""HLReciptMaster_Child1_Child5"" type=""xs:string"" />
              <xs:element name=""HLReciptMaster_Child1_Child6"" type=""xs:unsignedInt"" />
              <xs:element name=""HLReciptMaster_Child1_Child7"" type=""xs:string"" />
              <xs:element name=""HLReciptMaster_Child1_Child8"" type=""xs:byte"" />
              <xs:element name=""HLReciptMaster_Child1_Child9"" type=""xs:string"" />
              <xs:element name=""HLReciptMaster_Child1_Child10"" type=""xs:string"" />
              <xs:element name=""HLReciptMaster_Child1_Child11"" type=""xs:string"" />
              <xs:element name=""HLReciptMaster_Child1_Child12"" type=""xs:string"" />
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>";
        
        public ReciptDebatched() {
        }
        
        public override string XmlContent {
            get {
                return _strSchema;
            }
        }
        
        public override string[] RootNodes {
            get {
                string[] _RootElements = new string [1];
                _RootElements[0] = "HLReciptDebatched";
                return _RootElements;
            }
        }
        
        protected override object RawSchema {
            get {
                return _rawSchema;
            }
            set {
                _rawSchema = value;
            }
        }
    }
}
