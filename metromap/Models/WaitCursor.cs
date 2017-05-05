using System;
using System.Windows.Input;

namespace MetroMap
{
    /// <summary>
    /// Ждущий курсор
    /// </summary>
    public class WaitCursor : IDisposable
    {
        private Cursor _previousCursor;

        public WaitCursor()
        {
            _previousCursor = Mouse.OverrideCursor;

            Mouse.OverrideCursor = Cursors.Wait;
        }

        #region IDisposable

        public void Dispose()
        {
            Mouse.OverrideCursor = _previousCursor;
        }

        #endregion
    }
}
