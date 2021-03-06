using UnityEngine;

public class PivotTweenProperty : AbstractTweenProperty
{
	protected RectTransform _target;

	protected Vector2 _originalEndValue;

	protected Vector2 _startValue;

	protected Vector2 _endValue;

	protected Vector2 _diffValue;

	public PivotTweenProperty(Vector2 endValue, bool isRelative = false)
		: base(isRelative)
	{
		_originalEndValue = endValue;
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
			_startValue = ((!_isRelative) ? _endValue : (_endValue + _target.pivot));
			_endValue = _target.pivot;
		}
		else
		{
			_startValue = _target.pivot;
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
		Vector2 pivot = GoTweenUtils.unclampedVector2Lerp(_startValue, _diffValue, value);
		_target.pivot = pivot;
	}

	public void resetWithNewEndValue(Vector2 endValue)
	{
		_originalEndValue = endValue;
		prepareForUse();
	}
}
