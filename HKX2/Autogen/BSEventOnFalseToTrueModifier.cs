using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // BSEventOnFalseToTrueModifier Signatire: 0x81d0777a size: 160 flags: FLAGS_NONE

    // m_bEnableEvent1 m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 80 flags: FLAGS_NONE enum: 
    // m_bVariableToTest1 m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 81 flags: FLAGS_NONE enum: 
    // m_EventToSend1 m_class: hkbEventProperty Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 88 flags: FLAGS_NONE enum: 
    // m_bEnableEvent2 m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 104 flags: FLAGS_NONE enum: 
    // m_bVariableToTest2 m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 105 flags: FLAGS_NONE enum: 
    // m_EventToSend2 m_class: hkbEventProperty Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 112 flags: FLAGS_NONE enum: 
    // m_bEnableEvent3 m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 128 flags: FLAGS_NONE enum: 
    // m_bVariableToTest3 m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 129 flags: FLAGS_NONE enum: 
    // m_EventToSend3 m_class: hkbEventProperty Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 136 flags: FLAGS_NONE enum: 
    // m_bSlot1ActivatedLastFrame m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 152 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_bSlot2ActivatedLastFrame m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 153 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_bSlot3ActivatedLastFrame m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 154 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    public partial class BSEventOnFalseToTrueModifier : hkbModifier
    {
        public bool m_bEnableEvent1 { set; get; } = default;
        public bool m_bVariableToTest1 { set; get; } = default;
        public hkbEventProperty m_EventToSend1 { set; get; } = new();
        public bool m_bEnableEvent2 { set; get; } = default;
        public bool m_bVariableToTest2 { set; get; } = default;
        public hkbEventProperty m_EventToSend2 { set; get; } = new();
        public bool m_bEnableEvent3 { set; get; } = default;
        public bool m_bVariableToTest3 { set; get; } = default;
        public hkbEventProperty m_EventToSend3 { set; get; } = new();
        private bool m_bSlot1ActivatedLastFrame { set; get; } = default;
        private bool m_bSlot2ActivatedLastFrame { set; get; } = default;
        private bool m_bSlot3ActivatedLastFrame { set; get; } = default;

        public override uint Signature => 0x81d0777a;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_bEnableEvent1 = br.ReadBoolean();
            m_bVariableToTest1 = br.ReadBoolean();
            br.Position += 6;
            m_EventToSend1.Read(des, br);
            m_bEnableEvent2 = br.ReadBoolean();
            m_bVariableToTest2 = br.ReadBoolean();
            br.Position += 6;
            m_EventToSend2.Read(des, br);
            m_bEnableEvent3 = br.ReadBoolean();
            m_bVariableToTest3 = br.ReadBoolean();
            br.Position += 6;
            m_EventToSend3.Read(des, br);
            m_bSlot1ActivatedLastFrame = br.ReadBoolean();
            m_bSlot2ActivatedLastFrame = br.ReadBoolean();
            m_bSlot3ActivatedLastFrame = br.ReadBoolean();
            br.Position += 5;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteBoolean(m_bEnableEvent1);
            bw.WriteBoolean(m_bVariableToTest1);
            bw.Position += 6;
            m_EventToSend1.Write(s, bw);
            bw.WriteBoolean(m_bEnableEvent2);
            bw.WriteBoolean(m_bVariableToTest2);
            bw.Position += 6;
            m_EventToSend2.Write(s, bw);
            bw.WriteBoolean(m_bEnableEvent3);
            bw.WriteBoolean(m_bVariableToTest3);
            bw.Position += 6;
            m_EventToSend3.Write(s, bw);
            bw.WriteBoolean(m_bSlot1ActivatedLastFrame);
            bw.WriteBoolean(m_bSlot2ActivatedLastFrame);
            bw.WriteBoolean(m_bSlot3ActivatedLastFrame);
            bw.Position += 5;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_bEnableEvent1 = xd.ReadBoolean(xe, nameof(m_bEnableEvent1));
            m_bVariableToTest1 = xd.ReadBoolean(xe, nameof(m_bVariableToTest1));
            m_EventToSend1 = xd.ReadClass<hkbEventProperty>(xe, nameof(m_EventToSend1));
            m_bEnableEvent2 = xd.ReadBoolean(xe, nameof(m_bEnableEvent2));
            m_bVariableToTest2 = xd.ReadBoolean(xe, nameof(m_bVariableToTest2));
            m_EventToSend2 = xd.ReadClass<hkbEventProperty>(xe, nameof(m_EventToSend2));
            m_bEnableEvent3 = xd.ReadBoolean(xe, nameof(m_bEnableEvent3));
            m_bVariableToTest3 = xd.ReadBoolean(xe, nameof(m_bVariableToTest3));
            m_EventToSend3 = xd.ReadClass<hkbEventProperty>(xe, nameof(m_EventToSend3));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteBoolean(xe, nameof(m_bEnableEvent1), m_bEnableEvent1);
            xs.WriteBoolean(xe, nameof(m_bVariableToTest1), m_bVariableToTest1);
            xs.WriteClass<hkbEventProperty>(xe, nameof(m_EventToSend1), m_EventToSend1);
            xs.WriteBoolean(xe, nameof(m_bEnableEvent2), m_bEnableEvent2);
            xs.WriteBoolean(xe, nameof(m_bVariableToTest2), m_bVariableToTest2);
            xs.WriteClass<hkbEventProperty>(xe, nameof(m_EventToSend2), m_EventToSend2);
            xs.WriteBoolean(xe, nameof(m_bEnableEvent3), m_bEnableEvent3);
            xs.WriteBoolean(xe, nameof(m_bVariableToTest3), m_bVariableToTest3);
            xs.WriteClass<hkbEventProperty>(xe, nameof(m_EventToSend3), m_EventToSend3);
            xs.WriteSerializeIgnored(xe, nameof(m_bSlot1ActivatedLastFrame));
            xs.WriteSerializeIgnored(xe, nameof(m_bSlot2ActivatedLastFrame));
            xs.WriteSerializeIgnored(xe, nameof(m_bSlot3ActivatedLastFrame));
        }
    }
}

