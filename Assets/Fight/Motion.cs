using System;

[Serializable]
public struct Motion
{
	public Direction Move;
	public Direction Attack;
	public Direction Block;

	public override bool Equals(object obj)
	{
		return obj is Motion motion &&
			   Move == motion.Move &&
			   Attack == motion.Attack &&
			   Block == motion.Block;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Move, Attack, Block);
	}

	public static bool operator == (Motion a, Motion b)
	{
		return 
			b.Move == a.Move && 
			a.Attack == b.Attack && 
			a.Block == b.Block;
	}
	public static bool operator !=(Motion a, Motion b)
	{
		return
			b.Move != a.Move ||
			a.Attack != b.Attack ||
			a.Block != b.Block;
	}
}