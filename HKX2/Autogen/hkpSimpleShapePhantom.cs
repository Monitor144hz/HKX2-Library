using System.Collections.Generic;
using System.Xml.Linq;

namespace HKX2
{
    // hkpSimpleShapePhantom Signatire: 0x32a2a8a8 size: 448 flags: FLAGS_NONE

    // m_collisionDetails m_class: hkpSimpleShapePhantomCollisionDetail Type.TYPE_ARRAY Type.TYPE_STRUCT arrSize: 0 offset: 416 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_orderDirty m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 432 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    public partial class hkpSimpleShapePhantom : hkpShapePhantom
    {
        public List<hkpSimpleShapePhantomCollisionDetail> m_collisionDetails = new List<hkpSimpleShapePhantomCollisionDetail>();
        public bool m_orderDirty;

        public override uint Signature => 0x32a2a8a8;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_collisionDetails = des.ReadClassArray<hkpSimpleShapePhantomCollisionDetail>(br);
            m_orderDirty = br.ReadBoolean();
            br.Position += 15;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteClassArray<hkpSimpleShapePhantomCollisionDetail>(bw, m_collisionDetails);
            bw.WriteBoolean(m_orderDirty);
            bw.Position += 15;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_collisionDetails = new List<hkpSimpleShapePhantomCollisionDetail>();
            m_orderDirty = default;
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteSerializeIgnored(xe, nameof(m_collisionDetails));
            xs.WriteSerializeIgnored(xe, nameof(m_orderDirty));
        }
    }
}

