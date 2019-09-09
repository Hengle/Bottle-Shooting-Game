using System.Runtime.CompilerServices;

public class GoProxyProp<T>
{
	public T value
	{
		[CompilerGenerated]
		get
		{
			return value;
		}
		[CompilerGenerated]
		set
		{
			this.value = value;
		}
	}

	public GoProxyProp(T startValue)
	{
		value = startValue;
	}
}
