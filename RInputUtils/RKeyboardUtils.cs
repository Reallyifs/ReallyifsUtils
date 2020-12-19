using Microsoft.Xna.Framework.Input;
using Terraria.ModLoader;

namespace ReallyifsUtils.RInputUtils
{
    /// <summary>
    /// 如果你要使用此工具，请在你的 <see cref="Mod.PostUpdateInput"/> 中使用 <see cref="KeyboardStateUpdate"/>
    /// </summary>
    public static class RKeyboardUtils
    {
        public const double MaxDoubleClickTime = 0.25;

        private static KeyboardState _state;
        private static KeyboardState _oldState;

        private static bool[] _clickList;
        private static byte[] _clickTimeList;

        public static KeyboardState State
        {
            get
            {
                CheckUpdate();
                return _state;
            }
        }

        public static KeyboardState OldState
        {
            get
            {
                CheckUpdate();
                return _oldState;
            }
        }

        /// <summary>
        /// <paramref name="key"/> 所代表的键是否被单击
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyboardClick(Keys key)
        {
            if (OldState.IsKeyDown(key) && State.IsKeyUp(key))
            {
                _clickList[(int)key] = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// <paramref name="key"/> 所代表的键是否被双击
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyboardDoubleClick(Keys key)
        {
            if (_clickList[(int)key] && OldState.IsKeyDown(key) && State.IsKeyUp(key))
            {
                _clickList[(int)key] = false;
                _clickTimeList[(int)key] = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// <paramref name="key"/> 所代表的键是否按下
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyboardPressed(Keys key) => State.IsKeyDown(key);

        /// <summary>
        /// <paramref name="key"/> 所代表的键是否松开
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyboardReleased(Keys key) => State.IsKeyUp(key);

        /// <summary>
        /// <paramref name="key"/> 所代表的键在上一帧是否按下
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyboardPrePressed(Keys key) => OldState.IsKeyDown(key);

        /// <summary>
        /// <paramref name="key"/> 所代表的键在上一帧是否松开
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyboardPreReleased(Keys key) => OldState.IsKeyUp(key);

        private static void CheckUpdate()
        {
            if (_state == null || _oldState == null)
            {
                _state = Keyboard.GetState();
                _oldState = _state;
            }
            if (_clickList == null || _clickTimeList == null)
            {
                _clickList = new bool[255];
                _clickTimeList = new byte[255];
            }
        }

        /// <summary>
        /// 更新 <see cref="RKeyboardUtils"/> 的状态
        /// </summary>
        public static void KeyboardStateUpdate()
        {
            CheckUpdate();
            for (int i = 0; i < _clickList.Length; i++)
            {
                if (_clickTimeList[i] > MaxDoubleClickTime)
                {
                    _clickList[i] = false;
                    _clickTimeList[i] = 0;
                }
                if (_clickList[i])
                    _clickTimeList[i]++;
            }
        }
    }
}