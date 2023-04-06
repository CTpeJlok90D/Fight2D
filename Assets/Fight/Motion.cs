using System;
using Unity.Netcode;

[Serializable]
public struct Motion : INetworkSerializable
{
	public Direction Move;
	public Direction Attack;
	public Direction Block;
	public bool LightBlock;

	public override bool Equals(object obj)
	{
		return obj is Motion motion &&
			   Move == motion.Move &&
			   Attack == motion.Attack &&
			   Block == motion.Block &&
               LightBlock == motion.LightBlock;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Move, Attack, Block);
	}

	public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
	{
		serializer.SerializeValue(ref Move);
		serializer.SerializeValue(ref Attack);
		serializer.SerializeValue(ref Block);
		serializer.SerializeValue(ref LightBlock);
	}

	public static bool operator == (Motion a, Motion b)
	{
		return 
			b.Move == a.Move && 
			a.Attack == b.Attack && 
			a.Block == b.Block &&
            a.LightBlock == b.LightBlock;
	}
	public static bool operator !=(Motion a, Motion b)
	{
		return
			b.Move != a.Move ||
			a.Attack != b.Attack ||
			a.Block != b.Block ||
            a.LightBlock != b.LightBlock;
	}
}