using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Timers;
using System.Windows.Forms;
using DSW.Properties;
using Timer = System.Timers.Timer;

namespace DSW.popup
{
    static class Notifier
    {
        private static readonly Queue<ToastForm> Stack = new Queue<ToastForm>(); 
        private static readonly ToastForm[] Viewport;
        private static readonly int X = Screen.PrimaryScreen.WorkingArea.Right - 289 - 3;
        private static Form1 _mf;
        static Notifier()
        {
            using (var stackTimer = new Timer(750))
            {
                stackTimer.Elapsed += _stackTimer_Elapsed;
                stackTimer.Enabled = true;
                stackTimer.Start();
            }
            Viewport = new ToastForm[(Screen.PrimaryScreen.WorkingArea.Bottom - 200) / 69];
        }

        static void _stackTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            while (true) 
            {

                var pos = GetNewPos(69);
                var sc = 0;

                if (_mf.IsDisposed | _mf.Disposing)
                {
                    return;
                }

                _mf.Invoke(new MethodInvoker(delegate
                    {
                        sc = Stack.Count;
                    }));

                if (((int)pos[1] == -1) | (sc == 0))
                {
                    break;
                }
                _mf.Invoke(new MethodInvoker(delegate
                    {
                    var tf = Stack.Dequeue();
                    
                    tf.StartPosition = new FormStartPosition();
                    tf.Opacity = 0;
                    
                    tf.Location = new Point(X,(int)pos[0]);
                    Viewport[(int)pos[1]] = tf;
                        tf.Setvp((int) pos[1]);
                    tf.Timer.Interval = 5000 + 1250 * ((int)pos[1]);
                    tf.Show();
                }));
                if (Settings.Default.UseSound)
                {
                    SystemSounds.Exclamation.Play();
                }
                
            } 

        }


        /// <summary>
        /// Creates and sends a new notification window.
        /// </summary>
        /// <param name="text">Text for the popup.</param>
        public static void Pop(string text)
        {
            _mf = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            if (_mf == null)
            {
                return;
            }
            if (_mf.IsDisposed | _mf.Disposing)
            {
                return;
            }
                _mf.Invoke(new MethodInvoker(delegate
                    {
                        var tf = new ToastForm(text);
                        Stack.Enqueue(tf);
                    }));
            
        }


        private static object[] GetNewPos(int height)
        {
            var ind = -1;
            _mf.Invoke(new MethodInvoker(delegate
            {
                ind = Array.IndexOf(Viewport, null);

            }));


            return new object[] { Screen.PrimaryScreen.WorkingArea.Bottom - height * (ind + 1) - 5 * (ind + 1), ind };
        }

        public static void Remove(int num)
        {
            if (_mf.IsDisposed | _mf.Disposing)
            {
                return;
            }
                _mf.Invoke(new MethodInvoker(delegate
                    {
                        Viewport[num] = null;
                    }));
            
        }
    }
}
