using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkbSetWorldFromModelModifier Signatire: 0xafcfa211 size: 128 flags: FLAGS_NONE

    // m_translation m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 80 flags: FLAGS_NONE enum: 
    // m_rotation m_class:  Type.TYPE_QUATERNION Type.TYPE_VOID arrSize: 0 offset: 96 flags: FLAGS_NONE enum: 
    // m_setTranslation m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 112 flags: FLAGS_NONE enum: 
    // m_setRotation m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 113 flags: FLAGS_NONE enum: 
    public partial class hkbSetWorldFromModelModifier : hkbModifier
    {
        public Vector4 m_translation { set; get; } = default;
        public Quaternion m_rotation { set; get; } = default;
        public bool m_setTranslation { set; get; } = default;
        public bool m_setRotation { set; get; } = default;

        public override uint Signature => 0xafcfa211;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_translation = br.ReadVector4();
            m_rotation = des.ReadQuaternion(br);
            m_setTranslation = br.ReadBoolean();
            m_setRotation = br.ReadBoolean();
            br.Position += 14;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteVector4(m_translation);
            s.WriteQuaternion(bw, m_rotation);
            bw.WriteBoolean(m_setTranslation);
            bw.WriteBoolean(m_setRotation);
            bw.Position += 14;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_translation = xd.ReadVector4(xe, nameof(m_translation));
            m_rotation = xd.ReadQuaternion(xe, nameof(m_rotation));
            m_setTranslation = xd.ReadBoolean(xe, nameof(m_setTranslation));
            m_setRotation = xd.ReadBoolean(xe, nameof(m_setRotation));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteVector4(xe, nameof(m_translation), m_translation);
            xs.WriteQuaternion(xe, nameof(m_rotation), m_rotation);
            xs.WriteBoolean(xe, nameof(m_setTranslation), m_setTranslation);
            xs.WriteBoolean(xe, nameof(m_setRotation), m_setRotation);
        }
    }
}

