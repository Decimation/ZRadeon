using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZRadeon
{
	public partial class MainWindow : Window
	{
		private LLKeyboardListener _listener;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			_listener              =  new LLKeyboardListener();
			_listener.OnKeyPressed += _listener_OnKeyPressed;

			_listener.HookKeyboard();
		}

		void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
		{
			Debug.WriteLine($"{e.KeyPressed}");
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			_listener.UnHookKeyboard();
		}
	}

	/*
	 * http://www.dylansweb.com/2014/10/low-level-global-keyboard-hook-sink-in-c-net/
	 */

	public class KeyPressedArgs : EventArgs
	{
		public Key KeyPressed { get; private set; }

		public KeyPressedArgs(Key key)
		{
			KeyPressed = key;
		}
	}
}