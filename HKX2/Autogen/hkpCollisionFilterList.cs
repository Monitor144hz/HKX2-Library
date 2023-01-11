using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkpCollisionFilterList Signatire: 0x2603bf04 size: 88 flags: FLAGS_NONE

    // m_collisionFilters m_class: hkpCollisionFilter Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 72 flags: FLAGS_NONE enum: 
    public partial class hkpCollisionFilterList : hkpCollisionFilter
    {
        public IList<hkpCollisionFilter> m_collisionFilters { set; get; } = new List<hkpCollisionFilter>();

        public override uint Signature => 0x2603bf04;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_collisionFilters = des.ReadClassPointerArray<hkpCollisionFilter>(br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteClassPointerArray(bw, m_collisionFilters);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_collisionFilters = xd.ReadClassPointerArray<hkpCollisionFilter>(xe, nameof(m_collisionFilters));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteClassPointerArray<hkpCollisionFilter>(xe, nameof(m_collisionFilters), m_collisionFilters);
        }
    }
}

