using Delaunay.Geo;
using Delaunay.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Delaunay
{
	public sealed class SiteList : IDisposable
	{
		public List<Site> _sites;

		private int _currentIndex;

		private bool _sorted;

		public int Count => _sites.Count;

		public SiteList()
		{
			_sites = new List<Site>();
			_sorted = false;
		}

		public void Dispose()
		{
			if (_sites != null)
			{
				for (int i = 0; i < _sites.Count; i++)
				{
					Site site = _sites[i];
					site.Dispose();
				}
				_sites.Clear();
				_sites = null;
			}
		}

		public int Add(Site site)
		{
			_sorted = false;
			_sites.Add(site);
			return _sites.Count;
		}

		public Site Next()
		{
			if (!_sorted)
			{
				UnityEngine.Debug.LogError("SiteList::next():  sites have not been sorted");
			}
			if (_currentIndex < _sites.Count)
			{
				return _sites[_currentIndex++];
			}
			return null;
		}

		internal Rect GetSitesBounds()
		{
			if (!_sorted)
			{
				Site.SortSites(_sites);
				_currentIndex = 0;
				_sorted = true;
			}
			if (_sites.Count == 0)
			{
				return new Rect(0f, 0f, 0f, 0f);
			}
			float num = float.MaxValue;
			float num2 = float.MinValue;
			for (int i = 0; i < _sites.Count; i++)
			{
				Site site = _sites[i];
				if (site.x < num)
				{
					num = site.x;
				}
				if (site.x > num2)
				{
					num2 = site.x;
				}
			}
			float y = _sites[0].y;
			float y2 = _sites[_sites.Count - 1].y;
			return new Rect(num, y, num2 - num, y2 - y);
		}

		public List<uint> SiteColors()
		{
			List<uint> list = new List<uint>();
			for (int i = 0; i < _sites.Count; i++)
			{
				Site site = _sites[i];
				list.Add(site.color);
			}
			return list;
		}

		public List<Vector2> SiteCoords()
		{
			List<Vector2> list = new List<Vector2>();
			for (int i = 0; i < _sites.Count; i++)
			{
				Site site = _sites[i];
				list.Add(site.Coord);
			}
			return list;
		}

		public List<Circle> Circles()
		{
			List<Circle> list = new List<Circle>();
			for (int i = 0; i < _sites.Count; i++)
			{
				Site site = _sites[i];
				float radius = 0f;
				Edge edge = site.NearestEdge();
				if (!edge.IsPartOfConvexHull())
				{
					radius = edge.SitesDistance() * 0.5f;
				}
				list.Add(new Circle(site.x, site.y, radius));
			}
			return list;
		}

		public List<List<Vector2>> Regions(Rect plotBounds)
		{
			List<List<Vector2>> list = new List<List<Vector2>>();
			for (int i = 0; i < _sites.Count; i++)
			{
				Site site = _sites[i];
				list.Add(site.Region(plotBounds));
			}
			return list;
		}

		public Vector2? NearestSitePoint(float x, float y)
		{
			return null;
		}
	}
}
