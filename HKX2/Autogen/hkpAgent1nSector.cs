using System.Xml.Linq;

namespace HKX2
{
    // hkpAgent1nSector Signatire: 0x626e55a size: 512 flags: FLAGS_NONE

    // m_bytesAllocated m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 0 flags: FLAGS_NONE enum: 
    // m_pad0 m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 4 flags: FLAGS_NONE enum: 
    // m_pad1 m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 8 flags: FLAGS_NONE enum: 
    // m_pad2 m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 12 flags: FLAGS_NONE enum: 
    // m_data m_class:  Type.TYPE_UINT8 Type.TYPE_VOID arrSize: 496 offset: 16 flags: FLAGS_NONE enum: 
    public partial class hkpAgent1nSector : IHavokObject
    {
        public uint m_bytesAllocated;
        public uint m_pad0;
        public uint m_pad1;
        public uint m_pad2;
        public byte[] m_data = new byte[496];

        public virtual uint Signature => 0x626e55a;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_bytesAllocated = br.ReadUInt32();
            m_pad0 = br.ReadUInt32();
            m_pad1 = br.ReadUInt32();
            m_pad2 = br.ReadUInt32();
            m_data = des.ReadByteCStyleArray(br, 496);
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            bw.WriteUInt32(m_bytesAllocated);
            bw.WriteUInt32(m_pad0);
            bw.WriteUInt32(m_pad1);
            bw.WriteUInt32(m_pad2);
            s.WriteByteCStyleArray(bw, m_data);
        }

        public virtual void ReadXml(XmlDeserializer xd, XElement xe)
        {
            m_bytesAllocated = xd.ReadUInt32(xe, nameof(m_bytesAllocated));
            m_pad0 = xd.ReadUInt32(xe, nameof(m_pad0));
            m_pad1 = xd.ReadUInt32(xe, nameof(m_pad1));
            m_pad2 = xd.ReadUInt32(xe, nameof(m_pad2));
            m_data = xd.ReadByteCStyleArray(xe, nameof(m_data), 496);
        }

        public virtual void WriteXml(XmlSerializer xs, XElement xe)
        {
            xs.WriteNumber(xe, nameof(m_bytesAllocated), m_bytesAllocated);
            xs.WriteNumber(xe, nameof(m_pad0), m_pad0);
            xs.WriteNumber(xe, nameof(m_pad1), m_pad1);
            xs.WriteNumber(xe, nameof(m_pad2), m_pad2);
            xs.WriteNumberArray(xe, nameof(m_data), m_data);
        }
    }
}

