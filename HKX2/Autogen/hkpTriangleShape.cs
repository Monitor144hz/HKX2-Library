using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkpTriangleShape Signatire: 0x95ad1a25 size: 112 flags: FLAGS_NONE

    // m_weldingInfo m_class:  Type.TYPE_UINT16 Type.TYPE_VOID arrSize: 0 offset: 40 flags: FLAGS_NONE enum: 
    // m_weldingType m_class:  Type.TYPE_ENUM Type.TYPE_UINT8 arrSize: 0 offset: 42 flags: FLAGS_NONE enum: WeldingType
    // m_isExtruded m_class:  Type.TYPE_UINT8 Type.TYPE_VOID arrSize: 0 offset: 43 flags: FLAGS_NONE enum: 
    // m_vertexA m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 48 flags: FLAGS_NONE enum: 
    // m_vertexB m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 64 flags: FLAGS_NONE enum: 
    // m_vertexC m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 80 flags: FLAGS_NONE enum: 
    // m_extrusion m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 96 flags: FLAGS_NONE enum: 
    public partial class hkpTriangleShape : hkpConvexShape
    {
        public ushort m_weldingInfo;
        public byte m_weldingType;
        public byte m_isExtruded;
        public Vector4 m_vertexA;
        public Vector4 m_vertexB;
        public Vector4 m_vertexC;
        public Vector4 m_extrusion;

        public override uint Signature => 0x95ad1a25;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_weldingInfo = br.ReadUInt16();
            m_weldingType = br.ReadByte();
            m_isExtruded = br.ReadByte();
            br.Position += 4;
            m_vertexA = br.ReadVector4();
            m_vertexB = br.ReadVector4();
            m_vertexC = br.ReadVector4();
            m_extrusion = br.ReadVector4();
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteUInt16(m_weldingInfo);
            s.WriteByte(bw, m_weldingType);
            bw.WriteByte(m_isExtruded);
            bw.Position += 4;
            bw.WriteVector4(m_vertexA);
            bw.WriteVector4(m_vertexB);
            bw.WriteVector4(m_vertexC);
            bw.WriteVector4(m_extrusion);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_weldingInfo = xd.ReadUInt16(xe, nameof(m_weldingInfo));
            m_weldingType = xd.ReadFlag<WeldingType, byte>(xe, nameof(m_weldingType));
            m_isExtruded = xd.ReadByte(xe, nameof(m_isExtruded));
            m_vertexA = xd.ReadVector4(xe, nameof(m_vertexA));
            m_vertexB = xd.ReadVector4(xe, nameof(m_vertexB));
            m_vertexC = xd.ReadVector4(xe, nameof(m_vertexC));
            m_extrusion = xd.ReadVector4(xe, nameof(m_extrusion));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteNumber(xe, nameof(m_weldingInfo), m_weldingInfo);
            xs.WriteEnum<WeldingType, byte>(xe, nameof(m_weldingType), m_weldingType);
            xs.WriteNumber(xe, nameof(m_isExtruded), m_isExtruded);
            xs.WriteVector4(xe, nameof(m_vertexA), m_vertexA);
            xs.WriteVector4(xe, nameof(m_vertexB), m_vertexB);
            xs.WriteVector4(xe, nameof(m_vertexC), m_vertexC);
            xs.WriteVector4(xe, nameof(m_extrusion), m_extrusion);
        }
    }
}

