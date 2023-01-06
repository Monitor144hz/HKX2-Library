using System.Collections.Generic;
using System.Xml.Linq;

namespace HKX2
{
    // hkpEntity Signatire: 0xa03c774b size: 720 flags: FLAGS_NONE

    // m_material m_class: hkpMaterial Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 208 flags: FLAGS_NONE enum: 
    // m_limitContactImpulseUtilAndFlag m_class:  Type.TYPE_POINTER Type.TYPE_VOID arrSize: 0 offset: 224 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_damageMultiplier m_class:  Type.TYPE_REAL Type.TYPE_VOID arrSize: 0 offset: 232 flags: FLAGS_NONE enum: 
    // m_breakableBody m_class:  Type.TYPE_POINTER Type.TYPE_VOID arrSize: 0 offset: 240 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_solverData m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 248 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_storageIndex m_class:  Type.TYPE_UINT16 Type.TYPE_VOID arrSize: 0 offset: 252 flags: FLAGS_NONE enum: 
    // m_contactPointCallbackDelay m_class:  Type.TYPE_UINT16 Type.TYPE_VOID arrSize: 0 offset: 254 flags: FLAGS_NONE enum: 
    // m_constraintsMaster m_class: hkpEntitySmallArraySerializeOverrideType Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 256 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_constraintsSlave m_class: hkpConstraintInstance Type.TYPE_ARRAY Type.TYPE_POINTER arrSize: 0 offset: 272 flags: SERIALIZE_IGNORED|NOT_OWNED|FLAGS_NONE enum: 
    // m_constraintRuntime m_class:  Type.TYPE_ARRAY Type.TYPE_UINT8 arrSize: 0 offset: 288 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_simulationIsland m_class:  Type.TYPE_POINTER Type.TYPE_VOID arrSize: 0 offset: 304 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_autoRemoveLevel m_class:  Type.TYPE_INT8 Type.TYPE_VOID arrSize: 0 offset: 312 flags: FLAGS_NONE enum: 
    // m_numShapeKeysInContactPointProperties m_class:  Type.TYPE_UINT8 Type.TYPE_VOID arrSize: 0 offset: 313 flags: FLAGS_NONE enum: 
    // m_responseModifierFlags m_class:  Type.TYPE_UINT8 Type.TYPE_VOID arrSize: 0 offset: 314 flags: FLAGS_NONE enum: 
    // m_uid m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 316 flags: FLAGS_NONE enum: 
    // m_spuCollisionCallback m_class: hkpEntitySpuCollisionCallback Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 320 flags: FLAGS_NONE enum: 
    // m_motion m_class: hkpMaxSizeMotion Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 336 flags: FLAGS_NONE enum: 
    // m_contactListeners m_class: hkpEntitySmallArraySerializeOverrideType Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 656 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_actions m_class: hkpEntitySmallArraySerializeOverrideType Type.TYPE_STRUCT Type.TYPE_VOID arrSize: 0 offset: 672 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_localFrame m_class: hkLocalFrame Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 688 flags: FLAGS_NONE enum: 
    // m_extendedListeners m_class: hkpEntityExtendedListeners Type.TYPE_POINTER Type.TYPE_STRUCT arrSize: 0 offset: 696 flags: SERIALIZE_IGNORED|FLAGS_NONE enum: 
    // m_npData m_class:  Type.TYPE_UINT32 Type.TYPE_VOID arrSize: 0 offset: 704 flags: FLAGS_NONE enum: 
    public partial class hkpEntity : hkpWorldObject
    {
        public hkpMaterial m_material = new hkpMaterial();
        public dynamic m_limitContactImpulseUtilAndFlag;
        public float m_damageMultiplier;
        public dynamic m_breakableBody;
        public uint m_solverData;
        public ushort m_storageIndex;
        public ushort m_contactPointCallbackDelay;
        public hkpEntitySmallArraySerializeOverrideType m_constraintsMaster = new hkpEntitySmallArraySerializeOverrideType();
        public List<dynamic> m_constraintsSlave = new List<dynamic>();
        public List<byte> m_constraintRuntime;
        public dynamic m_simulationIsland;
        public sbyte m_autoRemoveLevel;
        public byte m_numShapeKeysInContactPointProperties;
        public byte m_responseModifierFlags;
        public uint m_uid;
        public hkpEntitySpuCollisionCallback m_spuCollisionCallback = new hkpEntitySpuCollisionCallback();
        public hkpMaxSizeMotion m_motion = new hkpMaxSizeMotion();
        public hkpEntitySmallArraySerializeOverrideType m_contactListeners = new hkpEntitySmallArraySerializeOverrideType();
        public hkpEntitySmallArraySerializeOverrideType m_actions = new hkpEntitySmallArraySerializeOverrideType();
        public hkLocalFrame m_localFrame;
        public hkpEntityExtendedListeners m_extendedListeners;
        public uint m_npData;

        public override uint Signature => 0xa03c774b;

        public override void Read(PackFileDeserializer des, BinaryReaderEx br)
        {
            base.Read(des, br);
            m_material = new hkpMaterial();
            m_material.Read(des, br);
            br.Position += 4;
            des.ReadEmptyPointer(br);
            m_damageMultiplier = br.ReadSingle();
            br.Position += 4;
            des.ReadEmptyPointer(br);
            m_solverData = br.ReadUInt32();
            m_storageIndex = br.ReadUInt16();
            m_contactPointCallbackDelay = br.ReadUInt16();
            m_constraintsMaster = new hkpEntitySmallArraySerializeOverrideType();
            m_constraintsMaster.Read(des, br);
            des.ReadEmptyArray(br);
            m_constraintRuntime = des.ReadByteArray(br);
            des.ReadEmptyPointer(br);
            m_autoRemoveLevel = br.ReadSByte();
            m_numShapeKeysInContactPointProperties = br.ReadByte();
            m_responseModifierFlags = br.ReadByte();
            br.Position += 1;
            m_uid = br.ReadUInt32();
            m_spuCollisionCallback = new hkpEntitySpuCollisionCallback();
            m_spuCollisionCallback.Read(des, br);
            m_motion = new hkpMaxSizeMotion();
            m_motion.Read(des, br);
            m_contactListeners = new hkpEntitySmallArraySerializeOverrideType();
            m_contactListeners.Read(des, br);
            m_actions = new hkpEntitySmallArraySerializeOverrideType();
            m_actions.Read(des, br);
            m_localFrame = des.ReadClassPointer<hkLocalFrame>(br);
            m_extendedListeners = des.ReadClassPointer<hkpEntityExtendedListeners>(br);
            m_npData = br.ReadUInt32();
            br.Position += 12;
        }

        public override void Write(PackFileSerializer s, BinaryWriterEx bw)
        {
            base.Write(s, bw);
            m_material.Write(s, bw);
            bw.Position += 4;
            s.WriteVoidPointer(bw);
            bw.WriteSingle(m_damageMultiplier);
            bw.Position += 4;
            s.WriteVoidPointer(bw);
            bw.WriteUInt32(m_solverData);
            bw.WriteUInt16(m_storageIndex);
            bw.WriteUInt16(m_contactPointCallbackDelay);
            m_constraintsMaster.Write(s, bw);
            s.WriteVoidArray(bw);
            s.WriteByteArray(bw, m_constraintRuntime);
            s.WriteVoidPointer(bw);
            bw.WriteSByte(m_autoRemoveLevel);
            bw.WriteByte(m_numShapeKeysInContactPointProperties);
            bw.WriteByte(m_responseModifierFlags);
            bw.Position += 1;
            bw.WriteUInt32(m_uid);
            m_spuCollisionCallback.Write(s, bw);
            m_motion.Write(s, bw);
            m_contactListeners.Write(s, bw);
            m_actions.Write(s, bw);
            s.WriteClassPointer(bw, m_localFrame);
            s.WriteClassPointer(bw, m_extendedListeners);
            bw.WriteUInt32(m_npData);
            bw.Position += 12;
        }

        public override void ReadXml(XmlDeserializer xd, XElement xe)
        {
            base.ReadXml(xd, xe);
            m_material = xd.ReadClass<hkpMaterial>(xe, nameof(m_material));
            m_limitContactImpulseUtilAndFlag = default;
            m_damageMultiplier = xd.ReadSingle(xe, nameof(m_damageMultiplier));
            m_breakableBody = default;
            m_solverData = default;
            m_storageIndex = xd.ReadUInt16(xe, nameof(m_storageIndex));
            m_contactPointCallbackDelay = xd.ReadUInt16(xe, nameof(m_contactPointCallbackDelay));
            m_constraintsMaster = new hkpEntitySmallArraySerializeOverrideType();
            m_constraintsSlave = default;
            m_constraintRuntime = new List<byte>();
            m_simulationIsland = default;
            m_autoRemoveLevel = xd.ReadSByte(xe, nameof(m_autoRemoveLevel));
            m_numShapeKeysInContactPointProperties = xd.ReadByte(xe, nameof(m_numShapeKeysInContactPointProperties));
            m_responseModifierFlags = xd.ReadByte(xe, nameof(m_responseModifierFlags));
            m_uid = xd.ReadUInt32(xe, nameof(m_uid));
            m_spuCollisionCallback = xd.ReadClass<hkpEntitySpuCollisionCallback>(xe, nameof(m_spuCollisionCallback));
            m_motion = xd.ReadClass<hkpMaxSizeMotion>(xe, nameof(m_motion));
            m_contactListeners = new hkpEntitySmallArraySerializeOverrideType();
            m_actions = new hkpEntitySmallArraySerializeOverrideType();
            m_localFrame = xd.ReadClassPointer<hkLocalFrame>(xe, nameof(m_localFrame));
            m_extendedListeners = default;
            m_npData = xd.ReadUInt32(xe, nameof(m_npData));
        }

        public override void WriteXml(XmlSerializer xs, XElement xe)
        {
            base.WriteXml(xs, xe);
            xs.WriteClass<hkpMaterial>(xe, nameof(m_material), m_material);
            xs.WriteSerializeIgnored(xe, nameof(m_limitContactImpulseUtilAndFlag));
            xs.WriteFloat(xe, nameof(m_damageMultiplier), m_damageMultiplier);
            xs.WriteSerializeIgnored(xe, nameof(m_breakableBody));
            xs.WriteSerializeIgnored(xe, nameof(m_solverData));
            xs.WriteNumber(xe, nameof(m_storageIndex), m_storageIndex);
            xs.WriteNumber(xe, nameof(m_contactPointCallbackDelay), m_contactPointCallbackDelay);
            xs.WriteSerializeIgnored(xe, nameof(m_constraintsMaster));
            xs.WriteSerializeIgnored(xe, nameof(m_constraintsSlave));
            xs.WriteSerializeIgnored(xe, nameof(m_constraintRuntime));
            xs.WriteSerializeIgnored(xe, nameof(m_simulationIsland));
            xs.WriteNumber(xe, nameof(m_autoRemoveLevel), m_autoRemoveLevel);
            xs.WriteNumber(xe, nameof(m_numShapeKeysInContactPointProperties), m_numShapeKeysInContactPointProperties);
            xs.WriteNumber(xe, nameof(m_responseModifierFlags), m_responseModifierFlags);
            xs.WriteNumber(xe, nameof(m_uid), m_uid);
            xs.WriteClass<hkpEntitySpuCollisionCallback>(xe, nameof(m_spuCollisionCallback), m_spuCollisionCallback);
            xs.WriteClass<hkpMaxSizeMotion>(xe, nameof(m_motion), m_motion);
            xs.WriteSerializeIgnored(xe, nameof(m_contactListeners));
            xs.WriteSerializeIgnored(xe, nameof(m_actions));
            xs.WriteClassPointer(xe, nameof(m_localFrame), m_localFrame);
            xs.WriteSerializeIgnored(xe, nameof(m_extendedListeners));
            xs.WriteNumber(xe, nameof(m_npData), m_npData);
        }
    }
}

