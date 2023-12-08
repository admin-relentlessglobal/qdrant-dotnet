namespace Qdrant.Client.Grpc;

/// <summary>
/// A vector
/// </summary>
public partial class Vector
{
	/// <summary>
	/// Implicitly converts an array of <see cref="float"/> to a new instance of <see cref="Vector"/>
	/// </summary>
	/// <param name="values">the array of floats</param>
	/// <returns>a new instance of <see cref="Vector"/></returns>
	public static implicit operator Vector(float[] values) => new() { Data = { values } };

	/// <summary>
	/// Implicitly converts a tuple of sparse values array of <see cref="float"/>
	/// and sparse indices array of <see cref="uint"/> to a new instance of <see cref="Vector"/>
	/// </summary>
	/// <param name="sparseValues">a tuple of arrays of values and indices</param>
	/// <returns>a new instance of <see cref="Vector"/></returns>
	public static implicit operator Vector((float[], uint[]) sparseValues) => new()
	{
		Data = { sparseValues.Item1 },
		Indices = new SparseIndices { Data = { sparseValues.Item2 } }
	};

	/// <summary>
	/// Implicitly converts an array of sparse value index tuples to a new instance of <see cref="Vector"/>
	/// </summary>
	/// <param name="sparseValues">the array of value-index pairs</param>
	/// <returns>a new instance of <see cref="Vector"/></returns>
	public static implicit operator Vector((float, uint)[] sparseValues) => new()
	{
		Data = { sparseValues.Select(v => v.Item1) },
		Indices = new SparseIndices { Data = { sparseValues.Select(v => v.Item2) } }
	};
}
