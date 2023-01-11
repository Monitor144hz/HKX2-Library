using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;

namespace HKX2
{
    // hkbCharacterControllerModifierInternalState Signatire: 0xf8dfec0d size: 48 flags: FLAGS_NONE

    // m_gravity m_class:  Type.TYPE_VECTOR4 Type.TYPE_VOID arrSize: 0 offset: 16 flags: FLAGS_NONE enum: 
    // m_timestep m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 32 flags: FLAGS_NONE enum: 
    // m_isInitialVelocityAdded m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 36 flags: FLAGS_NONE enum: 
    // m_isTouchingGround m_class:  Type.TYPE_BOOL Type.TYPE_VOID arrSize: 0 offset: 37 flags: FLAGS_NONE enum: 
    public partial class hkbCharacterControllerModifierInternalState : hkReferencedObject
    {
        public Vector4 m_gravity { set; get; } = default;
        public float m_timestep { set; get; } = default;
        public bool m_isInitialVelocityAdded { set; get; } = default;
        public bool m_isTouchingGround { set; get; } = default;

        public override uint Signature => 0xf8dfec0d;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_gravity = br.ReadVector4();
            m_timestep = br.ReadSingle();
            m_isInitialVelocityAdded = br.ReadBoolean();
            m_isTouchingGround = br.ReadBoolean();
            br.Position += 10;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            bw.WriteVector4(m_gravity);
            bw.WriteSingle(m_timestep);
            bw.WriteBoolean(m_isInitialVelocityAdded);
            bw.WriteBoolean(m_isTouchingGround);
            bw.Position += 10;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_gravity = xd.ReadVector4(xe, nameof(m_gravity));
            m_timestep = xd.ReadSingle(xe, nameof(m_timestep));
            m_isInitialVelocityAdded = xd.ReadBoolean(xe, nameof(m_isInitialVelocityAdded));
            m_isTouchingGround = xd.ReadBoolean(xe, nameof(m_isTouchingGround));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteVector4(xe, nameof(m_gravity), m_gravity);
            xs.WriteFloat(xe, nameof(m_timestep), m_timestep);
            xs.WriteBoolean(xe, nameof(m_isInitialVelocityAdded), m_isInitialVelocityAdded);
            xs.WriteBoolean(xe, nameof(m_isTouchingGround), m_isTouchingGround);
        }
    }
}

