using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkbNode Signatire: 0x6d26f61d size: 72 flags: FLAGS_NONE

    // m_userData m_class:  Type.TYPE_ULONG Type.TYPE_VOID arrSize: 0 offset: 48 flags: FLAGS_NONE enum: 
    // m_name m_class:  Type.TYPE_STRINGPTR Type.TYPE_VOID arrSize: 0 offset: 56 flags: FLAGS_NONE enum: 
    // m_id m_class:  Type.TYPE_INT16 Type.TYPE_VOID arrSize: 0 offset: 64 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_cloneState m_class:  Type.TYPE_ENUM Type.TYPE_INT8 arrSize: 0 offset: 66 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_padNode m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 1 offset: 67 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    public partial class hkbNode : hkbBindable
    {
        public ulong m_userData { set; get; } = default;
        public string m_name { set; get; } = "";
        private short m_id { set; get; } = default;
        private sbyte m_cloneState { set; get; } = default;
        public bool[] m_padNode = new bool[1];

        public override uint Signature => 0x6d26f61d;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_userData = br.ReadUInt64();
            m_name = des.ReadStringPointer(br);
            m_id = br.ReadInt16();
            m_cloneState = br.ReadSByte();
            m_padNode = des.ReadBooleanCStyleArray(br, 1);
            br.Position += 4;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteUInt64(m_userData);
            s.WriteStringPointer(bw, m_name);
            bw.WriteInt16(m_id);
            bw.WriteSByte(m_cloneState);
            s.WriteBooleanCStyleArray(bw, m_padNode);
            bw.Position += 4;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_userData = xd.ReadUInt64(xe, nameof(m_userData));
            m_name = xd.ReadString(xe, nameof(m_name));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteNumber(xe, nameof(m_userData), m_userData);
            xs.WriteString(xe, nameof(m_name), m_name);
            xs.WriteSerializeIgnored(xe, nameof(m_id));
            xs.WriteSerializeIgnored(xe, nameof(m_cloneState));
            xs.WriteSerializeIgnored(xe, nameof(m_padNode));
        }
    }
}

