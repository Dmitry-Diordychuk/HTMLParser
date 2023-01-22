using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HTMLParser.Model;

public class HtmlElement : HtmlData, ICloneable
{
	public override string ToString()
	{
		return "<" + Name + ">";
	}
	
	public object Clone()
	{
		return MemberwiseClone();
	}
}