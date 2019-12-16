using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace SudokuGame
{
	public class Navigator
	{
		private readonly Action<object> _navigate;

		private Navigator(Action<object> navigate)
		{
			_navigate = navigate;
		}

		private static Navigator _navigator;

		public static void Initialize(Action<object> frameNavigator)
		{
			if (_navigator != null)
				throw new Exception("Navigation is already set");

			_navigator = new Navigator(frameNavigator);
		}

		public static Navigator Default { get => _navigator; }

		public void Navigate<T>(T page) where T : Page
			=> _navigate(page);

		public void NavigateMain<T>(T window) where T : MainWindow
			=> _navigate(window);
	}
}
