using UnityEngine;

public class OffsetTweenProperty : AbstractTweenProperty
{
	protected bool _useMax;

	protected RectTransform _target;

	protected Vector2 _originalEndValue;

	protected Vector2 _startValue;

	protected Vector2 _endValue;

	protected Vector2 _diffValue;

	public OffsetTweenProperty(Vector2 endValue, bool isRelative = false, bool useMax = false)
		: base(isRelative)
	{
		_originalEndValue = endValue;
		_useMax = useMax;
	}

	public override bool validateTarget(object target)
	{
		return target is RectTransform;
	}

	public override void prepareForUse()
	{
		_target = (_ownerTween.target as RectTransform);
		_endValue = _originalEndValue;
		if (_ownerTween.isFrom)
		{
			if (_useMax)
			{
				_startValue = ((!_isRelative) ? _endValue : (_endValue + _target.offsetMax));
				_endValue = _target.offsetMax;
			}
			else
			{
				_startValue = ((!_isRelative) ? _endValue : (_endValue + _target.offsetMin));
				_endValue = _target.offsetMin;
			}
		}
		else
		{
			_startValue = ((!_useMax) ? _target.offsetMin : _target.offsetMax);
		}
		if (_isRelative && !_ownerTween.isFrom)
		{
			_diffValue = _endValue;
		}
		else
		{
			_diffValue = _endValue - _startValue;
		}
	}

	public override void tick(float totalElapsedTime)
	{
		float value = _easeFunction(totalElapsedTime, 0f, 1f, _ownerTween.duration);
		Vector2 vector = GoTweenUtils.unclampedVector2Lerp(_startValue, _diffValue, value);
		if (_useMax)
		{
			_target.offsetMax = vector;
		}
		else
		{
			_target.offsetMin = vector;
		}
	}

	public void resetWithNewEndValue(Vector2 endValue)
	{
		_originalEndValue = endValue;
		prepareForUse();
	}
}
