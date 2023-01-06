using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkxVertexBufferVertexData Signatire: 0xd72b6fd0 size: 104 flags: FLAGS_NONE

    // m_vectorData m_class:  Type.TYPE_ARRAY Type.TYPE_VECTOR4 arrSize: 0 offset: 0 flags: FLAGS_NONE enum: 
    // m_floatData m_class:  Type.TYPE_ARRAY Type.TYPE_REAL arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_uint32Data m_class:  Type.TYPE_ARRAY Type.TYPE_UINT32 arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    // m_uint16Data m_class:  Type.TYPE_ARRAY Type.TYPE_UINT16 arrSize: 0 offset: 48 flags: FLAGS_NONE enum: 
    // m_uint8Data m_class:  Type.TYPE_ARRAY Type.TYPE_UINT8 arrSize: 0 offset: 64 flags: FLAGS_NONE enum: 
    // m_numVerts m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 80 flags: FLAGS_NONE enum: 
    // m_vectorStride m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 84 flags: FLAGS_NONE enum: 
    // m_floatStride m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 88 flags: FLAGS_NONE enum: 
    // m_uint32Stride m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 92 flags: FLAGS_NONE enum: 
    // m_uint16Stride m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 96 flags: FLAGS_NONE enum: 
    // m_uint8Stride m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 100 flags: FLAGS_NONE enum: 
    public partial class hkxVertexBufferVertexData : IHavokObject
    {
        public List<Vector4> m_vectorData;
        public List<float> m_floatData;
        public List<uint> m_uint32Data;
        public List<ushort> m_uint16Data;
        public List<byte> m_uint8Data;
        public uint m_numVerts;
        public uint m_vectorStride;
        public uint m_floatStride;
        public uint m_uint32Stride;
        public uint m_uint16Stride;
        public uint m_uint8Stride;

        public virtual uint Signature => 0xd72b6fd0;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_vectorData = des.ReadVector4Array(br);
            m_floatData = des.ReadSingleArray(br);
            m_uint32Data = des.ReadUInt32Array(br);
            m_uint16Data = des.ReadUInt16Array(br);
            m_uint8Data = des.ReadByteArray(br);
            m_numVerts = br.ReadUInt32();
            m_vectorStride = br.ReadUInt32();
            m_floatStride = br.ReadUInt32();
            m_uint32Stride = br.ReadUInt32();
            m_uint16Stride = br.ReadUInt32();
            m_uint8Stride = br.ReadUInt32();
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            s.WriteVector4Array(bw, m_vectorData);
            s.WriteSingleArray(bw, m_floatData);
            s.WriteUInt32Array(bw, m_uint32Data);
            s.WriteUInt16Array(bw, m_uint16Data);
            s.WriteByteArray(bw, m_uint8Data);
            bw.WriteUInt32(m_numVerts);
            bw.WriteUInt32(m_vectorStride);
            bw.WriteUInt32(m_floatStride);
            bw.WriteUInt32(m_uint32Stride);
            bw.WriteUInt32(m_uint16Stride);
            bw.WriteUInt32(m_uint8Stride);
        }

        public virtual void ReadXml(XmlDeserializer xd, XElement xe)
        {
            m_vectorData = xd.ReadVector4Array(xe, nameof(m_vectorData));
            m_floatData = xd.ReadSingleArray(xe, nameof(m_floatData));
            m_uint32Data = xd.ReadUInt32Array(xe, nameof(m_uint32Data));
            m_uint16Data = xd.ReadUInt16Array(xe, nameof(m_uint16Data));
            m_uint8Data = xd.ReadByteArray(xe, nameof(m_uint8Data));
            m_numVerts = xd.ReadUInt32(xe, nameof(m_numVerts));
            m_vectorStride = xd.ReadUInt32(xe, nameof(m_vectorStride));
            m_floatStride = xd.ReadUInt32(xe, nameof(m_floatStride));
            m_uint32Stride = xd.ReadUInt32(xe, nameof(m_uint32Stride));
            m_uint16Stride = xd.ReadUInt32(xe, nameof(m_uint16Stride));
            m_uint8Stride = xd.ReadUInt32(xe, nameof(m_uint8Stride));
        }

        public virtual void WriteXml(XmlSerializer xs, XElement xe)
        {
            xs.WriteVector4Array(xe, nameof(m_vectorData), m_vectorData);
            xs.WriteFloatArray(xe, nameof(m_floatData), m_floatData);
            xs.WriteNumberArray(xe, nameof(m_uint32Data), m_uint32Data);
            xs.WriteNumberArray(xe, nameof(m_uint16Data), m_uint16Data);
            xs.WriteNumberArray(xe, nameof(m_uint8Data), m_uint8Data);
            xs.WriteNumber(xe, nameof(m_numVerts), m_numVerts);
            xs.WriteNumber(xe, nameof(m_vectorStride), m_vectorStride);
            xs.WriteNumber(xe, nameof(m_floatStride), m_floatStride);
            xs.WriteNumber(xe, nameof(m_uint32Stride), m_uint32Stride);
            xs.WriteNumber(xe, nameof(m_uint16Stride), m_uint16Stride);
            xs.WriteNumber(xe, nameof(m_uint8Stride), m_uint8Stride);
        }
    }
}

