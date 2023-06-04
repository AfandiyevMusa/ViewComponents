using System;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
	public class HeaderViewComponents:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return await Task.FromResult(View());
		}
	}
}

