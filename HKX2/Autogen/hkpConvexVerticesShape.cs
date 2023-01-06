using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkpConvexVerticesShape Signatire: 0x28726ad8 size: 144 flags: FLAGS_NONE

    // m_aabbHalfExtents m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 48 flags: FLAGS_NONE enum: 
    // m_aabbCenter m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 64 flags: FLAGS_NONE enum: 
    // m_rotatedVertices m_class: hkpConvexVerticesShapeFourVectors Type.TYPE_ARRAY Type.TYPE_STRUCT arrSize: 0 offset: 80 flags: FLAGS_NONE enum: 
    // m_numVertices m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 96 flags: FLAGS_NONE enum: 
    // m_externalObject m_class:  Type.TYPE_POINTER Type.TYPE_VOID arrSize: 0 offset: 104 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_getFaceNormals m_class:  Type.TYPE_POINTER Type.TYPE_VOID arrSize: 0 offset: 112 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_planeEquations m_class:  Type.TYPE_ARRAY Type.TYPE_VECTOR4 arrSize: 0 offset: 120 flags: FLAGS_NONE enum: 
    // m_connectivity m_class: hkpConvexVerticesConnectivity Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 136 flags: FLAGS_NONE enum: 
    public partial class hkpConvexVerticesShape : hkpConvexShape
    {
        public Vector4 m_aabbHalfExtents;
        public Vector4 m_aabbCenter;
        public List<hkpConvexVerticesShapeFourVectors> m_rotatedVertices = new List<hkpConvexVerticesShapeFourVectors>();
        public int m_numVertices;
        public dynamic m_externalObject;
        public dynamic m_getFaceNormals;
        public List<Vector4> m_planeEquations;
        public hkpConvexVerticesConnectivity m_connectivity;

        public override uint Signature => 0x28726ad8;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            br.Position += 8;
            m_aabbHalfExtents = br.ReadVector4();
            m_aabbCenter = br.ReadVector4();
            m_rotatedVertices = des.ReadClassArray<hkpConvexVerticesShapeFourVectors>(br);
            m_numVertices = br.ReadInt32();
            br.Position += 4;
            des.ReadEmptyPointer(br);
            des.ReadEmptyPointer(br);
            m_planeEquations = des.ReadVector4Array(br);
            m_connectivity = des.ReadClassPointer<hkpConvexVerticesConnectivity>(br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.Position += 8;
            bw.WriteVector4(m_aabbHalfExtents);
            bw.WriteVector4(m_aabbCenter);
            s.WriteClassArray<hkpConvexVerticesShapeFourVectors>(bw, m_rotatedVertices);
            bw.WriteInt32(m_numVertices);
            bw.Position += 4;
            s.WriteVoidPointer(bw);
            s.WriteVoidPointer(bw);
            s.WriteVector4Array(bw, m_planeEquations);
            s.WriteClassPointer(bw, m_connectivity);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_aabbHalfExtents = xd.ReadVector4(xe, nameof(m_aabbHalfExtents));
            m_aabbCenter = xd.ReadVector4(xe, nameof(m_aabbCenter));
            m_rotatedVertices = xd.ReadClassArray<hkpConvexVerticesShapeFourVectors>(xe, nameof(m_rotatedVertices));
            m_numVertices = xd.ReadInt32(xe, nameof(m_numVertices));
            m_externalObject = default;
            m_getFaceNormals = default;
            m_planeEquations = xd.ReadVector4Array(xe, nameof(m_planeEquations));
            m_connectivity = xd.ReadClassPointer<hkpConvexVerticesConnectivity>(xe, nameof(m_connectivity));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteVector4(xe, nameof(m_aabbHalfExtents), m_aabbHalfExtents);
            xs.WriteVector4(xe, nameof(m_aabbCenter), m_aabbCenter);
            xs.WriteClassArray<hkpConvexVerticesShapeFourVectors>(xe, nameof(m_rotatedVertices), m_rotatedVertices);
            xs.WriteNumber(xe, nameof(m_numVertices), m_numVertices);
            xs.WriteSerializeIgnored(xe, nameof(m_externalObject));
            xs.WriteSerializeIgnored(xe, nameof(m_getFaceNormals));
            xs.WriteVector4Array(xe, nameof(m_planeEquations), m_planeEquations);
            xs.WriteClassPointer(xe, nameof(m_connectivity), m_connectivity);
        }
    }
}

