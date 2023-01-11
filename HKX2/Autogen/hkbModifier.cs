using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkbModifier Signatire: 0x96ec5ced size: 80 flags: FLAGS_NONE

    // m_enable m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 72 flags: FLAGS_NONE enum: 
    // m_padModifier m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 3 offset: 73 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    public partial class hkbModifier : hkbNode
    {
        public bool m_enable { set; get; } = default;
        public bool[] m_padModifier = new bool[3];

        public override uint Signature => 0x96ec5ced;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_enable = br.ReadBoolean();
            m_padModifier = des.ReadBooleanCStyleArray(br, 3);
            br.Position += 4;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteBoolean(m_enable);
            s.WriteBooleanCStyleArray(bw, m_padModifier);
            bw.Position += 4;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_enable = xd.ReadBoolean(xe, nameof(m_enable));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteBoolean(xe, nameof(m_enable), m_enable);
            xs.WriteSerializeIgnored(xe, nameof(m_padModifier));
        }
    }
}

