using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkpEntitySmallArraySerializeOverrideType Signatire: 0xee3c2aec size: 16 flags: FLAGS_NONE

    // m_data m_class:  Type.TYPE_POINTER Type.TYPE_VOID arrSize: 0 offset: 0 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_size m_class:  Type.TYPE_UINT16 Type.TYPE_VOID arrSize: 0 offset: 8 flags: FLAGS_NONE enum: 
    // m_capacityAndFlags m_class:  Type.TYPE_UINT16 Type.TYPE_VOID arrSize: 0 offset: 10 flags: FLAGS_NONE enum: 
    public partial class hkpEntitySmallArraySerializeOverrideType : IHavokObject
    {
        private object? m_data { set; get; } = default;
        public ushort m_size { set; get; } = default;
        public ushort m_capacityAndFlags { set; get; } = default;

        public virtual uint Signature => 0xee3c2aec;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            des.ReadEmptyPointer(br);
            m_size = br.ReadUInt16();
            m_capacityAndFlags = br.ReadUInt16();
            br.Position += 4;
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            s.WriteVoidPointer(bw);
            bw.WriteUInt16(m_size);
            bw.WriteUInt16(m_capacityAndFlags);
            bw.Position += 4;
        }

        public virtual void ReadXml(XmlDeserializer xd, XElement xe)
        {
            m_size = xd.ReadUInt16(xe, nameof(m_size));
            m_capacityAndFlags = xd.ReadUInt16(xe, nameof(m_capacityAndFlags));
        }

        public virtual void WriteXml(XmlSerializer xs, XElement xe)
        {
            xs.WriteSerializeIgnored(xe, nameof(m_data));
            xs.WriteNumber(xe, nameof(m_size), m_size);
            xs.WriteNumber(xe, nameof(m_capacityAndFlags), m_capacityAndFlags);
        }
    }
}

