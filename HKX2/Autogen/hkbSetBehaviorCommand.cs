using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkbSetBehaviorCommand Signatire: 0xe18b74b9 size: 72 flags: FLAGS_NONE

    // m_characterId m_class:  Type.TYPE_UINT64 Type.TYPE_VOID arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_behavior m_class: hkbBehaviorGraph Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 24 flags: FLAGS_NONE enum: 
    // m_rootGenerator m_class: hkbGenerator Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    // m_referencedBehaviors m_class: hkbBehaviorGraph Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 40 flags: FLAGS_NONE enum: 
    // m_startStateIndex m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 56 flags: FLAGS_NONE enum: 
    // m_randomizeSimulation m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 60 flags: FLAGS_NONE enum: 
    // m_padding m_class:  Type.TYPE_INT32 Type.TYPE_VOID arrSize: 0 offset: 64 flags: FLAGS_NONE enum: 
    public partial class hkbSetBehaviorCommand : hkReferencedObject
    {
        public ulong m_characterId { set; get; } = default;
        public hkbBehaviorGraph? m_behavior { set; get; } = default;
        public hkbGenerator? m_rootGenerator { set; get; } = default;
        public IList<hkbBehaviorGraph> m_referencedBehaviors { set; get; } = new List<hkbBehaviorGraph>();
        public int m_startStateIndex { set; get; } = default;
        public bool m_randomizeSimulation { set; get; } = default;
        public int m_padding { set; get; } = default;

        public override uint Signature => 0xe18b74b9;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_characterId = br.ReadUInt64();
            m_behavior = des.ReadClassPointer<hkbBehaviorGraph>(br);
            m_rootGenerator = des.ReadClassPointer<hkbGenerator>(br);
            m_referencedBehaviors = des.ReadClassPointerArray<hkbBehaviorGraph>(br);
            m_startStateIndex = br.ReadInt32();
            m_randomizeSimulation = br.ReadBoolean();
            br.Position += 3;
            m_padding = br.ReadInt32();
            br.Position += 4;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteUInt64(m_characterId);
            s.WriteClassPointer(bw, m_behavior);
            s.WriteClassPointer(bw, m_rootGenerator);
            s.WriteClassPointerArray(bw, m_referencedBehaviors);
            bw.WriteInt32(m_startStateIndex);
            bw.WriteBoolean(m_randomizeSimulation);
            bw.Position += 3;
            bw.WriteInt32(m_padding);
            bw.Position += 4;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_characterId = xd.ReadUInt64(xe, nameof(m_characterId));
            m_behavior = xd.ReadClassPointer<hkbBehaviorGraph>(xe, nameof(m_behavior));
            m_rootGenerator = xd.ReadClassPointer<hkbGenerator>(xe, nameof(m_rootGenerator));
            m_referencedBehaviors = xd.ReadClassPointerArray<hkbBehaviorGraph>(xe, nameof(m_referencedBehaviors));
            m_startStateIndex = xd.ReadInt32(xe, nameof(m_startStateIndex));
            m_randomizeSimulation = xd.ReadBoolean(xe, nameof(m_randomizeSimulation));
            m_padding = xd.ReadInt32(xe, nameof(m_padding));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteNumber(xe, nameof(m_characterId), m_characterId);
            xs.WriteClassPointer(xe, nameof(m_behavior), m_behavior);
            xs.WriteClassPointer(xe, nameof(m_rootGenerator), m_rootGenerator);
            xs.WriteClassPointerArray<hkbBehaviorGraph>(xe, nameof(m_referencedBehaviors), m_referencedBehaviors);
            xs.WriteNumber(xe, nameof(m_startStateIndex), m_startStateIndex);
            xs.WriteBoolean(xe, nameof(m_randomizeSimulation), m_randomizeSimulation);
            xs.WriteNumber(xe, nameof(m_padding), m_padding);
        }
    }
}

