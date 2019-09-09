using System;

[Flags]
public enum GoShakeType
{
	Position = 0x1,
	Scale = 0x2,
	Eulers = 0x4
}
