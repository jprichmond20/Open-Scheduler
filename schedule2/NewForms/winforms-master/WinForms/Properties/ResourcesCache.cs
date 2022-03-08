﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;

namespace AdamsLair.WinForms.Properties
{
	public static class ResourcesCache
	{
		public readonly	static Bitmap ImageAdd					= Resources.ImageAdd;
		public readonly	static Bitmap ImageDelete				= Resources.ImageDelete;
		public readonly	static Bitmap NumberGripIcon			= Resources.NumberGripIcon;
		public readonly	static Bitmap DropDownIcon				= Resources.DropDownIcon;
		public readonly	static Bitmap ExpandNodeClosedDisabled	= Resources.ExpandNodeClosedDisabled;
		public readonly	static Bitmap ExpandNodeClosedNormal	= Resources.ExpandNodeClosedNormal;
		public readonly	static Bitmap ExpandNodeClosedHot		= Resources.ExpandNodeClosedHot;
		public readonly	static Bitmap ExpandNodeClosedPressed	= Resources.ExpandNodeClosedPressed;
		public readonly	static Bitmap ExpandNodeOpenedDisabled	= Resources.ExpandNodeOpenedDisabled;
		public readonly	static Bitmap ExpandNodeOpenedNormal	= Resources.ExpandNodeOpenedNormal;
		public readonly	static Bitmap ExpandNodeOpenedHot		= Resources.ExpandNodeOpenedHot;
		public readonly	static Bitmap ExpandNodeOpenedPressed	= Resources.ExpandNodeOpenedPressed;
		public readonly	static Bitmap ArrowDown					= Resources.ArrowDown;
		public readonly	static Bitmap ArrowDownLeft				= Resources.ArrowDownLeft;
		public readonly	static Bitmap ArrowDownRight			= Resources.ArrowDownRight;
		public readonly	static Bitmap ArrowUp					= Resources.ArrowUp;
		public readonly	static Bitmap ArrowUpLeft				= Resources.ArrowUpLeft;
		public readonly	static Bitmap ArrowUpRight				= Resources.ArrowUpRight;
		public readonly	static Bitmap ArrowLeft					= Resources.ArrowLeft;
		public readonly	static Bitmap ArrowRight				= Resources.ArrowRight;

		public readonly static Font DefaultFont = SystemFonts.DefaultFont;
		public readonly static Font DefaultFontSmall = new Font(DefaultFont.FontFamily, DefaultFont.Size * 0.9f, DefaultFont.Unit);
		public readonly static Font DefaultFontBold = new Font(DefaultFont, FontStyle.Bold);
		public readonly static Font DefaultFontBoldSmall = new Font(DefaultFontSmall, FontStyle.Bold);
	}
}
