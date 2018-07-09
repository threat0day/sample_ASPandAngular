﻿
using GameStore.Domain.Abstract;
using System.Web.Security;

namespace GameStore.Domain.Concrete
{
	public class FormAuthProvider : IAuthProvider
	{
		public bool Authenticate(string username, string password)
		{
			bool result = FormsAuthentication.Authenticate(username, password);
			if (result)
				FormsAuthentication.SetAuthCookie(username, false);
			return result;
		}
	}
}
