using System.Collections.Generic;

namespace ClipperLib
{
	public class ClipperBase
	{
		protected const double horizontal = -3.4E+38;

		protected const int Skip = -2;

		protected const int Unassigned = -1;

		protected const double tolerance = 1E-20;

		internal const long loRange = 1073741823L;

		internal const long hiRange = 4611686018427387903L;

		internal LocalMinima m_MinimaList;

		internal LocalMinima m_CurrentLM;

		internal List<List<TEdge>> m_edges = new List<List<TEdge>>();

		internal bool m_UseFullRange;

		internal bool m_HasOpenPaths;

		public bool PreserveCollinear
		{
			get;
			set;
		}

		internal ClipperBase()
		{
			m_MinimaList = null;
			m_CurrentLM = null;
			m_UseFullRange = false;
			m_HasOpenPaths = false;
		}

		internal static bool near_zero(double val)
		{
			return val > -1E-20 && val < 1E-20;
		}

		internal static bool IsHorizontal(TEdge e)
		{
			return e.Delta.Y == 0;
		}

		internal bool PointIsVertex(IntPoint pt, OutPt pp)
		{
			OutPt outPt = pp;
			do
			{
				if (outPt.Pt == pt)
				{
					return true;
				}
				outPt = outPt.Next;
			}
			while (outPt != pp);
			return false;
		}

		internal bool PointOnLineSegment(IntPoint pt, IntPoint linePt1, IntPoint linePt2, bool UseFullRange)
		{
			if (UseFullRange)
			{
				return (pt.X == linePt1.X && pt.Y == linePt1.Y) || (pt.X == linePt2.X && pt.Y == linePt2.Y) || (pt.X > linePt1.X == pt.X < linePt2.X && pt.Y > linePt1.Y == pt.Y < linePt2.Y && Int128.Int128Mul(pt.X - linePt1.X, linePt2.Y - linePt1.Y) == Int128.Int128Mul(linePt2.X - linePt1.X, pt.Y - linePt1.Y));
			}
			return (pt.X == linePt1.X && pt.Y == linePt1.Y) || (pt.X == linePt2.X && pt.Y == linePt2.Y) || (pt.X > linePt1.X == pt.X < linePt2.X && pt.Y > linePt1.Y == pt.Y < linePt2.Y && (pt.X - linePt1.X) * (linePt2.Y - linePt1.Y) == (linePt2.X - linePt1.X) * (pt.Y - linePt1.Y));
		}

		internal bool PointOnPolygon(IntPoint pt, OutPt pp, bool UseFullRange)
		{
			OutPt outPt = pp;
			do
			{
				if (PointOnLineSegment(pt, outPt.Pt, outPt.Next.Pt, UseFullRange))
				{
					return true;
				}
				outPt = outPt.Next;
			}
			while (outPt != pp);
			return false;
		}

		internal static bool SlopesEqual(TEdge e1, TEdge e2, bool UseFullRange)
		{
			if (UseFullRange)
			{
				return Int128.Int128Mul(e1.Delta.Y, e2.Delta.X) == Int128.Int128Mul(e1.Delta.X, e2.Delta.Y);
			}
			return e1.Delta.Y * e2.Delta.X == e1.Delta.X * e2.Delta.Y;
		}

		protected static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, bool UseFullRange)
		{
			if (UseFullRange)
			{
				return Int128.Int128Mul(pt1.Y - pt2.Y, pt2.X - pt3.X) == Int128.Int128Mul(pt1.X - pt2.X, pt2.Y - pt3.Y);
			}
			return (pt1.Y - pt2.Y) * (pt2.X - pt3.X) - (pt1.X - pt2.X) * (pt2.Y - pt3.Y) == 0;
		}

		protected static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, IntPoint pt4, bool UseFullRange)
		{
			if (UseFullRange)
			{
				return Int128.Int128Mul(pt1.Y - pt2.Y, pt3.X - pt4.X) == Int128.Int128Mul(pt1.X - pt2.X, pt3.Y - pt4.Y);
			}
			return (pt1.Y - pt2.Y) * (pt3.X - pt4.X) - (pt1.X - pt2.X) * (pt3.Y - pt4.Y) == 0;
		}

		public virtual void Clear()
		{
			DisposeLocalMinimaList();
			for (int i = 0; i < m_edges.Count; i++)
			{
				for (int j = 0; j < m_edges[i].Count; j++)
				{
					m_edges[i][j] = null;
				}
				m_edges[i].Clear();
			}
			m_edges.Clear();
			m_UseFullRange = false;
			m_HasOpenPaths = false;
		}

		private void DisposeLocalMinimaList()
		{
			while (m_MinimaList != null)
			{
				LocalMinima next = m_MinimaList.Next;
				m_MinimaList = null;
				m_MinimaList = next;
			}
			m_CurrentLM = null;
		}

		private void RangeTest(IntPoint Pt, ref bool useFullRange)
		{
			if (useFullRange)
			{
				if (Pt.X > 4611686018427387903L || Pt.Y > 4611686018427387903L || -Pt.X > 4611686018427387903L || -Pt.Y > 4611686018427387903L)
				{
					throw new ClipperException("Coordinate outside allowed range");
				}
			}
			else if (Pt.X > 1073741823 || Pt.Y > 1073741823 || -Pt.X > 1073741823 || -Pt.Y > 1073741823)
			{
				useFullRange = true;
				RangeTest(Pt, ref useFullRange);
			}
		}

		private void InitEdge(TEdge e, TEdge eNext, TEdge ePrev, IntPoint pt)
		{
			e.Next = eNext;
			e.Prev = ePrev;
			e.Curr = pt;
			e.OutIdx = -1;
		}

		private void InitEdge2(TEdge e, PolyType polyType)
		{
			if (e.Curr.Y >= e.Next.Curr.Y)
			{
				e.Bot = e.Curr;
				e.Top = e.Next.Curr;
			}
			else
			{
				e.Top = e.Curr;
				e.Bot = e.Next.Curr;
			}
			SetDx(e);
			e.PolyTyp = polyType;
		}

		private TEdge FindNextLocMin(TEdge E)
		{
			while (true)
			{
				if (!(E.Bot != E.Prev.Bot) && !(E.Curr == E.Top))
				{
					if (E.Dx != -3.4E+38 && E.Prev.Dx != -3.4E+38)
					{
						break;
					}
					while (E.Prev.Dx == -3.4E+38)
					{
						E = E.Prev;
					}
					TEdge tEdge = E;
					while (E.Dx == -3.4E+38)
					{
						E = E.Next;
					}
					if (E.Top.Y != E.Prev.Bot.Y)
					{
						if (tEdge.Prev.Bot.X < E.Bot.X)
						{
							E = tEdge;
						}
						break;
					}
				}
				else
				{
					E = E.Next;
				}
			}
			return E;
		}

		private TEdge ProcessBound(TEdge E, bool IsClockwise)
		{
			TEdge tEdge = E;
			TEdge tEdge2 = E;
			if (E.Dx == -3.4E+38)
			{
				long num = (!IsClockwise) ? E.Next.Bot.X : E.Prev.Bot.X;
				if (E.Bot.X != num)
				{
					ReverseHorizontal(E);
				}
			}
			if (tEdge2.OutIdx != -2)
			{
				if (IsClockwise)
				{
					while (tEdge2.Top.Y == tEdge2.Next.Bot.Y && tEdge2.Next.OutIdx != -2)
					{
						tEdge2 = tEdge2.Next;
					}
					if (tEdge2.Dx == -3.4E+38 && tEdge2.Next.OutIdx != -2)
					{
						TEdge tEdge3 = tEdge2;
						while (tEdge3.Prev.Dx == -3.4E+38)
						{
							tEdge3 = tEdge3.Prev;
						}
						if (tEdge3.Prev.Top.X == tEdge2.Next.Top.X)
						{
							if (!IsClockwise)
							{
								tEdge2 = tEdge3.Prev;
							}
						}
						else if (tEdge3.Prev.Top.X > tEdge2.Next.Top.X)
						{
							tEdge2 = tEdge3.Prev;
						}
					}
					while (E != tEdge2)
					{
						E.NextInLML = E.Next;
						if (E.Dx == -3.4E+38 && E != tEdge && E.Bot.X != E.Prev.Top.X)
						{
							ReverseHorizontal(E);
						}
						E = E.Next;
					}
					if (E.Dx == -3.4E+38 && E != tEdge && E.Bot.X != E.Prev.Top.X)
					{
						ReverseHorizontal(E);
					}
					tEdge2 = tEdge2.Next;
				}
				else
				{
					while (tEdge2.Top.Y == tEdge2.Prev.Bot.Y && tEdge2.Prev.OutIdx != -2)
					{
						tEdge2 = tEdge2.Prev;
					}
					if (tEdge2.Dx == -3.4E+38 && tEdge2.Prev.OutIdx != -2)
					{
						TEdge tEdge3 = tEdge2;
						while (tEdge3.Next.Dx == -3.4E+38)
						{
							tEdge3 = tEdge3.Next;
						}
						if (tEdge3.Next.Top.X == tEdge2.Prev.Top.X)
						{
							if (!IsClockwise)
							{
								tEdge2 = tEdge3.Next;
							}
						}
						else if (tEdge3.Next.Top.X > tEdge2.Prev.Top.X)
						{
							tEdge2 = tEdge3.Next;
						}
					}
					while (E != tEdge2)
					{
						E.NextInLML = E.Prev;
						if (E.Dx == -3.4E+38 && E != tEdge && E.Bot.X != E.Next.Top.X)
						{
							ReverseHorizontal(E);
						}
						E = E.Prev;
					}
					if (E.Dx == -3.4E+38 && E != tEdge && E.Bot.X != E.Next.Top.X)
					{
						ReverseHorizontal(E);
					}
					tEdge2 = tEdge2.Prev;
				}
			}
			if (tEdge2.OutIdx == -2)
			{
				E = tEdge2;
				if (IsClockwise)
				{
					while (E.Top.Y == E.Next.Bot.Y)
					{
						E = E.Next;
					}
					while (E != tEdge2 && E.Dx == -3.4E+38)
					{
						E = E.Prev;
					}
				}
				else
				{
					while (E.Top.Y == E.Prev.Bot.Y)
					{
						E = E.Prev;
					}
					while (E != tEdge2 && E.Dx == -3.4E+38)
					{
						E = E.Next;
					}
				}
				if (E == tEdge2)
				{
					tEdge2 = ((!IsClockwise) ? E.Prev : E.Next);
				}
				else
				{
					E = ((!IsClockwise) ? tEdge2.Prev : tEdge2.Next);
					LocalMinima localMinima = new LocalMinima();
					localMinima.Next = null;
					localMinima.Y = E.Bot.Y;
					localMinima.LeftBound = null;
					localMinima.RightBound = E;
					localMinima.RightBound.WindDelta = 0;
					tEdge2 = ProcessBound(localMinima.RightBound, IsClockwise);
					InsertLocalMinima(localMinima);
				}
			}
			return tEdge2;
		}

		public bool AddPath(List<IntPoint> pg, PolyType polyType, bool Closed)
		{
			if (!Closed)
			{
				throw new ClipperException("AddPath: Open paths have been disabled.");
			}
			int num = pg.Count - 1;
			if (Closed)
			{
				while (num > 0 && pg[num] == pg[0])
				{
					num--;
				}
			}
			while (num > 0 && pg[num] == pg[num - 1])
			{
				num--;
			}
			if ((Closed && num < 2) || (!Closed && num < 1))
			{
				return false;
			}
			List<TEdge> list = new List<TEdge>(num + 1);
			for (int i = 0; i <= num; i++)
			{
				list.Add(new TEdge());
			}
			bool flag = true;
			list[1].Curr = pg[1];
			RangeTest(pg[0], ref m_UseFullRange);
			RangeTest(pg[num], ref m_UseFullRange);
			InitEdge(list[0], list[1], list[num], pg[0]);
			InitEdge(list[num], list[0], list[num - 1], pg[num]);
			for (int num2 = num - 1; num2 >= 1; num2--)
			{
				RangeTest(pg[num2], ref m_UseFullRange);
				InitEdge(list[num2], list[num2 + 1], list[num2 - 1], pg[num2]);
			}
			TEdge tEdge = list[0];
			TEdge tEdge2 = tEdge;
			TEdge tEdge3 = tEdge;
			while (true)
			{
				if (tEdge2.Curr == tEdge2.Next.Curr)
				{
					if (tEdge2 == tEdge2.Next)
					{
						break;
					}
					if (tEdge2 == tEdge)
					{
						tEdge = tEdge2.Next;
					}
					tEdge2 = RemoveEdge(tEdge2);
					tEdge3 = tEdge2;
					continue;
				}
				if (tEdge2.Prev == tEdge2.Next)
				{
					break;
				}
				if (Closed && SlopesEqual(tEdge2.Prev.Curr, tEdge2.Curr, tEdge2.Next.Curr, m_UseFullRange) && (!PreserveCollinear || !Pt2IsBetweenPt1AndPt3(tEdge2.Prev.Curr, tEdge2.Curr, tEdge2.Next.Curr)))
				{
					if (tEdge2 == tEdge)
					{
						tEdge = tEdge2.Next;
					}
					tEdge2 = RemoveEdge(tEdge2);
					tEdge2 = tEdge2.Prev;
					tEdge3 = tEdge2;
				}
				else
				{
					tEdge2 = tEdge2.Next;
					if (tEdge2 == tEdge3)
					{
						break;
					}
				}
			}
			if ((!Closed && tEdge2 == tEdge2.Next) || (Closed && tEdge2.Prev == tEdge2.Next))
			{
				return false;
			}
			if (!Closed)
			{
				m_HasOpenPaths = true;
				tEdge.Prev.OutIdx = -2;
			}
			TEdge tEdge4 = tEdge;
			tEdge2 = tEdge;
			do
			{
				InitEdge2(tEdge2, polyType);
				tEdge2 = tEdge2.Next;
				if (flag && tEdge2.Curr.Y != tEdge.Curr.Y)
				{
					flag = false;
				}
			}
			while (tEdge2 != tEdge);
			if (flag)
			{
				if (Closed)
				{
					return false;
				}
				tEdge2.Prev.OutIdx = -2;
				if (tEdge2.Prev.Bot.X < tEdge2.Prev.Top.X)
				{
					ReverseHorizontal(tEdge2.Prev);
				}
				LocalMinima localMinima = new LocalMinima();
				localMinima.Next = null;
				localMinima.Y = tEdge2.Bot.Y;
				localMinima.LeftBound = null;
				localMinima.RightBound = tEdge2;
				localMinima.RightBound.Side = EdgeSide.esRight;
				localMinima.RightBound.WindDelta = 0;
				while (tEdge2.Next.OutIdx != -2)
				{
					tEdge2.NextInLML = tEdge2.Next;
					if (tEdge2.Bot.X != tEdge2.Prev.Top.X)
					{
						ReverseHorizontal(tEdge2);
					}
					tEdge2 = tEdge2.Next;
				}
				InsertLocalMinima(localMinima);
				m_edges.Add(list);
				return true;
			}
			m_edges.Add(list);
			TEdge tEdge5 = null;
			while (true)
			{
				tEdge2 = FindNextLocMin(tEdge2);
				if (tEdge2 == tEdge5)
				{
					break;
				}
				if (tEdge5 == null)
				{
					tEdge5 = tEdge2;
				}
				LocalMinima localMinima2 = new LocalMinima();
				localMinima2.Next = null;
				localMinima2.Y = tEdge2.Bot.Y;
				bool flag2;
				if (tEdge2.Dx < tEdge2.Prev.Dx)
				{
					localMinima2.LeftBound = tEdge2.Prev;
					localMinima2.RightBound = tEdge2;
					flag2 = false;
				}
				else
				{
					localMinima2.LeftBound = tEdge2;
					localMinima2.RightBound = tEdge2.Prev;
					flag2 = true;
				}
				localMinima2.LeftBound.Side = EdgeSide.esLeft;
				localMinima2.RightBound.Side = EdgeSide.esRight;
				if (!Closed)
				{
					localMinima2.LeftBound.WindDelta = 0;
				}
				else if (localMinima2.LeftBound.Next == localMinima2.RightBound)
				{
					localMinima2.LeftBound.WindDelta = -1;
				}
				else
				{
					localMinima2.LeftBound.WindDelta = 1;
				}
				localMinima2.RightBound.WindDelta = -localMinima2.LeftBound.WindDelta;
				tEdge2 = ProcessBound(localMinima2.LeftBound, flag2);
				TEdge tEdge6 = ProcessBound(localMinima2.RightBound, !flag2);
				if (localMinima2.LeftBound.OutIdx == -2)
				{
					localMinima2.LeftBound = null;
				}
				else if (localMinima2.RightBound.OutIdx == -2)
				{
					localMinima2.RightBound = null;
				}
				InsertLocalMinima(localMinima2);
				if (!flag2)
				{
					tEdge2 = tEdge6;
				}
			}
			return true;
		}

		public bool AddPaths(List<List<IntPoint>> ppg, PolyType polyType, bool closed)
		{
			bool result = false;
			for (int i = 0; i < ppg.Count; i++)
			{
				if (AddPath(ppg[i], polyType, closed))
				{
					result = true;
				}
			}
			return result;
		}

		internal bool Pt2IsBetweenPt1AndPt3(IntPoint pt1, IntPoint pt2, IntPoint pt3)
		{
			if (pt1 == pt3 || pt1 == pt2 || pt3 == pt2)
			{
				return false;
			}
			if (pt1.X != pt3.X)
			{
				return pt2.X > pt1.X == pt2.X < pt3.X;
			}
			return pt2.Y > pt1.Y == pt2.Y < pt3.Y;
		}

		private TEdge RemoveEdge(TEdge e)
		{
			e.Prev.Next = e.Next;
			e.Next.Prev = e.Prev;
			TEdge next = e.Next;
			e.Prev = null;
			return next;
		}

		private void SetDx(TEdge e)
		{
			e.Delta.X = e.Top.X - e.Bot.X;
			e.Delta.Y = e.Top.Y - e.Bot.Y;
			if (e.Delta.Y == 0)
			{
				e.Dx = -3.4E+38;
			}
			else
			{
				e.Dx = (double)e.Delta.X / (double)e.Delta.Y;
			}
		}

		private void InsertLocalMinima(LocalMinima newLm)
		{
			if (m_MinimaList == null)
			{
				m_MinimaList = newLm;
				return;
			}
			if (newLm.Y >= m_MinimaList.Y)
			{
				newLm.Next = m_MinimaList;
				m_MinimaList = newLm;
				return;
			}
			LocalMinima localMinima = m_MinimaList;
			while (localMinima.Next != null && newLm.Y < localMinima.Next.Y)
			{
				localMinima = localMinima.Next;
			}
			newLm.Next = localMinima.Next;
			localMinima.Next = newLm;
		}

		protected void PopLocalMinima()
		{
			if (m_CurrentLM != null)
			{
				m_CurrentLM = m_CurrentLM.Next;
			}
		}

		private void ReverseHorizontal(TEdge e)
		{
			long x = e.Top.X;
			e.Top.X = e.Bot.X;
			e.Bot.X = x;
		}

		protected virtual void Reset()
		{
			m_CurrentLM = m_MinimaList;
			if (m_CurrentLM == null)
			{
				return;
			}
			for (LocalMinima localMinima = m_MinimaList; localMinima != null; localMinima = localMinima.Next)
			{
				TEdge leftBound = localMinima.LeftBound;
				if (leftBound != null)
				{
					leftBound.Curr = leftBound.Bot;
					leftBound.Side = EdgeSide.esLeft;
					leftBound.OutIdx = -1;
				}
				leftBound = localMinima.RightBound;
				if (leftBound != null)
				{
					leftBound.Curr = leftBound.Bot;
					leftBound.Side = EdgeSide.esRight;
					leftBound.OutIdx = -1;
				}
			}
		}

		public static IntRect GetBounds(List<List<IntPoint>> paths)
		{
			int i = 0;
			int count;
			for (count = paths.Count; i < count && paths[i].Count == 0; i++)
			{
			}
			if (i == count)
			{
				return new IntRect(0L, 0L, 0L, 0L);
			}
			IntRect result = default(IntRect);
			IntPoint intPoint = paths[i][0];
			result.left = intPoint.X;
			result.right = result.left;
			IntPoint intPoint2 = paths[i][0];
			result.top = intPoint2.Y;
			result.bottom = result.top;
			for (; i < count; i++)
			{
				for (int j = 0; j < paths[i].Count; j++)
				{
					IntPoint intPoint3 = paths[i][j];
					if (intPoint3.X < result.left)
					{
						IntPoint intPoint4 = paths[i][j];
						result.left = intPoint4.X;
					}
					else
					{
						IntPoint intPoint5 = paths[i][j];
						if (intPoint5.X > result.right)
						{
							IntPoint intPoint6 = paths[i][j];
							result.right = intPoint6.X;
						}
					}
					IntPoint intPoint7 = paths[i][j];
					if (intPoint7.Y < result.top)
					{
						IntPoint intPoint8 = paths[i][j];
						result.top = intPoint8.Y;
						continue;
					}
					IntPoint intPoint9 = paths[i][j];
					if (intPoint9.Y > result.bottom)
					{
						IntPoint intPoint10 = paths[i][j];
						result.bottom = intPoint10.Y;
					}
				}
			}
			return result;
		}
	}
}
