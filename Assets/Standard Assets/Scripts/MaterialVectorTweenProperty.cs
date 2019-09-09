using UnityEngine;

public class MaterialVectorTweenProperty : AbstractMaterialVectorTweenProperty
{
	private string _materialPropertyName;

	public MaterialVectorTweenProperty(Vector4 endValue, string propertyName, bool isRelative = false)
		: base(endValue, isRelative)
	{
		_materialPropertyName = propertyName;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (base.Equals(obj))
		{
			return _materialPropertyName == ((MaterialVectorTweenProperty)obj)._materialPropertyName;
		}
		return false;
	}

	public override void prepareForUse()
	{
		_endValue = _originalEndValue;
		if (_ownerTween.isFrom)
		{
			_startValue = _endValue;
			_endValue = _target.GetVector(_materialPropertyName);
		}
		else
		{
			_startValue = _target.GetVector(_materialPropertyName);
		}
		base.prepareForUse();
	}

	public override void tick(float totalElapsedTime)
	{
		float value = _easeFunction(totalElapsedTime, 0f, 1f, _ownerTween.duration);
		Vector4 value2 = GoTweenUtils.unclampedVector4Lerp(_startValue, _diffValue, value);
		_target.SetVector(_materialPropertyName, value2);
	}
}
