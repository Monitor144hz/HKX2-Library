using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkbTransformVectorModifier Signatire: 0xf93e0e24 size: 160 flags: FLAGS_NONE

    // m_rotation m_class:  Type.TYPE_QUATERNION Type.TYPE_VOID arrSize: 0 offset: 80 flags: FLAGS_NONE enum: 
    // m_translation m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 96 flags: FLAGS_NONE enum: 
    // m_vectorIn m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 112 flags: FLAGS_NONE enum: 
    // m_vectorOut m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 128 flags: FLAGS_NONE enum: 
    // m_rotateOnly m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 144 flags: FLAGS_NONE enum: 
    // m_inverse m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 145 flags: FLAGS_NONE enum: 
    // m_computeOnActivate m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 146 flags: FLAGS_NONE enum: 
    // m_computeOnModify m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 147 flags: FLAGS_NONE enum: 
    public partial class hkbTransformVectorModifier : hkbModifier
    {
        public Quaternion m_rotation { set; get; } = default;
        public Vector4 m_translation { set; get; } = default;
        public Vector4 m_vectorIn { set; get; } = default;
        public Vector4 m_vectorOut { set; get; } = default;
        public bool m_rotateOnly { set; get; } = default;
        public bool m_inverse { set; get; } = default;
        public bool m_computeOnActivate { set; get; } = default;
        public bool m_computeOnModify { set; get; } = default;

        public override uint Signature => 0xf93e0e24;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_rotation = des.ReadQuaternion(br);
            m_translation = br.ReadVector4();
            m_vectorIn = br.ReadVector4();
            m_vectorOut = br.ReadVector4();
            m_rotateOnly = br.ReadBoolean();
            m_inverse = br.ReadBoolean();
            m_computeOnActivate = br.ReadBoolean();
            m_computeOnModify = br.ReadBoolean();
            br.Position += 12;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteQuaternion(bw, m_rotation);
            bw.WriteVector4(m_translation);
            bw.WriteVector4(m_vectorIn);
            bw.WriteVector4(m_vectorOut);
            bw.WriteBoolean(m_rotateOnly);
            bw.WriteBoolean(m_inverse);
            bw.WriteBoolean(m_computeOnActivate);
            bw.WriteBoolean(m_computeOnModify);
            bw.Position += 12;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_rotation = xd.ReadQuaternion(xe, nameof(m_rotation));
            m_translation = xd.ReadVector4(xe, nameof(m_translation));
            m_vectorIn = xd.ReadVector4(xe, nameof(m_vectorIn));
            m_vectorOut = xd.ReadVector4(xe, nameof(m_vectorOut));
            m_rotateOnly = xd.ReadBoolean(xe, nameof(m_rotateOnly));
            m_inverse = xd.ReadBoolean(xe, nameof(m_inverse));
            m_computeOnActivate = xd.ReadBoolean(xe, nameof(m_computeOnActivate));
            m_computeOnModify = xd.ReadBoolean(xe, nameof(m_computeOnModify));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteQuaternion(xe, nameof(m_rotation), m_rotation);
            xs.WriteVector4(xe, nameof(m_translation), m_translation);
            xs.WriteVector4(xe, nameof(m_vectorIn), m_vectorIn);
            xs.WriteVector4(xe, nameof(m_vectorOut), m_vectorOut);
            xs.WriteBoolean(xe, nameof(m_rotateOnly), m_rotateOnly);
            xs.WriteBoolean(xe, nameof(m_inverse), m_inverse);
            xs.WriteBoolean(xe, nameof(m_computeOnActivate), m_computeOnActivate);
            xs.WriteBoolean(xe, nameof(m_computeOnModify), m_computeOnModify);
        }
    }
}

