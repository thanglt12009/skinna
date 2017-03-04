#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using SkinCare.Entities;
using SkinCare.Data;

#endregion

namespace SkinCare.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="DonHangProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DonHangProviderBase : DonHangProviderBaseCore
	{
	} // end class
} // end namespace
