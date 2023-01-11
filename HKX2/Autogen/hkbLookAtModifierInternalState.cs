using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkbLookAtModifierInternalState Signatire: 0xa14caba6 size: 48 flags: FLAGS_NONE

    // m_lookAtLastTargetWS m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_lookAtWeight m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    // m_isTargetInsideLimitCone m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 36 flags: FLAGS_NONE enum: 
    public partial class hkbLookAtModifierInternalState : hkReferencedObject
    {
        public Vector4 m_lookAtLastTargetWS { set; get; } = default;
        public float m_lookAtWeight { set; get; } = default;
        public bool m_isTargetInsideLimitCone { set; get; } = default;

        public override uint Signature => 0xa14caba6;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_lookAtLastTargetWS = br.ReadVector4();
            m_lookAtWeight = br.ReadSingle();
            m_isTargetInsideLimitCone = br.ReadBoolean();
            br.Position += 11;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteVector4(m_lookAtLastTargetWS);
            bw.WriteSingle(m_lookAtWeight);
            bw.WriteBoolean(m_isTargetInsideLimitCone);
            bw.Position += 11;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_lookAtLastTargetWS = xd.ReadVector4(xe, nameof(m_lookAtLastTargetWS));
            m_lookAtWeight = xd.ReadSingle(xe, nameof(m_lookAtWeight));
            m_isTargetInsideLimitCone = xd.ReadBoolean(xe, nameof(m_isTargetInsideLimitCone));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteVector4(xe, nameof(m_lookAtLastTargetWS), m_lookAtLastTargetWS);
            xs.WriteFloat(xe, nameof(m_lookAtWeight), m_lookAtWeight);
            xs.WriteBoolean(xe, nameof(m_isTargetInsideLimitCone), m_isTargetInsideLimitCone);
        }
    }
}

