using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkaSplineCompressedAnimationAnimationCompressionParams Signatire: 0xde830789 size: 4 flags: FLAGS_NONE

    // m_maxFramesPerBlock m_class:  Type.TYPE_UINT16 Type.TYPE_VOID arrSize: 0 offset: 0 flags: FLAGS_NONE enum: 
    // m_enableSampleSingleTracks m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 2 flags: FLAGS_NONE enum: 
    public partial class hkaSplineCompressedAnimationAnimationCompressionParams : IHavokObject
    {
        public ushort m_maxFramesPerBlock { set; get; } = default;
        public bool m_enableSampleSingleTracks { set; get; } = default;

        public virtual uint Signature => 0xde830789;

        public virtual void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            m_maxFramesPerBlock = br.ReadUInt16();
            m_enableSampleSingleTracks = br.ReadBoolean();
            br.Position += 1;
        }

        public virtual void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            bw.WriteUInt16(m_maxFramesPerBlock);
            bw.WriteBoolean(m_enableSampleSingleTracks);
            bw.Position += 1;
        }

        public virtual void ReadXml(XmlDeserializer xd, XElement xe)
        {
            m_maxFramesPerBlock = xd.ReadUInt16(xe, nameof(m_maxFramesPerBlock));
            m_enableSampleSingleTracks = xd.ReadBoolean(xe, nameof(m_enableSampleSingleTracks));
        }

        public virtual void WriteXml(XmlSerializer xs, XElement xe)
        {
            xs.WriteNumber(xe, nameof(m_maxFramesPerBlock), m_maxFramesPerBlock);
            xs.WriteBoolean(xe, nameof(m_enableSampleSingleTracks), m_enableSampleSingleTracks);
        }
    }
}

