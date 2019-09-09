using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGoSplineSolver
{
	protected struct Segment
	{
		public float time;

		public float distance;

		public Segment(float time, float distance)
		{
			this.time = time;
			this.distance = distance;
		}
	}

	protected List<Vector3> _nodes;

	protected float _pathLength;

	protected int totalSubdivisionsPerNodeForLookupTable = 5;

	protected List<Segment> segments;

	public List<Vector3> nodes => _nodes;

	public float pathLength => _pathLength;

	public virtual void buildPath()
	{
		int num = _nodes.Count * totalSubdivisionsPerNodeForLookupTable;
		if (segments == null)
		{
			segments = new List<Segment>(num);
		}
		else
		{
			segments.Clear();
			segments.Capacity = num;
		}
		_pathLength = 0f;
		float num2 = 1f / (float)num;
		Vector3 b = getPoint(0f);
		for (int i = 1; i < num + 1; i++)
		{
			float num3 = num2 * (float)i;
			Vector3 point = getPoint(num3);
			_pathLength += Vector3.Distance(point, b);
			b = point;
			segments.Add(new Segment(num3, _pathLength));
		}
	}

	public abstract void closePath();

	public abstract Vector3 getPoint(float t);

	public virtual Vector3 getPointOnPath(float t)
	{
		float num = _pathLength * t;
		int i;
		for (i = 0; i < segments.Count; i++)
		{
			Segment segment = segments[i];
			if (segment.distance >= num)
			{
				break;
			}
		}
		Segment segment2 = segments[i];
		if (i == 0)
		{
			t = num / segment2.distance * segment2.time;
		}
		else
		{
			Segment segment3 = segments[i - 1];
			float num2 = segment2.time - segment3.time;
			float num3 = segment2.distance - segment3.distance;
			t = segment3.time + (num - segment3.distance) / num3 * num2;
		}
		return getPoint(t);
	}

	public void reverseNodes()
	{
		_nodes.Reverse();
	}

	public virtual void drawGizmos()
	{
	}
}
