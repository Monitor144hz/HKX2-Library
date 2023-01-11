using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkxSparselyAnimatedBool Signatire: 0x7a894596 size: 48 flags: FLAGS_NONE

    // m_bools m_class:  Type.TYPE_ARRAY Type.TYPE_BOOL arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_times m_class:  Type.TYPE_ARRAY Type.TYPE_REAL arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    public partial class hkxSparselyAnimatedBool : hkReferencedObject
    {
        public IList<bool> m_bools { set; get; } = new List<bool>();
        public IList<float> m_times { set; get; } = new List<float>();

        public override uint Signature => 0x7a894596;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_bools = des.ReadBooleanArray(br);
            m_times = des.ReadSingleArray(br);
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            s.WriteBooleanArray(bw, m_bools);
            s.WriteSingleArray(bw, m_times);
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_bools = xd.ReadBooleanArray(xe, nameof(m_bools));
            m_times = xd.ReadSingleArray(xe, nameof(m_times));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteBooleanArray(xe, nameof(m_bools), m_bools);
            xs.WriteFloatArray(xe, nameof(m_times), m_times);
        }
    }
}

