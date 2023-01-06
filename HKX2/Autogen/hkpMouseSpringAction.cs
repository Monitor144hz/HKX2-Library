using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkpMouseSpringAction Signatire: 0x6e087fd6 size: 144 flags: FLAGS_NONE

    // m_positionInRbLocal m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 64 flags: FLAGS_NONE enum: 
    // m_mousePositionInWorld m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 80 flags: FLAGS_NONE enum: 
    // m_springDamping m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 96 flags: FLAGS_NONE enum: 
    // m_springElasticity m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 100 flags: FLAGS_NONE enum: 
    // m_maxRelativeForce m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 104 flags: FLAGS_NONE enum: 
    // m_objectDamping m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 108 flags: FLAGS_NONE enum: 
    // m_shapeKey m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 112 flags: FLAGS_NONE enum: 
    // m_applyCallbacks m_class:  Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 120 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    public partial class hkpMouseSpringAction : hkpUnaryAction
    {
        public Vector4 m_positionInRbLocal;
        public Vector4 m_mousePositionInWorld;
        public float m_springDamping;
        public float m_springElasticity;
        public float m_maxRelativeForce;
        public float m_objectDamping;
        public uint m_shapeKey;
        public List<dynamic> m_applyCallbacks = new List<dynamic>();

        public override uint Signature => 0x6e087fd6;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            br.Position += 8;
            m_positionInRbLocal = br.ReadVector4();
            m_mousePositionInWorld = br.ReadVector4();
            m_springDamping = br.ReadSingle();
            m_springElasticity = br.ReadSingle();
            m_maxRelativeForce = br.ReadSingle();
            m_objectDamping = br.ReadSingle();
            m_shapeKey = br.ReadUInt32();
            br.Position += 4;
            des.ReadEmptyArray(br);
            br.Position += 8;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.Position += 8;
            bw.WriteVector4(m_positionInRbLocal);
            bw.WriteVector4(m_mousePositionInWorld);
            bw.WriteSingle(m_springDamping);
            bw.WriteSingle(m_springElasticity);
            bw.WriteSingle(m_maxRelativeForce);
            bw.WriteSingle(m_objectDamping);
            bw.WriteUInt32(m_shapeKey);
            bw.Position += 4;
            s.WriteVoidArray(bw);
            bw.Position += 8;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_positionInRbLocal = xd.ReadVector4(xe, nameof(m_positionInRbLocal));
            m_mousePositionInWorld = xd.ReadVector4(xe, nameof(m_mousePositionInWorld));
            m_springDamping = xd.ReadSingle(xe, nameof(m_springDamping));
            m_springElasticity = xd.ReadSingle(xe, nameof(m_springElasticity));
            m_maxRelativeForce = xd.ReadSingle(xe, nameof(m_maxRelativeForce));
            m_objectDamping = xd.ReadSingle(xe, nameof(m_objectDamping));
            m_shapeKey = xd.ReadUInt32(xe, nameof(m_shapeKey));
            m_applyCallbacks = default;
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteVector4(xe, nameof(m_positionInRbLocal), m_positionInRbLocal);
            xs.WriteVector4(xe, nameof(m_mousePositionInWorld), m_mousePositionInWorld);
            xs.WriteFloat(xe, nameof(m_springDamping), m_springDamping);
            xs.WriteFloat(xe, nameof(m_springElasticity), m_springElasticity);
            xs.WriteFloat(xe, nameof(m_maxRelativeForce), m_maxRelativeForce);
            xs.WriteFloat(xe, nameof(m_objectDamping), m_objectDamping);
            xs.WriteNumber(xe, nameof(m_shapeKey), m_shapeKey);
            xs.WriteSerializeIgnored(xe, nameof(m_applyCallbacks));
        }
    }
}

