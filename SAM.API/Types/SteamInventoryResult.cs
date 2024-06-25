namespace SAM.API.Types;

public struct SteamInventoryResult : IEquatable<SteamInventoryResult>, IComparable<SteamInventoryResult>
{
    // Name: SteamInventoryResult, Type: int
    public int Value;

    public static implicit operator SteamInventoryResult(int value) => new SteamInventoryResult() { Value = value };
    public static implicit operator int(SteamInventoryResult value) => value.Value;
    public override string ToString() => Value.ToString();
    public override int GetHashCode() => Value.GetHashCode();
    public override bool Equals(object p) => this.Equals((SteamInventoryResult)p);
    public bool Equals(SteamInventoryResult p) => p.Value == Value;
    public static bool operator ==(SteamInventoryResult a, SteamInventoryResult b) => a.Equals(b);
    public static bool operator !=(SteamInventoryResult a, SteamInventoryResult b) => !a.Equals(b);
    public int CompareTo(SteamInventoryResult other) => Value.CompareTo(other.Value);
}
